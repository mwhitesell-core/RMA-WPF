identification division.
program-id. d001.
author. dyad computer systems inc.
installation. rma.
date-written. 80/04/01.
date-compiled.
security.
*
*    files      : f001  - batch control file
*               : f002  - claims master
*               : f011  - subscriber master
*               : f010  - patient master
*               : f020  - doctor master
*               : f040  - oma fee schedule master
*               : f090  - ram  constants master
*               : f090i - isam constants master
*               : f091  - valid diagnostic codes file
*               : f086  - corrected patient file
*               : f094  - message, subdivision master
*
*    program purpose : claims batch data entry
*
*            nov/83 (a.j.) - correct doc location verification
*            jan/84 (a.j.) - include direct bill capability for
*                            agent code 6
*
*            mar/84 (a.j.) - handle mumc technical billing
*
*            jan/85 (i.w.) - correct the constants mstr lock sms ii 35.2
*
*            jan/85 (m.s.) - change to use the new version of .slr
*                            of doctor master, and also change "ss-max-
*                            nbr-locs-in-doc-rec" to 30
*
*            feb/85 (i.w.) - add the required changes for the i-key.
*
*            apr 25 (i.w)  - added pricing changes...(sms 23.1.a)
*
*            oct/85 (c.a.) - correct looping when entering by chart
*
*            dec/85 (m.s.) - pdr 291
*                          - edit check on doctor location, should
*                            not allow keyers to enter a claim
*                            without a location code, see changes
*                            in subroutine zr0-verify-doc-for-loc
*
*            jan/86 (b.e.) - pdr 297
*                          - modifications to yf2 rtn to have the computer calculate
*                            the correct number of services based on services of codes
*                            for which add-on is an add-on.
*
*            mar/86 (m.s.) - pdr 301
*                          - if keyers enter at least one "*" on the
*                            location code from the batch control header
*                            screen , pgm will bring them back to the
*                            'old/new batch' option screen.
*
*            nov/86 (j.l.) - eft
*                          - bank code field change , and additional
*                            field for doc-sub-specialty in doctor mstr.
*
*            mar/87 (j.l.) - pdr 298
*                            put diagnosis code 100 to oma code s768a,
*                            s752a,s785a,s756a
*                          - pdr 313
*                            do not allow entry if doctor in dept "8",
*                            with clinic "22", "43".
*
*            may/87 (s.b.) - coversion from aos to aos/vs.
*                            change field size for
*                            status clause to 2 and
*                            feedback clause to 4.
*
*            sep/87 (m.s.) - an edit check of "*" on the first byte of
*                            ohip/chart id field - sms 98
*
*            nov/87 (j.l.) - sms 103
*                          - do not put diagnosis code 100 to oma code
*                            s768a,s752a,s785a,s756a
*                          - display message "NO VERIFICATION PLEASE"
*
*            dec/87 (j.l.) - pdr 356
*                          - after error message is displayed, hit
*                            space bar to return to keying field
*
*            jan/88 (l.w.) - pdr 360
*                          - display warning message if system-date
*                            greater than p.e.d.
*
*            nov/88 (m.s.) - sms 103
*                          - do not put diagnosis code 100 to oma code
*                            s768a,s752a,s785a,s756a
*                          - display message "NO VERIFICATION PLEASE"
*                            to the next blank description record, do
*                            not overwrite the existing messages.
*
*            nov/88 (m.s.) - sms 99
*                          - if the batctrl-amt-act is over 9999.99,
*                            display an warning message, do not bother
*                            to write the current claim hdr and dtls,
*                            and instead, end the batch with the prev.
*                            claim, user should re-enter the current
*                            claim with the new batch number.
*
*            nov/88 (m.s.) - sms 108
*                          - add the mod10 digit check for referring
*                            doctor no ends with '1' or '2'.  the check
*                            digit is provided from ministry of health.
*
*            feb/89 (s.f.) - sms 113
*                          - allow for agent 4 to be treated as a
*                            direct bill the same as agent 6
*
*            mar/89 (s.f.) - sms 115
*                          - make sure file status is pic xx ,feedback
*                            is pic x(4) and infos status is pic x(11).
*
*            aug/89 (m.c.) - pdr 426
*                            when user enters 'ic' on the claim, set the
*                            claim to be printed on the card
*
*            nov/89 (s.f.) - sms 126
*                          - allow for 8 claim details instead of 6.
*
*            oct/90 (b.e.) - sms 130
*                          - upload of ohip diskettes into f002
*                          - allow swap to m010 to add new patient
*                          - add new field "CLAIM-SOURCE" to allow
*                            user to indicate whether claim is being
*                            entered from a true source document or
*                            from a computer generated material.
*                            (other claims are being uploaded from
*                            diskette).
*
*            oct/90 (b.e.) - pdr #458
*                          - don't allow ohip # of 11111119 for any
*                            agent other than 'alternate funding'. this
*                            number is used for entering claims for
*                            babies without ohip #'s.
*
*            oct/90 (bml)  - sms 134 - set tape-submit-ind to "N" for
*                            alternative agents.
*
*            oct/90 (bml)  - pdr 458 - set stop statements in declarative
*                            for all files to loop until they notice error.
*
*            dec/90 (bml)  - pdr 466
*                          - set batctrladj-cd-sub-type to default to
*                            def-claim-source for existing batches.
*
*            feb/91 (mc)   - sms 138
*                          - no access to subscr mstr because subscr
*                            mstr merged into patient mstr
*                          - change clmhdr and clmdtl screen layout
*                            to allow health care nbr and diag cd
*                            respectively
*                          - replace 'ic' to 'mr' - manual review or
*                                            'op' - override price
*
*             apr/91 (db)  - pdr 489
*                          - hard code for clinic 22 & 66 to be
*                            accepted as part of the batch nbr.
*
*             apr/91 (mc)  - sms 138 (additional enhancement)
*                          - do not allow claims with agent '0', '2',
*                            '8' with province code = 'pq'
*                          - do not allow to enter claim if health
*                            nbr is expired
*                          - allow user to set the manual review ind
*                          - pdr 481
*                          - referring physician nbr cannot be the same
*                            as the physician ohip nbr of the claim
*                            that is being processed
*
*             jul/91 (mc)  - pdr 503
*                          - do not allow user to enter the claim for
*                          - services after june 30 if patient does not
*                            have health nbr.
*
*             aug/91 (bml) - made changes to above change so only
*                            certain agents and patients in ontario will
*                            meet above condition.
*
*             nov/91 (mc)  - pdr 535
*                          - allow the user to change batch control
*                            record for diskette claims only but no
*                            continuation to the existing batch

*             feb/92 (yb)  - pdr 549
*                          - remove message "look out !! premium code
*                          - is it an 'in' or 'er' patient?"
*                          - page 57 comment out line 38 to 42

*             mar/92 (yb)  - add new hospital number 1146 (e000)
*
*             jun/92 (mc)  - sms 139
*                          - verify clinic nbr of the claim with doctor
*                            mstr.
*                          - default the doc specialty code to the
*                            initial one, allow user to override
*                          - for clinic 60, default referring doctor
*                            nbr to the doctor ohip nbr being keyed,
*                            and also allow user to override
*             sep/92 (be)  - removed displays of claim-detail records
*                            during pricing calcuations.
*
*             feb/93 (mc)  - pdr 561
*                          - do not allow clinic 60 claim data entry
*                            because the clinic terminated on 92/06/30.
*
*             mar/93 (mc)  - pdr 565
*                          - hard code suffix 'b' for oma code 'j318'
*                            and 'j319'
*                          - make sure there are referring physician
*                            nbr for clinic 61 to 65
*
*             mar/93 (mc)  - sms 140
*                          - allow any new clinics between 22 to 99
*                            except 60
*
*             mar/93 (mc)  - pdr 569
*                          - show the version cd on the screen
*
*             apr/93 (mc)  - bypass the stale date check for clinic 80
*                            (ie service date < 6 months)
*
*             may/93 (mc)  - sms 141
*                          - reformat the screen layout of d001b
*                          - show more info about patient, and also
*                            user to modify some of the patient info
*
*             may/93 (mc)  - pdr 565
*                          - store the claim detail line no based on
*                            the sequence of entry by user
*
*             may/93 (mc)  - pdr 572
*                          - do not prompt for review indicator
*                          - when continue batch, show pat info for
*                            the last claim
*                          - move version and expiry date after
*                            the health nbr
*                          - allow user to enter city abbreviation
*                          - should only allow newline or '*' for
*                            last claim field
*                          - move hospital field after location code
*                          - if birth date is not match with yymm of
*                            chart nbr, display warning message
*
*             jun/93 (be)  - reset elig-flag flag so that only eligibility
*                            modified patients are written to f086 file.
*
*             jul/93 (mc)  - pdr 578
*                          - do the same confidentiality check as d003
*                          - pdr 577
*                          - allow user to enter estimated nbr of svc
*                            at claim level, show error if computed svc
*                            is not the same as entered svc
*
*             aug/93 (mc)  - pdr 576
*                          - allow user to change name
*
*             sep/93 (mc)  - pdr 588
*                          - set the batctrl-amt-est to the same as
*                            batctrl-amt-act,and set the batctrl-svc-est
*                            to the same as batctrl-svc-act, so user
*                            does not have to enter either value for
*                            balance batch
*                          - when 'm'odify claim, allow user to modify
*                            for claim header info only
*
*             jun/94 (mc)  - pdr 597
*                          - edit check on the 1st char of hosp equal
*                            to 1st char of location
*             mar/95 (yb)  - add new hospital "V"330
*
*             apr/95 (yb)  - change select for hc expired date
*
*             jun/95 (bml) - added the lookup of acronym in the health
*                            field to allow for dialysis lookup when
*                            acronym is entered.
*                          - also changed expiry date back to > to-date
*
*             aug/95 (mc)  - pdr 621 - if user enters 'mr' or 'op' for
*                                      non-agent 1 and non-agent 6,
*                                      stop to verify the entered price
*                                    - if error 39, reprompt for oma cd
*                                      field instead of the beginning of
*                                      the claim
*             nov/95 (yb)  - add new hospital "I"300
*
* 98/Jan/15 B.E.        - migration to MicroFocus cobol on dgux
*                       - changes flagged with "*mf"
*
* 98/Oct/30 B.E.        - system wouldn't accept MB patient id's (6 digit)
*                       - extensive change to edits on validating
*                         pat id's from non-ON provinces.
*
* 98/nov/09 B.E.        - if entry person accidentally entered no health
*                         care # or out of province id, the values defaulted
*                         to a specific patient in the patient mstr and they
*                         ended up with claims against them that were'nt theirs.
*                       - Error message 85 added and edits to ensure that a
*                         valid patient id is entered.
*
* 1999/Jun/15 S.B.      - Removed the periods from the final three statements
*                         of the ca0-acpt-hdr-data subroutine in order
*                         to keep them part of the subroutine.
*			- Added the call to the "d001_ca0.rtn" copybook.
*			- Added the call to the "d001_da1.rtn" copybook.
* 99/Jun/17 S.B.      - update pat-last-mod-by when updating patient record
* 99/Jun/18 S.B.	- Consolidate Sick Kids and RMA agents (def_agents.ws).
* 00/Mar/07 B.A.      - modify wa0_30 subroutine to call d001_wa0_30.rtn
*			- modify wa0_95 subroutine to call d001_wa0_95.rtn
*			- modify wa2 subroutine to call d001_wa3.rtn
*                       - modify ca0 subroutine to call d001_ca0.rtn
*			- modify va0 subroutine to call d001_va0.rtn
*			- modify da0 subroutine to call d001_da0.rtn
*			- modify zs0 subroutine to call d001_zs0.rtn
* 00/apr/23 B.E.      - the clmdtl "line numbers" where being dropped and
*			  several records where being written out as '0' line
*			  number. Increased size of hold-sort-oma-rec from
*			  166 to 168 so that when sorting records into group/
*			  section the entire length of record is maintained.
* 00/may/29 B.E.	- changes to confidentiality/manual review flag
*			  processing (ga1-..)
* 00/may/31 B.E.	- if user enters "NV" into any description rec
*			  pgm now immediately redisplay description rec
*			  with "NO VERFICATION PLEASE" showing.
* 00/jul/25 B.E.
*                      - reactivate the oma fee code 'effective date' so
*                        that current/previous  prices are based up effective
*                        date of each code and not sharing a common
*                        effective date in the constants master.
* 00/jul/27 B.E.       - in ya0- pricing module, removed hard coding of '7' 
*			 and replace with calculation using
*		 	 'ss-max-nbr-oma-det-rec-allow'.
* 00/aug/03 B.E.       - pricing modified to take into consideration that
*			 oma fees now 9(4).999 rather than 9(5).99
* 00/aug/04 B.E.       - corrected bug whereby and OP'd E0xx code line was
*			 being recalculated
* 00/aug/08 B.E.  - basic fee calculations are now tested again min/max
*		    specified in f040 rec. If fee calculated is < min
*		    then fee is bumped up to miniumn value. If fee is > max
*		    then it is reduced to max value.
* 00/aug/08 B.E.  - changed code to use the "P"ercentage/"F"lat designation
*		    field to determine if code is an 'add on' code rather
*		    than having only ICC codes of SP98 and SP99 as add ons
* 00/sep/15 B.E.  - added requirement to enter "!"  for error #59

* 00/sep/05 B.E.  - ADDING FEE-GLOBAL-ADDON-CD-EXCLUSION-FLAG which is used
*		    to DISABLE automatic application of "global" add on codes
*		    E400/E1401/E409/E410
* 00/sep/25 B.E.  - changed this pgm's code or copybooks that this pgm calls to:
*		    1) translate 'short forms' entered into description recs
*		    2) change tech calculations based upon ICC SEC instead
*		       of just using "B" suffix
*		    3) removed entry of hospital field and any error/warning
*		       messages since hospital can be calulated using
*		       location code
*		    4) displays after each step of pricing
* 00/oct/16 B.E.  - added new variable 'flag-retain-prices' and set it to "N"
*		    before calling ya0- pricing logic so that the pricing
*		    will not retain "incoming" prices as per diskette upload
*		    program and will use the rma calculated prices
* 00/dev/06 B.E. - corrected check digit verification of referring physician nbr
* 01/feb/06 B.E. - change to pricing routine to price loc G420 / oma code
*		   G259 at 85%
* 01/mar/27 B.E. - tech/prof rules of DU/PF icc codes changed to
*                  substitute "B" or "C" suffix for "A" if tech/prof
*                  only pricing, or to split into two separate lines
*                  if tech and prof fees involved.
* 01/mar/30 B.E. - mod's to reconcile with common code for above change
*		   done on mar 27 to take into consideration code shared
*		   with newu701.cbl 
* 01/apr/12 B.E. - when a user types in a suffix on one line it is used to
*		   default the suffix on the next line. However due to ohip
*		   rules and computer logic, sometimes the computer changes
*		   the suffix or splits the line and creates a new line with
*		   a suffix different from what the user has typed in. In order
*		   to default the next user enterable line with a suffix that
*		   they typed in, the typed in suffix is saved in hold value
*		   and used to preset new line (SEE CHANGE BELOW)
* 01/apr/16 B.E. - unique site code added - RMA always default suffix to "A"
*		   and HSC default to last suffix typed in by user
* 01/apr/23 B.E. - 'fee' amount for PERCENTAGE addon's now divided by 100 as
*                  read in from f040 into hold variables that allow a 
*                  4 decimal percentage
* 01/apr/26 B.E. - fixed mispricing of "F"lat based addon's.
* 01/apr/27 MC/AB - preset i/o indicator in f001 & f002 from f030-location-mstr
*		    and make it as display field only 
* 01/may/03 B.E. - adjusted screen to display correct hospital nbr
* 01/may/04 B.E. - RMA edit forcing entry of pat-id or OHIP number made active
*		   for all sites
* 01/may/06 B.E. - fixed bug with site-id and statedated claims so that edit
*		   active at RMA again
* 01/aug/15 yas. - added "PR" and "NO" to desc_text_translation.rtn          
* 01/aug/29 B.E. - removed error/beep in pricing routine when 
*                   reducing/increasing a claim detail's value due
*                   to minimum/maximum fee restriction in f040
*                 - don't give a 'zero fee value' warning message unless
*                   ONLY the OHIP fee is zero
*                 - generate a description record automatically if the 
*                   the special reduction rate is applied for 
*                   G430/G259  (location/OMA code) combination occurs
*                 - adjust claim 'audit' values when pricing adds 'basic'
*                   units from the F040 file
* 01/sep/25 B.E. - changed logic of how ADJUDICATION description was being
*                  created so that clmhdr manual-review-flag would be
*                  set automatically
* 01/nov/06 B.E. - recompiled to pickup the new contents of 'def_agents.ws'
*		   which uses agent 3 as direct bills for ICU (revenue
*		   clinic 85)
*		 - display new clmhdr-payroll value
* 02/feb/06 B.E. - added edit if doctor might be paid under ICU payroll (B)
*		   and claims being entered into 'A" payroll 
* 02/feb/11 B.E. - added warning if doctor terminated
* 02/mar/22 B.E. - made ICU payroll edits (01/nov/06) errors requiring "!" to
*		   move onwards so that keyer's don't casually ignore error
* 02/apr/08 M.C. - add prefix (!) for ohip or bill direct and ($) for chart
*		   when accepting scr-clmhdr-ohip-chart for RMA only
* 02/apr/22 M.C. - add prefix (!) for ohip or bill direct and ($) for chart
*		   nbr most of the time 
* 02/jun/17 M.C. - add the logic to determine what hospital chart nbr entered
*		   when user enters claims by chart nbr, access by the correct
*		   chart nbr index since now there is a separate field/index 
*		   for each hospital chart nbr
*		- add subroutine da61-read-chrt-pat-mstr,modify da0 subroutine
*		- drop country  field
* 02/jul/16 M.C. - modify to assign the proper next batch nbr for the correct
*		   clinic nbr  
* 03/nov/05 b.e. - alpha doc nbr
* 03/nov/19 M.C. - save the earliest service date from the detail into clmhdr-serv-date
* 04/feb/19 M.C. - when user change patient's eligibility info, make sure do the same
*		   as d003, u011, newu703 and m010 by calling yy0 subroutine.
*		 - add file f011-pat-mstr-eligibility
* 04/feb/25 M.C. - include pat-chart-nbr-2 to 5 in f086-pat-id for eligibility changes
* 04/feb/26 M.C. - display ws-hosp-nbr from location-mstr based on the criteria
* 04/mar/03 M.C. - temporary comment out the edit check on doc dept 15 with payroll 'B'
* 04/mar/04 M.C. - reinstate comment out the edit check on doc dept 15 with payroll 'B'
*                  and add additional check with doc-afp-paym-group
* 04/apr/07 M.C. - error if admit date less than birth date
* 04/may/19 M.C. - check w-iconst-clinic-card-colour with 'Y' only
* 04/jun/09 M.C. - provide error if clinic is AFP and icc code = pf or du or nm and suffix = A or B
*	           or technical = 'Y'
* 04/jul/08 M.C. - comment out the error(106) when data entry against the doctor belongs to payroll B
* 04/jul/13 M.C. - comment out the error(105) when data entry against the doctor belongs to payroll B
* 05/aug/16 M.C. - change description from'REFER TO ADJUDICATION' to 'G259A BILLED AT 85%'
* 05/nov/01 B.E. - If oma code = 'E420', then error - check pricing               
*		   if doc nbr = '049' and oma cd = 'Z425', then error - take out manual review
*		   if oma code is A073 or A074..etc (45 codes altogether) and diag code is 042 or 043..etc
*		   (26 altogether) and E078 is not on the same claim , error - check for E078 premium
*		   if oma code is A073 or A074..etc (45 codes altogether) and diag code is NOT 042 or 043..etc
*		   (26 altogether) and E078 is on the same claim , error - check for E078 premium
* 05/dec/14 M.C. - add oma code 'A340', 'A341', 'A343' & 'A348' to the list above  done on 05/nov/01       
* 05/dec/15 M.C. - do not allow agent 3, 5, 7 or 8 to be entered at batctrl header for RMA only
* 06/jan/18 M.C. - Yas requested to change error 111 to "E078 may be allowable, please check"
* 06/may/16 b.e. - undo apr/93 edit so that clinic 80 now checked for stale
*		   dated claims upon entry
* 06/jul/04 M.C. - only allow agent 6 for clinic 98 for  RMA.
* 06/sep/18 M.C. - provide error if clinic 61 to 65 with In patient and location cd M500
*		   but no admit date, this is for RMA only
* 06/sep/20 b.e. - added sequential file in user's home directory to keep
*		   track of batch using is working on. When this program is
*		   is started the file is read to see if a batch was active
*		   and not completed. This happens if the network goes down
*		   and the user is 'red balled'. If a batch is found in the
*		   file then the 'f001 fix' procedure is run on it to 
*		   "recover" the batch. 
* 06/sep/21 b.e. - for HSC only removed the need to enter batctrl-payroll
* 06/sep/26 M.C. - HSC requested to provide error if they enter RMB (agent  8)
*                  claims with Ontario patients
* 06/sep/27 M.C. - when red balled, prompt for payroll if batch record does not exist
* 07/mar/15 M.C. - if first claim exists in the file, delete d001-batch-in-progress file
*		   by open/close d001-batch-in-progress file
* 07/jul/18 M.C. - provide error if clinic 71 to 75 with In patient and location cd M500
*		   but no admit date, this is for RMA only - same as clinics 60's
* 07/aug/02 M.C. - HSC requested to provide error if they enter claims with agent 1
*                  (alternate fund) and prov cd not = 'ON'
* 08/jan/21 b.e. - added 5 new diag codes to "potentially missing E078 addon"
*		   edit as per shelley's request	
* 08/jan/31 b.e. - don't allow paediatric specialty (26) to bill A007 if 
*		   service date is > 2007/12/31 
* 08/apr/03 b.e. - add A261/A262 to list of codes to include in message
*		   about possible E078 add on
* 08/apr/04 b.e. - after talking jane/shelley removed A261 from above change
* 08/apr/30 M.C. - apply the same edits( 16 + desc) as newu701.cbl
* 08/jun/03 M.C. - provide error for location M549 & M558 with In patient has no admit date
*		   same as M500, this is for RMA only
* 08/dec/18 M.C. - empty d001-batch-in-progress file after the recovery of the batch in zi0 subroutine 
* 09/jan/22 MC1  - modify to ER with oma code starts with eith 'D' or F' for clinic 88 price at 75% for RMA only
* 09/may/04 MC2  - add 6 new edits and modify one existing edit for E021C in la5-oma-code-edit
*		 - modify to include in $use/d001_newu701_oma_code_edit.rtn, $use/pricing_logic.rtn
* 09/may/27 MC3  - modify the edit with exception of C101 when oma code is C990 to C997
*	           in  $use/d001_newu701_oma_code_edit.rtn
* 09/Jun/01 MC4  - RMA request to remove the edit check on C990 to C997 with other CXXX
* 10/feb/10 brad1 - redesign screen and change logic so that 10 details can be entered instead of 8
* 10/mar/30 MC5  - include clinic 66 as part of clinic 60's edit check - referring physician nbr
*		   related to err 24, 54, 114, change description for err 64
* 10/apr/13 MC6  - define 18 oma code for additional check , same as newu701.cbl
*                - add edits in la5-oma-code-edit, add error message 141 to 154

* 10/jun/16 MC8  - for agent 1, if user enters 'M' for suffix, it should stay as 'M' for the next line;
*		   otherwise, change back to 'A' for others
* 10/jun/21 MC9  - add code to process new logically-deleted-flag field of f085 - rejected claims file ..
*                  if change is made to patient's eligibility information then
*                  update existing f085 record to put 'Y' into logically deleted field
*                - modify process_pat_eligibility_change.rtn to update f085 file & add open/close f085
* 10/jul/05 MC10 - modify $use/d001_d003_confidentiality_check.rtn to allow 10 details
*		 - do not set clmhdr-manual-review to 'Y' if description 1 entered  = 1, 2, 3, 4 or 5
*		   with dept = 41, 42, 43 or 75
* 10/jul/12 MC11 - undo the changes related to manual review on 10/Jul/05; instead, allow entry on
*		   clmhdr-payroll and force entry to enter value 1 to 5 if dept = 41, 42, 43 or 75 
* 10/aug/17 MC12 - allow entry value 0 as well in clmhdr-payroll if dept = 41, 42, 43 or 75 
* 10/sep/21 MC13 - for error 147 - include the check for agent 9 
* 10/sep/23 MC14 - for error 139 - include the check for same service date
* 10/Oct/04 MC15 - Linda OHara requested to disable the edit check if
*		   AxxxA is billed plus GxxxA plus one of the follwing :U991, U993, U995, U997, K991,
*		   K993, K995 & K997. IF condition is true, claim is flagged or manual review with description
*		   'Pay visit premium based on AxxxA code'
* 10/dec/08 MC16 - modify for error 147 to check H1xx or H055 or H065
* 11/jan/26 MC17 - change the stale date to be 6 months plus 20 days per Yasemin
* 11/Apr/11 MC18 - modify edits for error 119, 130, 131, 135, 143, 147, 153, 111, 138 and add new edits for error 158 to 170
*		   do the same as newu701
*                - add edits in la5-oma-code-edit, add error message 158, 162, 165, 166, 167, 168, 169
*                - add edits in wa0-acpt-clmhdr-detail, add error message 159, 160, 161, 163, 164, 170
* 11/May/02 MC19 - modify edit for error 168 in pricing_variables_hold.ws & d001_newu701_oma_code_edit.rtn 
* 11/May/19 MC20 - modify edits for error 130 & 153  & remove the edit for error 161
*		 - remove third condition of edit 36 (error 111), modify edit for error 163 & 164
*		 - no actual changes for error 153 after investigation
*                - transfer all oma codes variables to copybook "d001_newu701_oma_code_variables.ws".
*                - transfer all oma codes variables reset to copybook "d001_newu701_oma_code_variables_reset.rtn".
*                - add the new subroutine ab0a-oma-code-reset to call "d001_newu701_oma_code_variables_reset.rtn"
*                  in ab0-processing.  
*                - include f201*slr/fd , open & close file to check against SLI OMA CODE SUFF
* 		 - add error 171 & 172 for sli edit check
* 11/Aug/22 MC21 - change error 134 from 'A007 only allowed for specialty 00' to 'A007 not allowed for the specialty 26'
*		 - disable the edit check on error 118 which is similar to error 134   
* 11/nov/22 be2  - fix pricing with respect to min-fee pricing of OMA amount 
* 11/Nov/23 MC22 - modify edit 1, 5, 12, 13, 21, 29, 32, 34, 40, 45, 49, 50 plus add new edits 52 to 63 for error 173 to 175
*                - add edits 53 to 63 in la5-oma-code-edit, add error message 174 & 175 (edit 54 to 63) 
*                - add edit  52 in wa0-acpt-clmhdr-detail, add error message 173 
* 11/Dec/05      - add edit 64 for error messsage 176, add edit 65 for using same error message 155
* 12/Apr/16 MC23 - for error 163 & 164, change to comment two lines.  
*		 - Yasemin requests to user to enter '!' when error  occurs
* 12/May/17 MC24 - modify edit for error 119 to remove E022C check temporary
* 12/Jul/12 MC25 - modify $use/pricing_logic.rtn to process yio before yf0 subroutine for pricing correctly
* 12/Oct/22 MC26 - since pricing for E676B is now correct, user requested to remove the error 176(edit 64) -'Check Fee for E676B'
*                  in  $use/d001_newu701_oma_code_edit.rtn & la5-oma-code-edit subroutine
* 13/Jan/29 MC27 - use verify_agent_code.rtn to edit the allowable agent, to be consistent with newu701
*		 - include flag-agent-cd and modify $use/def_agents.ws not to allow agent 3 to be with agent 4 & 6
* 13/Apr/10 MC28 - modify edit 1, 5, 12, 17, 18 plus add new edits 66 to 69 for error 177 to 180
*                - add edits 67 & 68 in la5-oma-code-edit, add error message 178 & 179 
*                - add edits 66 & 69 in wa0-acpt-clmhdr-detail, add error message 177 & 180
*                - modify  in  $use/d001_newu701_oma_code_edit.rtn & la5-oma-code-edit subroutine
*		 - modify  in  $use/d001_newu701_oma_code_variables.ws, $use/d001_newu701_oma_code_variables_reset.rtn 
* 13/Jun/17 MC29 - set referring doctor nbr to be the same as billing doctor nbr if referring doctor nbr = 0 if
*		   oma code = 'GnnnA' with fee-phy-ind = 'Y' (referring physician nbr is required)
* 13/Jun/20 MC30 - remove/comment out edit 69 which is same as edit 39 which was done on 2011/May/18
* 13/Jul/09 MC31 - Brad requested to add en edit check to make sure the service date > doctor start date
*		 - do not allow entry if doctor start date > system run date at the batch level
*		 - Linda O requested to allow 7 mth for svc date billing instead of 6 mth+ 20 days before staled date
* 13/Jul/30      - UNDO MC31 -  to add an edit check to make sure the service date > doctor start date
* 13/Jul/31 MC32 - comment out the edit check for error 67 REFERRING DOC # CAN'T THE SAME AS DOC # OF THE CLAIM
* 13/Sep/05 MC33 - include suffix 'M' when checking Gnnn for referring doctor nbr - see MC29 
* 13/Oct/15 MC34 - include the check of oma code 'J'nnn and 'X'nnn with 'G'nnn for 0 referring doctor (see MC29/MC33).
*		   Linda O'Hara said no need to check on suffix as J & X codes allow suffix, A,B,C,M.  
* 13/Dec/05 MC35 - if none of oma code detail requires referring doctor(ref-phy-ind in f040 = 'N') within the claim but
*		   keyer has entered referring doctor, then blank it out to reduce reject from MOH
* 14/Feb/25 MC36 - remove Z316 from the edits With the message "Maximum number of services exceeded"
* 14/Mar/26 MC37 - As per Brad's request, add the edit check of description fields to disallow '~'
* 14/Jun/05 MC38 - remove the edit check for err-ind = 144, modify $use/d001_newu701_oma_code_edit.rtn to comment out ws-hnnn
* 15/Apr/09 MC39 - modify the edit 36 for error 111 to remove edit check on 16 oma codes    
* 15/Jul/27 MC40 - modify the edit 12 for error 130 to include G371 in the edit check       
* 16/May/03 MC41 - Yasemin requested to allow <=231 days for svc date billing before staled date
* 16/Jun/15 MC42 - for existing batch, set last claim's doc-spec-cd to ws-doc-spec-cd instead of doc-spec-cd
* 16/Jul/19 MC43 - remove error check for Z441C and error only applies to Z441A   	
* 16/Aug/30 MC44 - upshift pat-version-cd

environment division.
input-output section.
file-control.
*
*   place your file select statements here
*
    copy "f001_batch_control_file.slr".
*
    copy "f002_claims_mstr.slr".
*
    copy "f010_new_patient_mstr.slr".
*
*mf    copy "f010_new_patient_mstr_hc.slr".
*
*mf    copy "f010_new_patient_mstr_od.slr".
*
*mf    copy "f010_new_patient_mstr_chrt.slr".
*
*mf    copy "f010_new_patient_mstr_acr.slr".
*
    copy "f020_doctor_mstr.slr".

    copy "f030_locations_mstr.slr".

    copy "f040_oma_fee_mstr.slr".
*
*  copy "F086_PAT_ID.SLR".
select corrected-pat
        assign        to "$HOME/f086_pat_id.d001"
        file status   is status-corrected-pat.

* 2004/02/19 - MC
    copy "f011_pat_mstr_elig_history.slr".
* 2004/02/19 - end

*
    copy "f090_constants_mstr.slr".
*
    copy "f091_diagnostic_codes.slr".
*
    copy "f094_msg_sub_mstr.slr".

* 2011/05/19 - MC20
copy "f201_sli_oma_code_suff.slr".
* 2011/05/19 - end

* 2006/sep/20 b.e.
select d001-batch-in-progress
        assign        to "$HOME/batch_in_progress.d001"
        organization is sequential   
        access mode  is sequential   
        status       is status-cobol-batch-in-progress.

* 2010/06/21 - MC9
    copy "f085_rejected_claims.slr".
* 2010/06/21 - end

data division.
file section.
*
    copy "f001_batch_control_file.fd".
    copy "f002_d001_claims_mstr.fd".
    copy "f010_patient_mstr.fd".
*mf    copy "f010_patient_mstr_hc.fd".
*mf    copy "f010_patient_mstr_od.fd".
*mf    copy "f010_patient_mstr_chrt.fd".
*mf    copy "f010_patient_mstr_acr.fd".
    copy "f020_doctor_mstr.fd".
    copy "f030_locations_mstr.fd".
    copy "f040_oma_fee_mstr.fd".
    copy "f090_constants_mstr.fd".
    copy "f090_const_mstr_rec_2.ws".
    copy "f091_diagnostic_codes.fd".
*
    copy "f086_pat_id.fd".

* 2004/02/19 - MC 
    copy "f011_pat_mstr_elig_history.fd".
* 2004/02/19 - end
*
* 2010/06/21 - MC9
    copy "f085_rejected_claims.fd".          
* 2010/06/21 - end
*
    copy "f094_msg_sub_mstr.fd".
*
* 2011/05/19 - MC20
copy "f201_sli_oma_code_suff.fd".
* 2011/05/19 - end


* 2006/sep/20 b.e.
fd  d001-batch-in-progress
        block contains  47 characters 
        record contains 47 characters .
*        feedback is feedback-batch-in-progress.

01  d001-batch-in-progress-rec.
    05  d001-recovery-command-line.
	10  d001-command-part-1			pic x(12).
	10  d001-space-1			pic x(1).
	10  d001-batch-nbr.  
            15  d001-bat-clinic-nbr-1-2         pic 99.     
            15  d001-bat-doc-nbr                pic x(3).   
            15  d001-bat-week-day		pic x(3).
            15  d001-bat-week-day-r redefines d001-bat-week-day  
                                                pic 999.  
	10  d001-space-2			pic x(1).
	10  d001-loc				pic x(4).
	10  d001-space-3 			pic x(1).
	10  d001-agent-cd 			pic x(1).
	10  d001-space-4			pic x(1).
	10  d001-i-o-pat-ind			pic x(1).
	10  d001-space-5			pic x(1).
	10  d001-payroll	   		pic x(1).
	10  d001-space-6			pic x(1).
	10  d001-f001-exists-ind		pic x(1).
	10  d001-space-7			pic x(1).
	10  d001-command-part-2			pic x(14).

working-storage section.
copy "site_variables.ws".

77 logon-id                                     pic x(5)  value 'D001'.
*       (change this value clause to alter rma's batch control data
*        modification passord)
*77  password                                    pic x(3)  value "RMA".
*77  password-special-privledges                 pic x(3)  value "GCS".

77  password-input                              pic x(3).
77  ws-claim-source                             pic x(01) value spaces.
77  ws-tot-serv                                 pic 999.
77  err-ind                                     pic 999.
77  c-1                                         pic 99.
*   ('curr'ent and 'prev'ious used in selecting the appropriate oma year's fees --
*    'oma' and 'ohip' to select the appropriate fee type)
77  curr                                        pic 9   comp    value 1.
77  prev                                        pic 9   comp    value 2.
77  oma                                         pic 9   comp    value 1.
77  ohip                                        pic 9   comp    value 2.
77  pline                                       pic 99.
77  temp                                        pic 9(9).
*brad1 - allow 2 digit nbrs
*77  ss-curr-prev                                pic 9   comp.
77  ss-curr-prev                                pic 99  comp.

77  temp-ss                                     pic 9(5) comp.

77  reply                                       pic x.
77  continue-reply                              pic x.
77  change-reply                                pic x.
77  flag-zero-fee                               pic x.
77  flag-z-highest-grp                          pic x.
77  flag-accept                                 pic x.
77  flag-sp-sec-exists                          pic x.
77  flag-new-sec                                pic x.
77  flag-diag-code-required                     pic x.
77  flag-special-diag-code-req                  pic x   value "N".
77  first-diag-cd                               pic x   value "Y".
77  flag-no-verif                               pic x   value "N".


77  ws-disp-pat-key-type                        pic x(7).
77  ws-disp-pat-err-msg                         pic x(42).
77  ws-batctrl-amt-diff                         pic 9(5)v99.
77  ws-nbr-clmdtl-recs                          pic 99.
77  ws-batctrl-svc-diff                         pic 9(5)v99.
77  ws-file-err-msg                             pic x(42)  value spaces.
77  ws-highest-grp-tot                          pic s9(5)v99.
77  ws-highest-grp-nbr                          pic 99 value zero.
77  ws-hold-wcb-rate                            pic 999v9(5) value zero.
77  ws-i-o-pat-ind                              pic x.
77  ws-scr-health-nbr                           pic x(10).
77  ws-hold-acronym                             pic x(9).
77  ws-oma-suff                                 pic a.
77  ws-last-typed-in-suffix		 	pic x.
77  ws-pricing-nbr-serv                         pic 999.
77  ws-reduc-rate98                             pic 99v99.
77  ws-reduc-rate99                             pic 99v99.
77  ws-reduc-rate                               pic 99v99.
77  ws-search-clinic-nbr-1-2                    pic 99  comp.
77  ws-special-add-on-cd-entered                pic x.
77  ws-tot-claim-nbr-sv                         pic 999.
77  ws-hold-screen-dept                         pic 99.
77  ws-hold-temp-1                              pic s9(7)v99.
77  ws-hold-temp-2                              pic 99.
77  ws-hold-temp-3                              pic s9(9).
77  confirm-space                               pic x   value space.


*
*  subscripts
*
77  rate-found-ss                               pic 99  comp.
77  ss                                          pic 99  comp.
77  ss1                                         pic 99  comp.
77  ss2                                         pic 99  comp.
77  ss-basic-times                              pic 99  comp value zero.
77  ss-basic-times-desc-rec                     pic 99  comp value zero.
* brad1 - allow 2 digit numbers
*77  ss-from-plus-one                            pic  9  comp.
77  ss-from-plus-one                            pic 99  comp.

77  ss-const                                    pic 99  comp.
77  subs-table-addr                             pic 99  comp.
77  i                                           pic 99  comp.

* brad1 - allow 2 digit numbers
*77  ss-from                                     pic  9  comp.
*77  ss-to                                       pic  9  comp.
77  ss-from                                     pic 99  comp.
77  ss-to                                       pic 99  comp.

77  ss-sec                                      pic 99  comp.
77  ss-grp                                      pic 99  comp.
77  ss-grp-tot                                  pic 99  comp.
77  ss-clmhdr                                   pic 99  comp.
77  ss-clmdtl-oma                               pic 99  comp.
77  ss-clmdtl-next-avail-dtl 			pic 99  comp.
77  ss-clmdtl-new-dtl	 			pic 99  comp.
77  ss-hold-clmdtl-oma                          pic 99  comp.
77  ss-clmdtl-desc                              pic 99  comp.
77  ss-conseq-dd                                pic 99  comp.
77  ss-det-nbr                                  pic 99  comp.
77  ss-ind                                      pic 99  comp.
77  ss-plus-one                                 pic 99  comp.
77  ss-x                                        pic 99  comp.
77  ss-suffix                                   pic 99  comp.
77  ss-desc                                     pic 9   comp.
77  subs                                        pic 99  comp.
*

* 2011/05/19 - MC20
copy "d001_newu701_oma_code_variables.ws".


*       (subscripts for hold-oma-records table)
*       (moved to pricing hold.ws copybook)
*
*  feedback values for all indexed files
*
77  feedback-batctrl-file                       pic x(4).
77  feedback-claims-mstr                        pic x(4).
77  feedback-doc-mstr                           pic x(4).
77  feedback-pat-mstr                           pic x(4).
77  feedback-pat-mstr-hc                        pic x(4).
77  feedback-pat-mstr-od                        pic x(4).
77  feedback-pat-mstr-chrt                      pic x(4).
77  feedback-pat-mstr-acr                       pic x(4).
77  feedback-oma-fee-mstr                       pic x(4).
77  feedback-iconst-mstr                        pic x(4).
*
*  eof flags
*
77  eof-filename-here                           pic x   value "N".
*
*   file status indicators --   'status-etc.'       for infos status return code
*                               'status-cobol-etc.' for cobol status return code
*
77  status-common                               pic x(11).
77  status-batctrl-file                         pic x(11)       value zero.
77  status-cobol-batctrl-file                   pic xx          value zero.
77  status-claims-mstr                          pic x(11)       value zero.
77  status-cobol-claims-mstr                    pic  xx         value zero.
* MC9
77  status-cobol-rejected-claims 		pic  xx         value zero.

77  status-pat-mstr                             pic x(11)       value zero.
77  status-cobol-batch-in-progress              pic  xx         value zero.
*7  status-cobol-pat-mstr                       pic  xx         value zero.
77  status-cobol-loc-mstr                       pic x(2)        value zero.

77  ws-d001-command-part-1			pic x(12) value "$cmd/utl0025".
77  ws-d001-command-part-2			pic x(14) value " ".

01 mf-cobol-status-codes.
    05  status-cobol-pat-mstr.
        10  status-cobol-pat-mstr1              pic x   value "0".
        10  status-cobol-pat-mstr2              pic x   value "0".
    05  status-cobol-pat-mstr-binary
                redefines status-cobol-pat-mstr pic 9(4) comp.

    05  status-cobol-display.
        10 status-cobol-display1                pic x.
        10 filler                               pic x(3).
        10 status-cobol-display2                pic 9(4).

77  status-pat-mstr-hc                          pic x(11)       value zero.
77  status-pat-mstr-od                          pic x(11)       value zero.
77  status-pat-mstr-chrt                        pic x(11)       value zero.
77  status-pat-mstr-acr                         pic x(11)       value zero.
77  status-cobol-pat-mstr-hc                    pic xx          value zero.
77  status-cobol-pat-mstr-od                    pic xx          value zero.
77  status-cobol-pat-mstr-chrt                  pic xx          value zero.
77  status-cobol-pat-mstr-acr                   pic xx          value zero.
77  status-corrected-pat                        pic xx          value zero.
* 2004/02/19 - MC
77  status-cobol-pat-elig-history		pic xx		value zero.
* 2004/02/19 - end
77  status-doc-mstr                             pic x(11)       value zero.
77  status-cobol-doc-mstr                       pic  xx         value zero.
77  status-oma-mstr                             pic x(11)       value zero.
77  status-cobol-oma-mstr                       pic  xx         value zero.
77  status-iconst-mstr                          pic x(11)       value zero.
77  status-cobol-iconst-mstr                    pic  xx         value zero.
77  status-diag-mstr                            pic x(11)       value zero.
77  status-cobol-diag-mstr                      pic  xx         value zero.
* 2011/05/19 - MC20
	77  status-cobol-sli-oma-mstr               	pic x(02)  	value zero.
* 2011/05/19 - end

copy "mth_desc_max_days.ws".

copy "sysdatetime.ws".

copy "check_digit.ws".

copy "check_digit_10.ws".

copy "def_agents.ws".

copy "linkage.ws".

copy "def_claim_source.ws".

copy "m010_table.ws".

01  ws-loc.
    05  ws-loc-1                                pic x.
    05  ws-loc-2                                pic x(3).
* 2010/05/27 - MC6
01  ws-birth-date                               pic 9(8).
01  ws-sv-date                                  pic 9(8).
01  date-difference-in-days                     pic 9(3).
* 2010/05/27 - end

* 2010/09/23 - MC14
01  ws-sv-date-c1                               pic 9(8).
01  ws-sv-date-c2                               pic 9(8).
* 2010/09/23 - end

01  ws-oma-cd.
    05  ws-oma-cd-1                             pic x.
    05  ws-oma-cd-2-4                           pic 999.

01  ws-date.
*y2k
*   05  ws-yy                                   pic 99.
    05  ws-yy                                   pic 9(4).
    05  ws-mm                                   pic 99.
    05  ws-dd                                   pic 99.

01  temp-yyyy.
    05  filler					pic 99.
    05  temp-yy					pic 99.
01  expiry-test-to-date.
*y2k -not changed - used to verify against expiry date which is only 2 digit yy
    05  expiry-test-to-date-yy			pic 99.
    05  expiry-test-to-date-mm                  pic 99.
01  hc-expiry-date.
*y2k
*y2k -not changed - used to verify against expiry date which is only 2 digit yy
    05  hc-expiry-date-yy                       pic 99.
    05  hc-expiry-date-mm                       pic 99.

*
*  *== keys *== for indexed files
*

01  key-oma-fee-mstr.
    05  key-oma-cd                              pic x(4).


*mf copy "f001_key_batctrl_file.ws".

*mf copy "f002_key_claims_mstr.ws".

copy "f002_claims_hdr_rec.ws".

copy "f010_patient_mstr.ws".

01  ws-batctrl-amt-act                          pic s9(6)v99.

01 flg-omacd-possible-addon-found	pic x.
01 flg-diag-possible-addon-found	pic x.
01 flg-addon-possible-addon-found	pic x.

01  claims-occur                                pic 9(16).

    copy "f094_msg_sub_mstr.fw".

01  flag-msg-sub                                pic x.
    88  msg-sub-missing                         value "N".
    88  msg-sub-exists                          value "Y".

01 flag-loc-code				pic x.
    88 loc-found				value "Y".
    88 loc-not-found				value "N".

01  option                                      pic x.
    88  new-batch                               value "1".
    88  old-batch                               value "2".
    88  stop-option                             value "*".

01  ic-flag                                     pic x  value "N".
    88  ic-entered                              value "Y".
    88  ic-not-entered                          value "N".

01  flag                                        pic x.
    88 ok                                       value "Y".
    88 not-ok                                   value "N".

01  flag-lock                                   pic x.
    88 rec-locked                               value "Y".
    88 rec-not-locked                           value "N".

*2002/04/08 - MC
01  ws-ohip-chart-flag				pic x.
*2002/04/08 - end

01  flag-ohip-vs-chart                          pic x.
    88  qhip                                    value "O".
    88  chart                                   value "C".
    88  direct                                  value "D".

01  flag-valid-ohip-or-chart                    pic x.
    88  valid-ohip                              value "Y".
    88  valid-chart                             value "Y".
    88  invalid-ohip                            value "N".
    88  invalid-chart                           value "N".

01  flag-ohip-mmyy                              pic x.
    88  valid-mmyy                              value "Y".
    88  invalid-mmyy                            value "N".

01  flag-err-data                               pic x.
    88  err-data                                value "N".
    88  ok-data                                 value "Y".

01  flag-done-clmdtl-recs                       pic x.
    88  done-clmdtl-recs-yes                    value "Y".

01  flag-eoj                                    pic x.
    88  eoj-create-new-patient                  value "C".
    88  eoj                                     value "E".

01  flag-sec-reduction-needed                   pic x.

01  flag-tech-prof-suffix-rule                  pic x.
    88  tech-prof-suff-rule-applied             value "Y".

01  flag-desc-report-required                 	pic x.
    88 report-desc-required                     value "Y".
01  flag-adjudication-required			pic x.
    88 adjudication-desc-required               value "Y".

01  flag-confidential-desc-rec			pic x.
    88 confidential-desc-not-found		value "N".
    88 confidential-desc-found			value "Y".

*2013/01/29 - MC
01  flag-agent-cd                               pic x.
    88 valid-agent-cd                           value "Y".
    88 invalid-agent-cd                         value "N".
*2013/01/29 - end

* 2013/06/17 - MC29
01  flag-refer-doc-needed-G-codes               pic x.
* 2013/06/17 - end

* 2013/12/05 - MC35
01  flag-refer-doc                              pic x.
    88 refer-doc-require                          value "Y".
    88 refer-doc-not-require                      value "N".
* 2013/12/05 - end

01  reply-create-pat                            pic x.
    88  new-patient                             value "R".
    88  err-patient                             value "T".
    88  request-pgm-m010                        value "A".

01  macro-line.
    02 macro                                    pic x(50) value space.
    02 macro-null-char                          pic x(1) value x"00".

* MC37
01  test-field.
    05  ws-test-field                           pic x(22).
    05  ws-test-field-r redefines ws-test-field.
        10 test-field-occ occurs 22 times       pic x(1).

77  ss-max-field-check				pic 99 value 22.
* MC37 -end


*   counters for records read/written for all input/output files

01  counters.
    05  ctr-read-batctrl-mstr                   pic 9(7).
    05  ctr-read-claims-mstr                    pic 9(7).
    05  ctr-read-pat-mstr                       pic 9(7).
    05  ctr-read-doc-mstr                       pic 9(7).
    05  ctr-read-loc-mstr                       pic 9(7).
    05  ctr-read-oma-mstr                       pic 9(7).
    05  ctr-read-const-mstr                     pic 9(7).

    05  ctr-writ-batctrl-file                   pic 9(7).
    05  ctr-writ-claims-mstr                    pic 9(7).
    05  ctr-write-corrected-pat                 pic 9(7).
* 2004/02/19 - MC   
    05  ctr-write-pat-elig-hist                 pic 9(7).
* 2004/02/19 - end
    05  ctr-rewrit-batctrl-file                 pic 9(7).
    05  ctr-rewrit-claims-mstr                  pic 9(7).
    05  ctr-rewrit-const-mstr                   pic 9(7).
    05  ctr-read-msg-sub-mstr                   pic 9(7).
* 2010/06/21 - MC9
    05  ctr-read-rejected-claims                pic 9(7).
    05  ctr-updated-rejected-claims             pic 9(7).
* 2010/06/21 - end

*   (include the pricing algorith's hold variables)
*   (brad1 - allow pricing to price up to 20 lines (2 rolled screens of 10 lines each)
*77  ss-max-nbr-oma-det-rec-allow	 	pic 99  comp    value  8.	
77  ss-max-nbr-oma-det-rec-allow	 	pic 99  comp    value 20.
    copy "pricing_variables_hold.ws".


*     data stored in working-storage for constants master clinic rec since
*     fd area is re-used for constants master pricing recs.
01  ws-iconst-mstr-rec-data.
    05  ws-iconst-clinic-nbr-1-2                pic   99.
*    05  ws-iconst-clinic-nbr                    pic 9(4). - 99/05/27 by M.C.
    05  ws-iconst-clinic-nbr                    pic x(4).
    05  ws-iconst-clinic-cycle-nbr              pic   99.
*y2k
*   05  ws-iconst-date-period-end               pic 9(6).
    05  ws-iconst-date-period-end               pic 9(8).
    05  ws-iconst-clinic-card-colour            pic    x.


*     data stored in working-storage from files that share i-o buffer areas.
01  ws-doc-mstr-rec-data.
    05  ws-doc-nx-batch-nbr                     pic  999.
    05  ws-doc-dept                             pic   99.
    05  ws-doc-ohip-nbr                         pic 9(6).
    05  ws-doc-spec-cd                          pic   99.
    05  ws-doc-locations.
        10  ws-doc-loc  occurs 30               pic x999.


01  hold-last-elig-mail-date.
*y2k
*   05  hold-last-elig-mail-yy                  pic 99 value zero.
    05  hold-last-elig-mail-yy                  pic 9(4) value zero.
    05  hold-last-elig-mail-yye redefines hold-last-elig-mail-yy.
	10  hold-last-elig-mail-yy-12		pic 99.
	10  hold-last-elig-mail-yy-34		pic 99.
    05  hold-last-elig-mail-mm                  pic 99 value zero.
    05  hold-last-elig-mail-dd                  pic 99 value zero.

01  hold-last-elig-maint-date.
*y2k
*   05  hold-last-elig-maint-yy                 pic 99 value zero.
    05  hold-last-elig-maint-yy                 pic 9(4) value zero.
    05  hold-last-elig-maint-yy-r redefines hold-last-elig-maint-yy.
	10  hold-last-elig-maint-yy-12		pic 99.
	10  hold-last-elig-maint-yy-34		pic 99.
    05  hold-last-elig-maint-mm                 pic 99 value zero.
    05  hold-last-elig-maint-dd                 pic 99 value zero.

*y2k
01  hold-last-birth-date.
*y2k
*   05  hold-last-birth-yy                      pic 99 value zero.
    05  hold-last-birth-yy.
        10 hold-last-birth-yy-12		pic 99.
	10 hold-last-birth-yy-34		pic 99.
    05  hold-last-birth-mm                      pic 99 value zero.
    05  hold-last-birth-dd                      pic 99 value zero.

*y2k
*01  hold-date                                  pic 9(5).

* 2003/11/19 - MC
*01  hold-date                                   pic 9(12).
01  hold-date                                   pic 9(8).
* 2003/11/19 - end 

01  rem1                                        pic 9(4).

*y2k
01  special-date                                pic s9(9) comp.
01  special-date-r  redefines special-date.
*y2k
    05 spec-date-1                              pic x(2).
*y2k
    05 spec-date-2                              pic x(2).

01  hold-pat-birth-date.
*y2k
*   05  hold-pat-birth-yy                       pic 99.
    05  hold-pat-birth-yy.
        10 hold-pat-birth-yy-12			pic 99.
	10 hold-pat-birth-yy-34			pic 99.
    05  hold-pat-birth-mm                       pic 99.
    05  hold-pat-birth-dd                       pic 99.

* 2004/02/23 - MC
**01  hold-version-cd                             pic x.
01  hold-version-cd                             pic xx.
* 2004/02/23 - end

* 2004/02/26 - MC
01  ws-clmhdr-hosp				pic x(4).
* 2004/02/26 - end

01  elig-flag                                   pic x.

01  last-claim-flag.
    05  last-claim                              pic x.
    05  filler                                  pic xx.
01  nbr-of-services-r redefines last-claim-flag.
    05 nbr-of-services                          pic 999.

01  claim-nbr-serv                              pic 999.

01  save-clmdtl-oma                             pic 99.

01 new-name.
    05  new-pat-surname                         pic x(15).
    05  new-pat-given-name                      pic x(12).

01  new-acronym.
    05  new-pat-surname6                        pic x(6).
    05  new-pat-given-name3                     pic x(3).

01  name-change-flag                            pic x.

01  save-feedback-pat-mstr                      pic x(4).

01  old-acronym                                 pic x(9).

01  pat-occur                                   pic 9(12).
01  pat-occur-acr                               pic 9(12).

01  error-message-table.

    05  error-messages.
        10  filler                              pic x(60)   value
* msg #1
                "INVALID REPLY".
        10  filler                              pic x(60)   value
                "NO SUCH 'CLAIMS' BATCH EXISTS IN THE BATCH CONTROL FILE".
        10  filler                              pic x(60)   value
                "INVALID PASSWORD".
        10  filler                              pic x(60)   value
                "SERIOUS ERROR #1 !! -- LAST CLAIM IN BATCH NOT FOUND".
        10  filler                              pic x(60)   value
* msg #5
                "INVALID DATE".
        10  filler                              pic x(60)   value
                "DATE CAN'T BE IN THE FUTURE (ie. > CURRENT SYSTEM DATE)".
        10  filler                              pic x(60)   value
                "INVALID DOCTOR NUMBER".
        10  filler                              pic x(60)   value
                "OMA CODES INPUT REQUIRE NON-ZERO DIAGNOSTIC CODE".
        10  filler                              pic x(60)   value
                "SERIOUS ERROR #2 !! -- BATCH'S DOCTOR NOT FOUND IN DOC MSTR".
        10  filler                              pic x(60)   value
* msg #10
                "INVALID LOCATION for batch's DOCTOR".
        10  filler                              pic x(60)   value
                "OMA Code requires a HOSPITAL Code - is LOCATION correct?".
        10  filler                              pic x(60)   value
                "IN/OUT PATIENT INDICATOR MUST BE 'I'N, 'O'UT, OR 'B'OTH".
        10  filler                              pic x(60)   value
                "INVALID OHIP Nbr / Chart ID -- please correct".
        10  filler                              pic x(60)   value
                "AGENT IS 'OHIP' -- Patient doesn't have OHIP or Health Nbr".
        10  filler                              pic x(60)   value
* msg #15
                "CONSTANTS MSTR REC 'LOCKED' -- INFORM OPERATIONS OF PROBLEM".
        10  filler                              pic x(60)   value
                "PATIENT NOT ON FILE".
        10  filler                              pic x(60)   value
                "PATIENT OHIP NBR DOESN'T EXIST".
        10  filler                              pic x(60)   value
                "PATIENT CHART NBR DOESN'T EXIST".
        10  filler                              pic x(60)   value
                "LOOK OUT !!  PREMIUM CODE. IS IT AN 'IN' OR 'E.R.' PATIENT ?".
        10  filler                              pic x(60)   value
* msg #20
                "INVALID 2 DIGIT CLINIC IDENTIFIER".
        10  filler                              pic x(60)   value
                "SERIOUS ERROR #10 - UNABLE TO READ CONSTANT MSTR REC #2 ".
        10  filler                              pic x(60)   value
                "CLAIM AGENT CODE = 'OHIP' -- BUT PATIENT'S OHIP # IS INVALID".
        10  filler                              pic x(60)   value
* 2010/03/30- MC5 - include clinic 66
*                "MUST SUPPLY REFERRING DOCTOR FOR CLINIC 61 TO 65".
                "MUST SUPPLY REFERRING DOCTOR FOR CLINIC 61 TO 66".
* 2010/03/30 - end
        10  filler                              pic x(60)       value
* 2007/07/16 - MC
*                "CAN'T KEY 'CV' or 'SP' SERVICES FOR CLINIC 61 TO 65".
                "CAN'T KEY 'CV' or 'SP' SERVICES FOR CLINIC 60's or 70's".
* 2007/07/16 - end
        10  filler                              pic x(60)       value
* msg #25
                "'B' OR 'C' SUFFIX NOT ALLOWED WITH CONSULTATIONS AND VISITS".
        10  filler                              pic x(60)       value
                "Ohip # 11111119 valid only for ALTERNATIVE FUNDING Agent".
        10  filler                              pic x(60)       value
                "SURNAME INPUT NOT = SURNAME OF PATIENT ON FILE".
        10  filler                              pic x(60)       value
                "INVALID OMA CODE".
        10  filler                              pic x(60)       value
                "SERIOUS ERROR #4 - INVALID WRITE ON CLAIMS HEADER INDX 1".
        10  filler                              pic x(60)       value
* msg #30
                "SERIOUS ERROR #5 - INVALID WRITE ON CLAIMS HEADER INDX 2".
        10  filler                              pic x(60)       value
                "SERIOUS ERROR #6 !! -- INVALID WRITE ON CLAIMS DETAIL REC".
        10  filler                              pic x(60)       value
                "# SERVICES FROM DAY DOES NOT FALL WITHIN # DAYS IN MONTH".
        10  filler                              pic x(60)       value
                "SERVICE DATE < ADMIT DATE".
        10  filler                              pic x(60)       value
                "'OHIP' AGENT REQUIRES A REFERRING PHYSICAN".
        10  filler                              pic x(60)       value
* msg #35
                "*NOT USED*'OHIP' requires a HOSPITAL # ting 'Y'es flag".
        10  filler                              pic x(60)       value
                "'OHIP' AGENT REQUIRES A PATIENT I/O INDICATOR OF 'I'".
        10  filler                              pic x(60)       value
                "'OHIP' AGENT REQUIRES A PATIENT I/O INDICATOR OF 'O'".
        10  filler                              pic x(60)       value
                "'OHIP' AGENT REQUIRES AN ADMIT DATE".
        10  filler                              pic x(60)       value
                "'OHIP' AGENT REQUIRES DOCTOR SPECIALTY CODE BE WITHIN RANGE".
        10  filler                              pic x(60)       value
* msg #40
* 2013/07/10 - MC31
*                "'OHIP' AGENT REQUIRES SERVICE WITHIN 6 MTHS OF SYSTEM DATE".
* MC41
*                "'OHIP' AGENT REQUIRES SERVICE WITHIN 7 MTHS OF SYSTEM DATE".
                "'OHIP' AGENT REQUIRES SERVICE WITHIN 231 days OF SYSTEM DATE".
* MC41 - end
* 2013/07/10 - end
        10  filler                              pic x(60)       value
                "DAY INPUT FALLS WITHIN PREVIOUS CONSECUTIVE DAY RANGE".
        10  filler                              pic x(60)       value
                "BATCH ALREADY EXISTS".
        10  filler                              pic x(60)       value
                "SERIOUS ERROR #7 !! - ERROR IN WRITING TO BATCH CONTROL FILE".
        10  filler                              pic x(60)       value
                "INVALID DIAGNOSTIC Code".
        10  filler                              pic x(60)       value
* msg #45
                "SERVICE DATE > SYSTEM DATE".
        10  filler                              pic x(60)       value
                "SERIOUS ERROR #8 !! - ERROR IN DELETING BATCH CONTROL RECORD".
        10  filler                              pic x(60)       value
                "OMA CODE'S SUFFIX MUST BE 'A','B','C', OR 'M'".
        10  filler                              pic x(60)       value
                "SERIOUS ERROR #9 !! - ERROR IN RE-WRITING PATIENT'S RECORD".
        10  filler                              pic x(60)       value
                "DIALYSIS PATIENT NOT FOUND, WITH ENTERED ACRONYM".
        10  filler                              pic x(60)       value
* msg #50
                "LOOK OUT !! OMA CODE'S BASIC VALUE = ZERO !".
        10  filler                              pic x(60)       value
                "UNABLE TO ACCESS BATCH -- STATUS IS NOT UNBALANCED/BALANCED".
        10  filler                              pic x(60)       value
                "MAXIMUM OF 99 CLAIMS HAVE BEEN ENTERED FOR BATCH - SHUT DOWN".
        10  filler                              pic x(60)       value
                "NEXT CLAIM ALREADY EXISTS! - SHUTDOWN AND START A NEW BATCH".
        10  filler                              pic x(60)       value
                "INVALID Doctor DEPARTMENT number".
        10  filler                              pic x(60)       value
* msg #55
                "SERIOUS ERROR #10 !! - ERROR IN RE-WRITING DOCTOR RECORD".
        10  filler                              pic x(60)       value
                "EXISTING OR ZERO MESSAGE NUMBER REQUIRED".
        10  filler                              pic x(60)       value
                "Existing SUBDIVISION Number required".
        10  filler                              pic x(60)       value
                "CAN NOT ENTER ZERO FEE".
        10  filler                              pic x(60)       value
                "FEE VALUE OF ZERO FOUND".
        10  filler                              pic x(60)       value
* msg # 60
                "SYSTEM DATE GREATER THAN PERIOD-END-DATE".
        10  filler                              pic x(60)       value
                "BATCTRL AMT > 99999.99, RE-ENTER CLAIM WITH NEW BATCH".
        10  filler                              pic x(60)       value
                "WARNING - CAN'T MANUALLY CONTINUE DISKETTE BATCH ".
        10  filler                              pic x(60)       value
                "PATIENT HEALTH NBR DOES NOT EXIST".
        10  filler                              pic x(60)       value
* 2010/03/30 - MC5 
*                "ONLY CLINIC NBR 22 OR 61 TO 65 IS VALID".
                "ONLY CLINIC NBR > 21 and < 100 and not clinc 60 is VALID".
* 2010/03/30 - end
        10  filler                              pic x(60)       value
* msg # 65
                "CAN'T ENTER OHIP OR WCB CLAIMS WITH 'PQ' PROV CODE".
        10  filler                              pic x(60)       value
                "HEALTH NBR IS EXPIRED".
        10  filler                              pic x(60)       value
                "REFERRING DOC # CAN'T THE SAME AS DOC # OF THE CLAIM".
        10  filler                              pic x(60)       value
                "MANUAL REVIEW CAN ONLY BE 'Y' OR ' '".
        10  filler                              pic x(60)       value
                "INVALID HEALTH CARE NUMBER --PLEASE CORRECT".
        10  filler                              pic x(60)       value
* msg # 70
                "PATIENT MUST HAVE HEALTH # FOR SERVICES AFTER 91/06/30".
        10  filler                              pic x(60)       value
                "INVALID SPECIALTY Code for this Doctor".
        10  filler                              pic x(60)       value
                "INVALID CLINIC Nbr for this Doctor".
        10  filler                              pic x(60)       value
                "BIRTH YEAR > SYSTEM YEAR".
        10  filler                              pic x(60)       value
                "BIRTH DATE > SYSTEM DATE".
        10  filler                              pic x(60)       value
* msg # 75
                "INVALID EXPIRY MONTH".
        10  filler                              pic x(60)       value
                "NBR OF SERV MUST BE EITHER NUMERIC OR '*'".
        10  filler                              pic x(60)       value
                "ENTERED SERV NOT EQUAL TO COMPUTED SERV".
        10  filler                              pic x(60)       value
                "INVALID WRITE INVERTED TO PAT MSTR ACRONYM".
        10  filler                              pic x(60)       value
                "CAN'T DELETE OLD ACRONYM KEY".
        10  filler                              pic x(60)       value
* msg # 80
                "INVALID READ ON PATIENT ACRONYM".
        10  filler                              pic x(60)       value
                "REACH TO THE END OF ACRONYM PAT MSTR".
        10  filler                              pic x(60)       value
                "ACRONYM READ IS NOT THE SAME AS THE ORIG ACRONYM".
        10  filler                              pic x(60)       value
		"Oma Code is NOT ACTIVE for data entry".
        10  filler                              pic x(60)       value
                "Doctor fails mod10 check. Are you sure number is correct?".
        10  filler                              pic x(60)       value
* msg # 85
                "You must enter a HEALTH # OR an out-of-province patient id".
        10  filler                              pic x(60)       value
                "INCREASING OMA  fee to MINIMUM value specified in Fee Master".
        10  filler                              pic x(60)       value
                "INCREASING OHIP fee to MINIMUM value specified in Fee Master".
        10  filler                              pic x(60)       value
                "DECREASING OMA  fee to MAXIMUM value specified in Fee Master".
        10  filler                              pic x(60)       value
                "DECREASING OHIP fee to MAXIMUM value specified in Fee Master".
        10  filler                              pic x(60)       value
* msg # 90
                "basic fee (yb0-) ...".
        10  filler                              pic x(60)       value
		"ICC sort flag have been determined (yd0-) ...".
        10  filler                              pic x(60)       value
                "group reductions (ye0-) ...".
        10  filler                              pic x(60)       value
		"add ons (yf0-) ...".
        10  filler                              pic x(60)       value
		"find highest group within section (yh0-) ...".
        10  filler                              pic x(60)       value
* msg # 95
		"sectional reduction (yi0-) ...".
        10  filler                              pic x(60)       value
		"special AddOn (yf1-) ...".
        10  filler                              pic x(60)       value
		"BEFORE min/maximums testing ...".
        10  filler                              pic x(60)       value
		"AFTER  min/maximums testing ...".
        10  filler                              pic x(60)       value
		"Technical prices calulated (ya3-) ....".
        10  filler                              pic x(60)       value
* msg # 100
		"sorted back into original sequence (yj0-) ...".
        10  filler                              pic x(60)       value
		"This code expands to 2 lines, split claim into a 2nd claim".
        10  filler                              pic x(60)       value
		"INVALID LOCATION Code - code is not in Location Master".
        10  filler                              pic x(60)       value
		"LOCATION Code not currently active for data entry".
        10  filler                              pic x(60)       value
		"'A' for 'regular clinic 22' / 'B' for ICU payroll".
        10  filler                              pic x(60)       value
* msg # 105
		"ICU payroll payroll doctor - use Payroll 'B'".
        10  filler                              pic x(60)       value
		"Warning - verify these claims aren't for Payroll 'B'".
        10  filler                              pic x(60)       value
		"Warning -  doctor is TERMINATED!".
        10  filler                              pic x(60)       value
		"Prefix must be either '!' or '$' ".
        10  filler                              pic x(60)       value
                "ADMIT DATE < BIRTH DATE".
        10  filler                              pic x(60)       value
* msg # 110
		"technical code not allowed for the clinic".       
        10  filler                              pic x(60)       value
*		"Add on E708 could be billed with these ohip/diag codes".       
		"E078 may be allowable, please check...".
        10  filler                              pic x(60)       value
		"Agent 3, 5, 7 or 8 is not allowed".  
        10  filler                              pic x(60)       value
		"Clinic 98 only allows agent 6".      
        10  filler                              pic x(60)       value
* 2010/03/30 - MC5 - include clinic 66
*		"Clinic 61 to 65 with M500 location must have admit date".
		"Clinic 61 to 66 with M500 location must have admit date".
* 2010/03/30 - end
* msg # 115
        10  filler                              pic x(60)       value
		"RMB claim must have non-Ontario province, please check.".
        10  filler                              pic x(60)       value
		"Clinic 71 to 75 with M500 location must have admit date".
        10  filler                              pic x(60)       value
                "Alternate funding claims must have Ontario province".
        10  filler                              pic x(60)       value
		"As of 2008/01/01 Pediatrics can't bill A007 - use A261/2".
        10  filler                              pic x(60)       value
* 2013/04/10 - MC28
*               "Check number of services for E add-on code".
                "Check number of services for C suffix code".
* 2013/04/10 - end
* #120
        10  filler                              pic x(60)       value
                "E020C only allowed with E022C, E017C or E016C".
        10  filler                              pic x(60)       value
                "E719 only allowed with Z570".
        10  filler                              pic x(60)       value
                "E720 only allowed with Z571".
        10  filler                              pic x(60)       value
* 2011/11/23 - MC22 - edit 5 
*		"E717 only allowed with Z555 or Z580".
		"E717 only allowed with specific colonoscopy codes".
* 2011/11/23 - end
        10  filler                              pic x(60)       value
                "E702 only allowed with specific codes".
* #125
        10  filler                              pic x(60)       value
                "G123 only allowed with G228".
        10  filler                              pic x(60)       value
                "G223 only allowed with G231".
        10  filler                              pic x(60)       value
                "G265 only allowed with G264".
        10  filler                              pic x(60)       value
                "G385 only allowed with G384".
        10  filler                              pic x(60)       value
                "G281 only allowed with G381".
* #130
        10  filler                              pic x(60)       value
                "Maximum number of services exceeded".
        10  filler                              pic x(60)       value
                "E793 only allowed with specific procedures".
        10  filler                              pic x(60)       value
                "P022 deleted as of 2008/02/01".
        10  filler                              pic x(60)       value
                "K120 deleted as of 2008/02/01".
        10  filler                              pic x(60)       value
* 2011/08/22 - MC21
*               "A007 only allowed for specialty '00'".
                "A007 not allowed for specialty  '26'".
* 2011/08/22 - end
* 2009/05/04 - MC2
* #135
        10  filler                              pic x(60)       value
                "Check fee and services of E400".             
        10  filler                              pic x(60)       value
                "Check fee and services of E401". 
        10  filler                              pic x(60)       value
                "E798 allowed only with  Z400".   
        10  filler                              pic x(60)       value
                "Check fee of E409/E410". 
        10  filler                              pic x(60)       value
                "Use General Listing code with special visit premium".
* #140
        10  filler                              pic x(60)       value
                "E450 may only be billed with J315".
* 2009/05/04 - end

* 2010/04/14 - MC6 - add errors 141 to 154
        10  filler                              pic x(60)       value
                "G222 not allowed with G248, G125, G118 or G062".
        10  filler                              pic x(60)       value
* 2011/11/23 - MC22 - edit 21
*               "A770 or A775 not allowed with special visit premium".
                "A770 or A775 or A075 not allowed with special visit premium".
* 2011/11/23 - end
        10  filler                              pic x(60)       value
                "Z432C deleted as of 2009/10/01".
        10  filler                              pic x(60)       value
                "H112 / H113 not allowed with another 'H' code".
* #145
        10  filler                              pic x(60)       value
                "Patient is underage for G489 / S323".
        10  filler                              pic x(60)       value
                "G222, Z804 or Z805 not allowed with P014C or P016C".
        10  filler                              pic x(60)       value
* 2010/09/21 - MC13
*                "H prefixed codes must be agent 2 in clinic 22".
* 2010/12/08 - MC16
*                "H prefixed codes must be agent 2 or 9 in clinic 22".
                "H prefixed E.R. codes must be agent 2 or 9 in clinic 22".
* 2010/12/08 - end
* 2010/09/21 - end
        10  filler                              pic x(60)       value
                "G221 only allowed with G220".
        10  filler                              pic x(60)       value
                "Patient must be under 16 for service".
* #150
        10  filler                              pic x(60)       value
                "Patient is overage for H267".
        10  filler                              pic x(60)       value
                "Reassessment not allowed with resuscitation".
        10  filler                              pic x(60)       value
                "Assessment included in chemotherapy code".
        10  filler                              pic x(60)       value
* 2011/04/11 - MC18
*                "Check suffix on 'G' code".  
		 "Check suffix on 'G' code or premium code".
* 2011/04/11 - end
        10  filler                              pic x(60)       value
                "Patient must be 16 and under".
* #155 - edit 34 & 65
        10  filler                              pic x(60)       value
                "Patient is underage for service".
* 2010/04/14 - end
* 2010/07/12 - MC11 
        10  filler                              pic x(60)       value
* 2010/08/17 - MC12 - include value 0 as well
*                "Value must be 1 to 5 for dept 41, 42, 43 or 75".
                "Value must be 0 to 5 for dept 41, 42, 43 or 75".
* 2010/08/17 - end
        10  filler                              pic x(60)       value
                "allowable entry is 'A'". 
* 2010/07/12 - end

* 2011/04/11 - MC18 - add message 158 to 170
        10  filler                              pic x(60)       value
                "J021 and J022 should be at 50% with J025".
        10  filler                              pic x(60)       value
                "Referring doctor must be an optometrist".
* #160
        10  filler                              pic x(60)       value
                "Referral must be a midwife".
        10  filler                              pic x(60)       value
                "Referring doctor cannot be an optometrist".
        10  filler                              pic x(60)       value
		"Z611 or Z602 not allowed with Z608".
        10  filler                              pic x(60)       value
		"Z176 or Z154 must have manual review".
        10  filler                              pic x(60)       value
		"Z175 - Z192 must have manual review".
* #165
        10  filler                              pic x(60)       value
		"Z403 with Z408 must have manual review".
        10  filler                              pic x(60)       value
		"A195 with K002 requires manual review with times of service".
        10  filler                              pic x(60)       value
		"Add E083 to MRP code".
        10  filler                              pic x(60)       value
		"E083 only allowed with specific codes".
        10  filler                              pic x(60)       value
		"Clarification required to add J021".
* #170
        10  filler                              pic x(60)       value
		"Echo needs admit date for in-patient".
* 2011/04/11 - end
* 2011/05/19 - MC20 - add message 171 & 172
        10  filler                              pic x(60)       value
		"Oma code suffix  / SLI  does not have admit date".
        10  filler                              pic x(60)       value
		"Oma code suffix  / SLI  does not require admit date".
* 2011/05/19 - end
* 2011/11/23 - MC22 - add message 173 to 175 for new edits 52 to 63
        10  filler                              pic x(60)       value
                 "Patient is overage for service".
        10  filler                              pic x(60)       value
                 "K189 only allowed with specific codes".
* #175 - edit 54 to 63
        10  filler                              pic x(60)       value
                 "Travel Premium billed incorrectly".
* 2011/11/23 - end

* #176 - edit 64
        10  filler                              pic x(60)       value
                 "Check Fee and Services for E676B". 
* 2011/12/05 - end


* 2013/04/10 - MC28
* #177 - 180 for edit 66 to 69
        10  filler                              pic x(60)       value
                 "Cannot use time units calculator for counselling".
        10  filler                              pic x(60)       value
                 "G556 only allowed with Day 1 per diem".
        10  filler                              pic x(60)       value
                 "A120 only allowed with colonoscopy codes".  
* #180
        10  filler                              pic x(60)       value
                 "referral cannot be midwife".
* 2013/04/10 - end
* 2013/07/09 - MC31
        10  filler                              pic x(60)       value
                 "Doctor start date greater than system run date".               
* 2013/07/09 - end
* MC37
        10  filler                              pic x(60)   value
                "Disallow '~' in the field : re-enter".
* MC37 - end
* MC44
        10  filler                              pic x(60)   value
                "Invalid version cd:  re-enter".
* MC44 - end

* 2006/09/25 - MC
    05  error-messages-r redefines error-messages.
        10  err-msg                             pic x(60)
                        occurs 183 times.

01  err-msg-comment                             pic x(60).

01  e1-error-line.
    05  e1-error-word                           pic x(13)    value
                        "*==  ERROR - ".
    05  e1-error-msg                            pic x(119).



screen section.

01  scr-title-claim-rec-data.

    05  blank screen.
    05  line 01 col 01 value is "D001B".
    05  line 01 col 31 value is "CLAIMS DATA ENTRY".
*y2k
*   05  line 01 col 73 pic 99 using sys-yy.
    05  line 01 col 71 pic 9999 using sys-yy.
    05  line 01 col 75 value "/".
    05  line 01 col 76 pic 99 using sys-mm.
    05  line 01 col 78 value "/".
    05  line 01 col 79 pic 99 using sys-dd.


01  scr-claim-lit.

    05  line 03 col 01 value "CLAIM ID    :".
    05  line 03 col 25 value "-".
    05  line 04 col 01 value "H/C...:".
    05  line 04 col 21 value "VER:".
    05  line 04 col 27 value "/".
    05  line 04 col 32 value "LAST.:".
    05  line 04 col 54 value "DOB(CUR/OLD)".
    05  line 04 col 74 value "/".

    05  line 05 col 01 value "PAT ID:".
    05  line 05 col 21 value "EXP:".
    05  line 05 col 32 value "FIRST:".
    05  line 05 col 54 value "ELIG(CHG/MAIL)".
    05  line 05 col 74 value "/".

    05  line 06 col 01 value "MESS:".
    05  line 06 col 12 value "ADDR:".

    05  line  8 col 01 value "REFER DOC:".
    05  line  8 col 22 value "LOC   :".
    05  line  8 col 36 value "HOSP:".
    05  line  8 col 46 value "I/O PATIENT:".
    05  line  8 col 63 value "ADMIT:".
    05  line  8 col 73 value "/".
    05  line  8 col 76 value "/".
    05  line  9 col 01 value "DIAG     :".
    05  line  9 col 22 value "REVIEW:".
    05  line  9 col 36 value "MESSAGE ID :".
    05  line  9 col 53 value "SUBDIVISION:".
    05  line  9 col 70 value "PAYROLL:".
    05  line 10 col 01 value "OMA SF  SERV DATE  #S DIAG".
    05  line 10 col 30 value "DD #S  DD #S  DD #S".
    05  line 10 col 52 value "OMA FEE (OHIP FEE) ICC  S/G".

01  scr-acpt-clmhdr.

    05          line 03 col 15 pic  99  using clmhdr-clinic-nbr-1-2 highlight.
*!    05          line 03 col 18 pic 999  using clmhdr-doc-nbr highlight.
    05          line 03 col 18 pic xxx  using clmhdr-doc-nbr highlight.
    05          line 03 col 22 pic 999  using clmhdr-batch-nbr-7-9 highlight.
    05                          line 03 col 26 pic 99 using batctrl-last-claim-nbr highlight.

    05  scr-pat-health-nbr      line 04 col 08 pic x(10) using
**                              ws-pat-health-nbr auto blank when zero.
                                ws-scr-health-nbr auto highlight.
    05  scr-acpt-version-cd     line 04 col 25 pic xx using ws-pat-version-cd  auto highlight.
    05                          line 04 col 28 pic xx using ws-pat-last-version-cd highlight.
    05  scr-acpt-last-name      line 04 col 38 pic x(15) using ws-pat-surname highlight.
*mf 01  scr-acpt-clmhdr-2.
*y2k - just show the lower order 2 digits of year)
*   05  scr-acpt-birth-yy       line 04 col 66 pic x(2) using ws-pat-birth-date-yy auto highlight.
    05  scr-acpt-birth-yy       line 04 col 66 pic x(4) using ws-pat-birth-date-yy auto highlight.
    05  scr-acpt-birth-mm       line 04 col 70 pic xx using ws-pat-birth-date-mm auto highlight.
    05  scr-acpt-birth-dd       line 04 col 72 pic xx using ws-pat-birth-date-dd auto highlight.
* y2k
*   05                          line 04 col 75 pic 99 using hold-last-birth-yy highlight.
    05                          line 04 col 75 pic 99 using hold-last-birth-yy-34 highlight.
    05                          line 04 col 77 pic 99 using hold-last-birth-mm highlight.
    05                          line 04 col 79 pic 99 using hold-last-birth-dd highlight.
*mf 01  scr-acpt-clmhdr-3.
*2002/04/08 - MC - include the prefix
    05  scr-ohip-chart-flag     line 05 col 08 pic x using ws-ohip-chart-flag
                                auto highlight.
*   05  scr-clmhdr-ohip-chart   line 05 col 08 pic xxx9(9) using
    05  scr-clmhdr-ohip-chart   line 05 col 09 pic xxx9(9) using
*2002/04/08 - end
                                ws-pat-ohip-mmyy auto highlight.
    05  scr-acpt-expiry-yy      line 05 col 25 pic x(2) using ws-pat-expiry-yy auto highlight.
    05  scr-acpt-expiry-mm      line 05 col 27 pic x(2) using ws-pat-expiry-mm auto highlight.
    05  scr-acpt-given-name     line 05 col 38 pic x(12) using ws-pat-given-name highlight.
*y2k - only show the lower order digits of year
*   05                          line 05 col 66 pic x(4) using hold-last-elig-maint-yy highlight.
    05                          line 05 col 68 pic xx using hold-last-elig-maint-yy-34 highlight.
    05                          line 05 col 70 pic xx using hold-last-elig-maint-mm highlight.
    05                          line 05 col 72 pic xx using hold-last-elig-maint-dd highlight.
*y2k
*   05                          line 05 col 73 pic x(4) using hold-last-elig-mail-yy highlight.
    05                          line 05 col 75 pic xx using hold-last-elig-mail-yy-34 highlight.
    05                          line 05 col 77 pic xx using hold-last-elig-mail-mm highlight.
    05                          line 05 col 79 pic xx using hold-last-elig-mail-dd highlight.

    05                          line 06 col 08 pic x(3) using ws-pat-mess-code highlight.
    05  scr-acpt-subscr-addr1   line 06 col 17 pic x(21) using ws-subscr-addr1 highlight.
    05  scr-acpt-subscr-addr2   line 06 col 38 pic x(21) using ws-subscr-addr2 highlight.
    05  scr-acpt-subscr-addr3   line 06 col 59 pic x(21) using ws-subscr-addr3 highlight.

    05  scr-acpt-postal-code    line 07 col 17 pic x(6)  using ws-subscr-postal-cd highlight.
* 2002/06/17 - mc - drop country
*    05  scr-acpt-country        line 07 col 24 pic x(20) using ws-pat-country highlight.
* 2002/06/17 - end 

*mf 01  scr-acpt-clmhdr-4.
    05  scr-clmhdr-refer-doc    line  8 col 12 pic 9(6) using
                                clmhdr-refer-doc-nbr auto blank when zero highlight.
    05  scr-clmhdr-loc           line  8 col 30 pic x999 using
* MC9
*                                clmhdr-loc of claim-header-rec auto highlight.
                                clmhdr-loc of claim-header-rec auto highlight.
* 2004/02/26 - MC - use the define item ws-clmhdr-hosp instead
*   05  scr-hosp-nbr            line  8 col 41 pic 9(4) using
*                                loc-hospital-nbr auto highlight 
*				blank when zero.
    05  scr-hosp-nbr            line  8 col 41 pic x(4) using
                                ws-clmhdr-hosp auto highlight.
* 2004/02/26 - end
*                                   clmhdr-hosp auto highlight.
    05  scr-clmhdr-i-o-pat-ind  line  8 col 59 pic x using
                                clmhdr-i-o-pat-ind auto highlight.
*y2k
*   05  scr-clmhdr-date-admit-yy    line  8 col 71 pic xx using
    05  scr-clmhdr-date-admit-yy-12 line  8 col 69 pic xx using
                                clmhdr-date-admit-yy-12 auto highlight.
    05  scr-clmhdr-date-admit-yy-34 line  8 col 71 pic xx using
                                clmhdr-date-admit-yy-34 auto highlight.
    05  scr-clmhdr-date-admit-mm line  8 col 74 pic 99 using
                                clmhdr-date-admit-mm auto highlight.
    05  scr-clmhdr-date-admit-dd line  8 col 77 pic 99 using
                                clmhdr-date-admit-dd auto highlight.
    05  scr-clmhdr-diag-cd      line  9 col 12 pic 999 using
                                clmhdr-diag-cd auto blank when zero highlight.
    05  scr-clmhdr-man-review   line  9 col 30 pic x using
                                clmhdr-manual-review auto highlight.
    05  scr-msg-nbr             line  9 col 49 pic xx using
                                clmhdr-msg-nbr auto highlight.
    05  scr-sub-nbr             line  9 col 67 pic x using
                                clmhdr-sub-nbr auto highlight.
    05  scr-payroll		line  9 col 79 pic x using
				clmhdr-payroll auto highlight.

01  scr-pat-info.
    05                          line 04 col 08 pic 9(10) using
                                ws-pat-health-nbr auto blank when zero highlight.
    05                          line 04 col 25 pic xx using ws-pat-version-cd  auto highlight.
    05                          line 04 col 28 pic xx using ws-pat-last-version-cd highlight.
    05                          line 04 col 38 pic x(15) using ws-pat-surname highlight.
*y2k - just show the lower order 2 digits of year)
*   05                          line 04 col 68 pic 9(2) using ws-pat-birth-date-yy-34 auto highlight.
*   05                          line 04 col 70 pic 99 using ws-pat-birth-date-mm auto highlight.
*   05                          line 04 col 72 pic 99 using ws-pat-birth-date-dd auto highlight.
*   05                          line 04 col 75 pic 99 using hold-last-birth-yy highlight.
*   05                          line 04 col 77 pic 99 using hold-last-birth-mm highlight.
*   05                          line 04 col 79 pic 99 using hold-last-birth-dd highlight.

    05                          line 05 col 08 pic xxx9(9) using
                                        ws-pat-ohip-mmyy auto highlight.
    05                          line 05 col 25 pic 9(2) using ws-pat-expiry-mm auto highlight.
*y2k 
    05                          line 05 col 27 pic 9(2) using ws-pat-expiry-yy auto highlight.
    05                          line 05 col 38 pic x(12) using ws-pat-given-name highlight.
*y2k
*   05                          line 05 col 68 pic 99 using hold-last-elig-maint-yy highlight.
*   05                          line 05 col 66 pic 9(2) using hold-last-elig-maint-yy highlight.
*   05                          line 05 col 70 pic 99 using hold-last-elig-maint-mm highlight.
*   05                          line 05 col 72 pic 99 using hold-last-elig-maint-dd highlight.
*y2k
*   05                          line 05 col 75 pic 99 using hold-last-elig-mail-yy highlight.
*   05                          line 05 col 73 pic 9(2) using hold-last-elig-mail-yy highlight.
*   05                          line 05 col 77 pic 99 using hold-last-elig-mail-mm highlight.
*   05                          line 05 col 79 pic 99 using hold-last-elig-mail-dd highlight.

    05                          line 06 col 08 pic x(3) using ws-pat-mess-code highlight.
    05                          line 06 col 17 pic x(21) using ws-subscr-addr1 HIghlight.
    05                          line 06 col 38 pic x(21) using ws-subscr-addr2 highlight.
    05                          line 06 col 59 pic x(21) using ws-subscr-addr3 highlight.

    05                          line 07 col 17 pic x(6)  using ws-subscr-postal-cd highlight.
* 2002/06/17 - mc - drop country
*    05                          line 07 col 24 pic x(20) using ws-pat-country highlight.
* 2002/06/17 - end 

01  scr-last-claim-lit.
*   05                          line 03 col 65 value 'Last Claim'.
    05                          line 03 col 65 value 'Nbr of Svc:'.
    05  scr-last-claim          line 03 col 77 pic xxx using
                                last-claim-flag auto highlight.

01  scr-acpt-pat-surname.
    05  scr-clmhdr-pat-surname
                                line 07 col 70 pic x(6) using
                                clmhdr-pat-acronym6 auto highlight.
*
01  scr-acpt-patient-verif.
*			(brad1 - move this line when allowing 10 claim details lines instead of 8)
*    05                 line 08 col 36 value '"R"estart claim,"T"ry # again,"A"dd patient'.
    05                  line 02 col 36 value '"R"estart claim,"T"ry # again,"A"dd patient'.
    05  scr-clmhdr-pat-verif
*                       line 08 col 80 pic x to reply-create-pat auto.
                        line 02 col 80 pic x to reply-create-pat auto.

01  scr-clear-pat-verif.
*			(brad1 - move this line when allowing 10 claim details lines instead of 8)
*    05                  line 08 col 36 blank line.
    05                  line 02 col 36 blank line.

01  scr-acpt-clmhdr-det.

    05  scr-hold-oma-cd
                        line pline col 01 pic x999 using
                        hold-oma-cd(ss-clmdtl-oma) auto highlight.
    05  scr-hold-oma-suff
                        line pline col 06 pic a    using hold-oma-suff(ss-clmdtl-oma) auto highlight.
*y2k - field left as 2 digit entry/ century is automatically defaulted by system
    05  scr-hold-sv-date-yy-12
                        line pline col  8 pic 99 from
                        hold-sv-date-yy-12(ss-clmdtl-oma) auto highlight.
    05  scr-hold-sv-date-yy-34
                        line pline col 10 pic 99 using
                        hold-sv-date-yy-34(ss-clmdtl-oma) auto highlight.
    05                  line pline col 12 value "/".
    05  scr-hold-sv-date-mm
                        line pline col 13 pic 99 using
                        hold-sv-date-mm(ss-clmdtl-oma) auto highlight.
    05                  line pline col 15 value "/".
    05  scr-hold-sv-date-dd
                        line pline col 16 pic 99 using
                        hold-sv-date-dd(ss-clmdtl-oma) auto highlight.
    05  scr-hold-sv-nbr-0
                        line pline col 21 pic 99 using
                        hold-sv-nbr-serv(ss-clmdtl-oma) auto highlight.
    05  scr-hold-diag-cd
                        line pline col 25 pic 999 using
                        hold-diag-cd(ss-clmdtl-oma) auto blank when zero highlight.
    05  scr-hold-sv-nbr-1
                        line pline col 33 pic  9 using
                        hold-sv-nbr(ss-clmdtl-oma,1) auto.
    05  scr-hold-sv-day-1
                        line pline col 30 pic xx using
                        hold-sv-day(ss-clmdtl-oma,1) auto.
    05  scr-hold-sv-nbr-2
                        line pline col 40 pic  9 using
                        hold-sv-nbr(ss-clmdtl-oma,2) auto.
    05  scr-hold-sv-day-2
                        line pline col 37 pic 99 using
                        hold-sv-day(ss-clmdtl-oma,2) auto.
    05  scr-hold-sv-nbr-3
                        line pline col 47 pic  9 using
                        hold-sv-nbr(ss-clmdtl-oma,3)auto.
    05  scr-hold-sv-day-3
                        line pline col 44 pic 99 using
                        hold-sv-day(ss-clmdtl-oma,3) auto.

    05  scr-hold-fee-oma  line pline col 50 pic zz,zz9.99- using hold-fee-oma(ss-clmdtl-oma) auto.
    05  scr-hold-fee-ohip line pline col 61 pic zz,zz9.99- using hold-fee-ohip(ss-clmdtl-oma).
    05  scr-icc-cd        line pline col 71 pic x(4)    using hold-icc-cd(ss-clmdtl-oma).
    05  scr-sec-grp       line pline col 76 pic 99      using hold-flag-sec-group(ss-clmdtl-oma).
*
*
01  scr-acpt-det-desc.

    05                  line 22 col 01 value "DESC #1:".
    05  scr-hold-desc-1
                        line 22 col 09 pic x(22) using hold-desc-1 auto.
    05                  line 22 col 31 value      "#2:".
    05  scr-hold-desc-2
                        line 22 col 34 pic x(22) using hold-desc-2 auto.
    05                  line 22 col 56 value      "#3:".
    05  scr-hold-desc-3
                        line 22 col 59 pic x(22) using hold-desc-3 auto.
    05                  line 23 col 01 value "DESC #4:".
    05  scr-hold-desc-4
                        line 23 col 09 pic x(22) using hold-desc-4 auto.
    05                  line 23 col 31 value      "#5:".
    05  scr-hold-desc-5
                        line 23 col 34 pic x(22) using hold-desc-5 auto.


    05  line 24 col  2 pic 99 using ws-highest-grp-nbr.
    05  line 24 col 30 pic z(4)9.99 using ws-highest-grp-tot.

01 file-status-display.
    05  line 24 col 01 pic x(42) from ws-file-err-msg.
    05  line 24 col 44 pic x(7)  from ws-disp-pat-key-type.
    05  line 24 col 56  "FILE STATUS = ".
    05  line 24 col 70  pic x(11) using status-cobol-display bell blink.
*
01  err-msg-line.
    05  line 24 col 01  value " ERROR -  "      bell blink.
    05  line 24 col 11  pic x(60)       using err-msg-comment.

01  confirm.
    05 line 24 col 01  pic x to continue-reply auto.

01  scr-loading-message.
    05  line 24 col 01 value "PGM M010 IS LOADING....PLEASE WAIT".

* (brad1 - allow 10 claim lines per screen rather than 8)
01  blank-det-line-2.
*    05  line 15 col 1   blank line.
    05  line 12 col 1   blank line.
01  blank-det-line-3.
*    05  line 16 col 1   blank line.
    05  line 13 col 1   blank line.
01  blank-det-line-4.
*    05  line 17 col 1   blank line.
    05  line 14 col 1   blank line.
01  blank-det-line-5.
*    05  line 18 col 1   blank line.
    05  line 15 col 1   blank line.
01  blank-det-line-6.
*    05  line 19 col 1   blank line.
    05  line 16 col 1   blank line.
01  blank-det-line-7.
*    05  line 20 col 1   blank line.
    05  line 17 col 1   blank line.
01  blank-det-line-8.
*    05  line 21 col 1   blank line.
    05  line 18 col 1   blank line.
* (brad1 - allow 10 claim lines per screen rather than 8)
01  blank-det-line-9.
    05  line 19 col 1   blank line.
01  blank-det-line-10.
    05  line 20 col 1   blank line.

* (brad1 - increased number of claim details from 8 to 10)
01  blank-detail-lines.
*    05  line 14 col 01 blank line.
    05  line 11 col 01 blank line.
    05  line 12 col 01 blank line.
    05  line 13 col 01 blank line.
    05  line 14 col 01 blank line.
    05  line 15 col 01 blank line.
    05  line 16 col 01 blank line.
    05  line 17 col 01 blank line.
    05  line 18 col 01 blank line.
* (brad1 - increased number of claim details from 8 to 10)
    05  line 19 col 01 blank line.
    05  line 20 col 01 blank line.

01  blank-line-24.
    05  line 24 col 1   blank line.

01  blank-screen.
    05  blank screen.

01  verification-screen-1.
    05  line 24 col 60  value "ACCEPT (Y/N/M) ".

01  verification-screen-2.
*   05  line 24 col 58  value "ACCEPT (Y/N/M/D) ".
*   05  line 24 col 56  value "ACCEPT (Y/N/M/D/P) ".
    05  line 24 col 54  value "ACCEPT (Y/N/M/D/P/S) ".

01  scr-verification.
    05  line 24 col 75  pic x   using flag-accept.

01  scr-reject-entry.
    05  line 24 col 50  value "ENTRY IS ".
    05  line 24 col 59  value "REJECTED"        bell blink.

01  ring-bell.
    05  line 24 col 01  value " " bell.
*
01   scr-confirm        line 23 col 1 pic x using confirm-space auto.


01  scr-title-batch-control-data.
    05  blank screen.
    05  line 01 col 01 value is "D001A".
    05  line 01 col 31 value is "CLAIMS BATCH DATA ENTRY".
*y2k
*   05  line 01 col 73 pic 99 using sys-yy.
    05  line 01 col 71 pic 9(4) using sys-yy.
    05  line 01 col 75 value "/".
    05  line 01 col 76 pic 99 using sys-mm.
    05  line 01 col 78 value "/".
    05  line 01 col 79 pic 99 using sys-dd.
*
01  scr-old-or-new-batch-option.

    05  line 03 col 29 value "1 -CREATE NEW BATCH".
    05  line 04 col 29 value "2 -CONTINUE EXISTING BATCH".
    05  line 06 col 36 value "OPTION -".
    05  scr-option      line 06 col 45 pic x to option auto required highlight.
*
01  scr-claim-source.
    05                  line 07 col 01 value
                "CLAIM SOURCE - ORIGINAL 'S'OURCE DOCUMENT / 'C'OMPUTER GENERATED MATERIAL:".
    05                  line 07 col 76 pic x(01) using def-claim-source auto highlight.

01  scr-acpt-batch-type.

    05                  line 09 col 01 value "BATCH TYPE  :".
    05  scr-batch-type  line 09 col 15 pic x using batctrl-batch-type auto highlight.
*
01  scr-acpt-batch-nbr.

    05                  line 10 col 01 value "BATCH NUMBER:".
    05  scr-acpt-clinic-nbr-1-2
                        line 10 col 15 pic  99  using batctrl-bat-clinic-nbr-1-2
                                                           auto highlight.
    05  scr-acpt-doc-nbr
*!                        line 10 col 18 pic 999  using batctrl-bat-doc-nbr  auto highlight.
                        line 10 col 18 pic xxx  using batctrl-bat-doc-nbr  auto highlight.
*
01  scr-dis-week-day.

    05  scr-acpt-week-day line 10 col 22 pic  999       using batctrl-bat-week-day-r    auto blink highlight.
* 2010/07/13 - MC11 - dept got displayed the second digit only instead of both digits
*    05  scr-clear-dept  line 10 col 25 value "    ".
    05  scr-clear-dept  line 10 col 25 value "   ".
* 2010/07/13 - end


01  scr-acpt-dept-nbr.

    05                  line 10 col 22 value "DEPT:".
    05  scr-acpt-dept   line 10 col 28 pic 99 using ws-hold-screen-dept auto blank when zero highlight.

01  scr-acpt-doc-name.

    05                  line 10 col 31 value "(".
    05  scr-disp-inits  line 10 col 32 pic xxx from doc-inits           auto.
    05  scr-disp-name   line 10 col 36 pic x(24) from doc-name            auto.
    05                  line 10 col 61 value ")".

01  scr-acpt-spec-cd.

    05                  line 11 col 01 value "SPECIALTY CD:".
    05  scr-acpt-spec
                        line 11 col 15 pic 99 using ws-doc-spec-cd
                                                auto highlight.
01  scr-val-batch-period-cycle.

    05                  line 10 col 30 value "PERIOD END DATE".
    05  scr-period-ends-yy
*y2k
*                       line 10 col 46 pic 99 using batctrl-date-period-end-yy
                        line 10 col 46 pic 9(4) using batctrl-date-period-end-yy
                                                auto highlight.
    05                  line 10 col 50 value "/".
    05  scr-period-ends-mm
                        line 10 col 51 pic 99 using batctrl-date-period-end-mm
                                        auto highlight.
    05                  line 10 col 53 value "/".
    05  scr-period-ends-dd
                        line 10 col 54 pic 99 using batctrl-date-period-end-dd
                                        auto highlight.
    05                  line 10 col 60 value "CYCLE NUMBER".
    05  scr-cycle-nbr   line 10 col 73 pic 99 using batctrl-cycle-nbr
                                        auto highlight.
*
01  scr-acpt-mask.

    05                          line 13 col 01 value "CLINIC NUMBER..:".
    05  scr-batctrl-clinic-nbr  line 13 col 18 pic zzzz using batctrl-clinic-nbr auto highlight.
    05                          line 15 col 01 value "DOCTOR NUMBER..:".
*!    05  scr-batctrl-doc-nbr     line 15 col 18 pic zzz using batctrl-bat-doc-nbr auto highlight.
    05  scr-batctrl-doc-nbr     line 15 col 18 pic xxx using batctrl-bat-doc-nbr auto highlight.
    05                          line 17 col 01 value "LOCATION.......:".
    05  scr-batctrl-loc         line 17 col 18 pic a999 using batctrl-loc auto highlight.
    05                          line 19 col 01 value "AGENT CODE.....:".
    05  scr-batctrl-agent-cd    line 19 col 18 pic 9 using batctrl-agent-cd auto highlight.
    05                          line 21 col 01 value "IN/OUT PATIENT.:".
    05  scr-batctrl-i-o-pat-ind line 21 col 18 pic x using batctrl-i-o-pat-ind auto highlight.
    05                          line 23 col 01 value "PAYROLL........:".
    05  scr-batctrl-payroll     line 23 col 18 pic x using batctrl-payroll auto highlight.
*
01  scr-lit-batctrl-data.

    05                  line 11 col 41 value "- BATCH CONTROL INFORMATION -".
    05                  line 13 col 31 value "ESTIMATED $ AMOUNT =".
    05                  line 15 col 31 value "ACTUAL    $ AMOUNT =".
    05                  line 15 col 64 value "OUT BY".
    05                  line 18 col 31 value "ESTIMATED SVC COUNT =".
    05                  line 20 col 31 value "ACTUAL    SVC COUNT =".
    05                  line 20 col 64 value "OUT BY".
*
01  scr-batctrl-estimates.

    05  scr-amt-est-input
                        line 13 col 52 pic zz,zz9.99- to batctrl-amt-est
                                        auto.
    05  scr-svc-est-input
                        line 18 col 53 pic z,zz9 to batctrl-svc-est
                                        auto.
*
01  scr-val-batctrl-data.

    05  scr-amt-est
                        line 13 col 52 pic zz,zz9.99- using batctrl-amt-est.
    05  scr-amt-act
                        line 15 col 52 pic zz,zz9.99- using batctrl-amt-act.
    05  scr-amt-diff
                        line 15 col 71 pic zz,zz9.99- using ws-batctrl-amt-diff.
    05  scr-svc-est
                        line 18 col 53 pic z,zz9 using batctrl-svc-est.
    05  scr-svc-act
                        line 20 col 53 pic z,zz9 using batctrl-svc-act.
    05  scr-svc-diff
                        line 20 col 72 pic z,zz9 using ws-batctrl-svc-diff.
*
01  scr-acpt-change-verification.

    05                  line 22 col 28 value "CHANGE BATCH CONTROL".
    05                  line 22 col 49 value "INFORMATION (Y/N)".
    05                  line 22 col 68 pic x to change-reply auto highlight.

01  scr-acpt-change-password.
    05                  line 22 col 69 value "PASSWORD".
    05                  line 22 col 78 pic xxx to password-input
                                                        auto secure highlight.

01  scr-closing-screen-1.
    05  blank screen.
    05  line  5 col 20  value "# OF BATCH CONTROL  READS    =".
    05  line  5 col 55  pic 9(7) from ctr-read-batctrl-mstr.
    05  line  6 col 20  value "# OF CLAIMS MASTER  READS    =".
    05  line  6 col 55  pic 9(7) from ctr-read-claims-mstr.
    05  line  7 col 20  value "# OF PATIENT MSTR   READS    =".
    05  line  7 col 55  pic 9(7) from ctr-read-pat-mstr.
01  scr-closing-screen-2.
    05  line  8 col 20  value "# OF DOCTOR MSTR    READS    =".
    05  line  8 col 55  pic 9(7) from ctr-read-doc-mstr.
    05  line  9 col 20  value "# OF LOCATION MSTR  READS    =".
    05  line  9 col 55 pic 9(7) from ctr-read-loc-mstr.
    05  line 10 col 20  value "# OF OMA FEE MSTR   READS    =".
    05  line 10 col 55 pic 9(7) from ctr-read-oma-mstr.
01  scr-closing-screen-3.
    05  line 11 col 20  value "# OF CONSTANTS MSTR READS    =".
    05  line 11 col 55 pic 9(7) from ctr-read-const-mstr.
    05  line 12 col 20  value "# OF MSG SUB MSTR READS      =".
    05  line 12 col 55 pic 9(7) from ctr-read-msg-sub-mstr.
    05  line 13 col 20  value "# OF BATCH CONTROL WRITES    =".
    05  line 13 col 55  pic 9(7) from ctr-writ-batctrl-file.
    05  line 14 col 20  value "# OF CLAIMS MASTER WRITES    =".
    05  line 14 col 55  pic 9(7) from ctr-writ-claims-mstr.
    05  line 15 col 20  value "# OF CORRECTE PAT  WRITES    =".
    05  line 15 col 55  pic 9(7) from ctr-write-corrected-pat.
01  scr-closing-screen-4.
    05  line 15 col 20  value "# OF BATCH CONTROL RE-WRITES =".
    05  line 15 col 55  pic 9(7) from ctr-rewrit-batctrl-file.
    05  line 21 col 20  value "PROGRAM D001 ENDING".
*y2k
*   05  line 21 col 40  pic 99  from sys-yy.
    05  line 21 col 38  pic 9(4)  from sys-yy.
    05  line 21 col 42  value "/".
    05  line 21 col 43  pic 99  from sys-mm.
    05  line 21 col 45  value "/".
    05  line 21 col 46  pic 99  from sys-dd.
    05  line 21 col 50  pic 99  from sys-hrs.
    05  line 21 col 52  value ":".
    05  line 21 col 53  pic 99  from sys-min.
procedure division.
declaratives.

err-batctrl-mstr-file section.
    use after standard error procedure on batch-ctrl-file.

err-batctrl-file.
    move status-cobol-batctrl-file              to status-common.
    display file-status-display.
    display "ERROR IN ACCESSING BATCH CONTROL FILE".
    move spaces                         to continue-reply.
    perform za1-make-them-notice-error  thru    za1-99-exit
                until continue-reply = "!".



err-claims-mstr-file section.
    use after standard error procedure on claims-mstr.

err-claims-mstr.
    move status-cobol-claims-mstr       to status-common.
    display file-status-display.
    display "COBOL - ERROR IN ACCESSING CLAIMS MASTER".
    move spaces                         to continue-reply.
    perform za1-make-them-notice-error  thru    za1-99-exit
                until continue-reply = "!".
    move status-cobol-claims-mstr       to status-common.
    display file-status-display.
    display "COBOL - ERROR IN ACCESSING CLAIMS MASTER".
    move spaces                         to continue-reply.
    perform za1-make-them-notice-error  thru    za1-99-exit
                until continue-reply = "!".



err-pat-mstr-file section.
    use after standard error procedure on pat-mstr.
err-pat-mstr.

*   move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.
*   move status-cobol-pat-mstr                to status-common.
*   display file-status-display.
    move status-cobol-pat-mstr1           to status-cobol-display1.
    if   status-cobol-pat-mstr1 <> 9
    then
        move status-cobol-pat-mstr2       to status-cobol-display2
    else
        move low-values                   to status-cobol-pat-mstr1
        move status-cobol-pat-mstr-binary to status-cobol-display2.
*   endif

    if status-cobol-pat-mstr1 <> 0
    then
        display "Patient error = ", status-cobol-display.
*   endif


    move spaces                         to continue-reply.
    perform za1-make-them-notice-error  thru    za1-99-exit
                until continue-reply = "!".


*mf err-hc-pat-mstr-file section.
*mf     use after standard error procedure on hc-pat-mstr.
*mf err-hc-pat-mstr.

*mf    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.
*mf    move status-cobol-pat-mstr-hc                          to status-common.
*mf    display file-status-display.

*mf    move spaces                      to continue-reply.
*mf    perform za1-make-them-notice-error  thru         za1-99-exit
*mf             until continue-reply = "!".

*mf err-od-pat-mstr-file section.
*mf    use after standard error procedure on od-pat-mstr.
*mf err-od-pat-mstr.

*mf    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.
*mf    move status-cobol-pat-mstr-od    to status-common.
*mf    display file-status-display.

*mf    move spaces                      to continue-reply.
*mf    perform za1-make-them-notice-error  thru za1-99-exit
*mf             until continue-reply = "!".

*mf err-chrt-pat-mstr-file section.
*mf    use after standard error procedure on chrt-pat-mstr.
*mf err-chrt-pat-mstr.

*mf    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.
*mf    move status-cobol-pat-mstr-chrt                        to status-common.
*mf    display file-status-display.

*mf    move spaces                      to continue-reply.
*mf    perform za1-make-them-notice-error  thru         za1-99-exit
*mf             until continue-reply = "!".

*mf err-acr-pat-mstr-file section.
*mf    use after standard error procedure on acr-pat-mstr.
*mf err-acr-pat-mstr.

*mf    move "ERROR IN ACCESSING PATIENT MASTER -- KEY =" to ws-file-err-msg.
*mf    move status-cobol-pat-mstr-acr                         to status-common.
*mf    display file-status-display.

*mf    move spaces                      to continue-reply.
*mf    perform za1-make-them-notice-error  thru         za1-99-exit
*mf             until continue-reply = "!".

err-doc-mstr-file section.
    use after standard error procedure on doc-mstr.

err-doc-mstr.
    move status-cobol-doc-mstr          to status-common.
    display file-status-display.
    display "ERROR IN ACCESSING DOCTOR MASTER".
    move spaces                         to continue-reply.
    perform za1-make-them-notice-error  thru za1-99-exit
                until continue-reply = "!".


err-oma-fee-mstr-file section.
    use after standard error procedure on oma-fee-mstr.

err-oma-fee-mstr.
    move status-cobol-oma-mstr          to status-common.
    display file-status-display.
    display "ERROR IN ACCESSING OMA FEE MASTER".
    move spaces                         to continue-reply.
    perform za1-make-them-notice-error  thru za1-99-exit
                until continue-reply = "!".

err-constants-mstr-file section.
    use after standard error procedure on iconst-mstr.

err-constants-mstr.
*   (if 'record locked' print warning, set flag so that 'read' will loop until record unlocked)
    if status-iconst-mstr = "7015"
    then
        move 15                         to      err-ind
        perform za0-common-error        thru    za0-99-exit
        move "Y"                        to      flag-lock
    else
        move status-iconst-mstr         to      status-common
        display file-status-display
        display "ERROR IN ACCESSING CONSTANTS MASTER"
        move spaces                     to continue-reply
        perform za1-make-them-notice-error      thru za1-99-exit
                        until continue-reply = "!".
*   endif.



err-diagnostics-mstr-file section.
    use after standard error procedure on diag-mstr.

err-diagnostics-mstr.
    move status-diag-mstr               to status-common.
    display file-status-display.
    display "ERROR IN ACCESSING DIAGNOSTIC CODES MASTER".
    move spaces                         to continue-reply.
    perform za1-make-them-notice-error  thru za1-99-exit
                until continue-reply = "!".


    copy "f094_msg_sub_mstr.ds".

end declaratives.
main-line section.
mainline.

*==*==*==*==*==*==*==*==*==*
*       job initialization
*       ---
*==*==*==*==*==*==*==*==*==*

    accept sys-date                     from date.
    perform y2k-default-sysdate		thru y2k-default-sysdate-exit.
    move sys-mm                         to run-mm.
    move sys-dd                         to run-dd.
    move sys-yy                         to run-yy.

    move sys-yy                         to temp-yyyy.
    move temp-yy			to expiry-test-to-date-yy.
    move sys-mm                         to expiry-test-to-date-mm.

    accept sys-time                     from time.
    move sys-hrs                        to run-hrs.
    move sys-min                        to run-min.
    move sys-sec                        to run-sec.

    display scr-title-batch-control-data.

    open i-o    batch-ctrl-file
                claims-mstr
                pat-mstr
* 2004/02/19 - MC
	        pat-elig-history
* 2004/02/19 - end
*mf             hc-pat-mstr
*mf             od-pat-mstr
*mf             chrt-pat-mstr
*mf             acr-pat-mstr
* 2010/06/21 - MC9
		rejected-claims
* 2010/06/21 - end
                doc-mstr.

    open input  oma-fee-mstr
                diag-mstr
*mf             pat-mstr
                loc-mstr
                iconst-mstr
* 2011/05/19 - MC20
                sli-oma-code-suff-mstr
* 2011/05/19 - end
                msg-sub-mstr.

    open extend corrected-pat.

*==*==*==*==*==*==*==*==*==*==*
*       batch initialization
*       -----
*==*==*==*==*==*==*==*==*==*==*

mainline-process-next-batch.

    move 0                              to ws-batctrl-amt-act.
    move 0                              to nbr-of-services.

    perform zh0-initialization          thru    zh0-99-exit.


*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==**
*       process next batch if end of job not indicated
*               ---- -----
*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==**

    if not stop-option
    then
*       (obtain pricing constant's values from rec 2 of constants master)
        move 2                          to      iconst-clinic-nbr-1-2
        perform uj1-read-isam-const-mstr thru   uj1-99-exit
        if not-ok
        then
            move 21                     to      err-ind
            perform za0-common-error    thru    za0-99-exit
            go to mainline-shutdown
        else
            move "N"                    to      flag-eoj
            perform ab0-processing      thru    ab0-99-exit
            perform zz0-end-of-batch    thru    zz0-99-exit
            go to mainline-process-next-batch
*       endif
    else
        next sentence.
*   endif

*==*==*==*==*==*==*==*==
*       end of job
*              ---
*==*==*==*==*==*==*==*==

mainline-shutdown.

    display blank-screen.

    close       batch-ctrl-file
                claims-mstr
                pat-mstr
*mf             hc-pat-mstr
*mf             od-pat-mstr
*mf             chrt-pat-mstr
*mf             acr-pat-mstr
                doc-mstr
                loc-mstr
                oma-fee-mstr
                iconst-mstr
                corrected-pat
* 2004/02/19 - MC
		pat-elig-history
* 2004/02/19 - end
* 2010/06/21 - MC9
		rejected-claims 
* 2010/06/21 - end
* 2011/05/19 - MC20 
                sli-oma-code-suff-mstr
* 2011/05/19 - end

                diag-mstr
                msg-sub-mstr.

*
*   call program "$obj/menu".
    chain "$obj/menu".

    stop run.
ab0-processing.

    perform uk0-zero-claim-hold-area    thru uk0-99-exit.

*       (preset data common between batctrl and clmhdr recs)

    move batctrl-batch-nbr              to clmhdr-batch-nbr
                                           clmhdr-orig-batch-nbr.
    move zero                           to clmhdr-zeroed-oma-suff-adj.
    move batctrl-batch-type             to clmhdr-batch-type.
    move batctrl-doc-nbr-ohip           to clmhdr-doc-nbr-ohip.
    move batctrl-loc                    to clmhdr-loc of claim-header-rec.
    move batctrl-agent-cd               to clmhdr-agent-cd.
    move batctrl-date-period-end        to clmhdr-date-period-end.
    move batctrl-cycle-nbr              to clmhdr-cycle-nbr.
    move batctrl-i-o-pat-ind            to clmhdr-i-o-pat-ind.
* 2010/07/12 - MC11
    move batctrl-payroll		to clmhdr-payroll.
* 2010/07/12 - end

    move "Y"                            to first-diag-cd.
    move "N"                            to flag-no-verif.

    move spaces                         to clmhdr-pat-ohip-id-or-chart of claim-header-rec
                                           clmhdr-confidential-flag
                                           clmhdr-manual-review
****                                           clmhdr-hosp
*mf                                        ws-pat-mstr-rec
                                           ws-scr-health-nbr
                                           hold-version-cd
                                           name-change-flag
                                           last-claim-flag.

*2002/04/08 - MC
    move spaces				to ws-ohip-chart-flag.
*2002/04/08 - end


    move zeros                          to clmhdr-refer-doc-nbr
                                           clmhdr-diag-cd
                                           clmhdr-date-admit
                                           claim-nbr-serv
                                           ws-pat-health-nbr
                                           ws-pat-ohip-mmyy
                                           ws-pat-mstr-rec
*mf zeros instead of spaces for hold values
                                           hold-last-birth-yy
                                           hold-last-birth-mm
                                           hold-last-birth-dd
                                           hold-last-elig-maint-yy
                                           hold-last-elig-maint-mm
                                           hold-last-elig-maint-dd
                                           hold-last-elig-mail-yy
                                           hold-last-elig-mail-mm
                                           hold-last-elig-mail-dd.

*       (maximum number of claims allowed in any batch is 99)

    if batctrl-last-claim-nbr > 98
    then
        display scr-acpt-clmhdr
        move 52                         to err-ind
        perform za0-common-error        thru za0-99-exit
        move "E"                        to flag-eoj
        go to ab0-99-exit.
*   (else)
*   endif

    if batctrl-nbr-claims-in-batch not numeric
    then
        move zero                       to      batctrl-nbr-claims-in-batch.
*   (else)
*   endif

    add 1                               to      batctrl-nbr-claims-in-batch.
    add 1 , batctrl-last-claim-nbr      giving batctrl-last-claim-nbr
                                               clmhdr-claim-nbr
                                               clmhdr-orig-claim-nbr.

*       (read claims master for claim-nbr about to be created --
*        if claim already exists then print error and shut down batch)

    move batctrl-batch-nbr              to clmhdr-batch-nbr.
    move batctrl-last-claim-nbr         to clmhdr-claim-nbr.
    move zeros                          to clmhdr-zeroed-oma-suff-adj.
*mf move clmhdr-claim-id                to key-clm-data.
*mf move "B"                            to key-clm-key-type.
    move clmhdr-claim-id                to clmdtl-b-data.
    move "B"                            to clmdtl-b-key-type.

    perform ai0-read-claims-mstr        thru    ai0-99-exit.
    if  ok
    then
*       (claim # already exists -- shut down batch with message to re-number remaining claims)
        perform ab1-subtract-1-from-claim-nbr   thru ab1-99-exit
        display ring-bell
        display ring-bell
        display ring-bell
        display ring-bell
        display ring-bell
        move 53                         to err-ind
        perform za0-common-error        thru za0-99-exit
        move "E"                        to flag-eoj
* 2007/03/15 - MC
*       (2006/sep/30 b.e. clear file containing batch in progress)
        open output d001-batch-in-progress
	close       d001-batch-in-progress
* 2007/03/15 - end
        go to ab0-99-exit.
*   (else)
*   endif

    move "N"                            to flag-accept.

ab0-10-enter-claim.

    perform ca0-acpt-hdr-data           thru    ca0-99-exit.
*   if eoj
*   if last-claim-flag = '**'
    if last-claim = '*'
    then
        go to ab0-99-exit.
*  (else)
*   endif

ab0-20-enter-claim-details.

    move "Y"                            to      flag-err-data.
    perform va0-acpt-dtl                thru    va0-99-exit.

    if err-data
    then
        go to ab0-10-enter-claim.
*   (else)
*   endif

    move 1                              to ss-basic-times-desc-rec.
    move 0                              to ss-basic-times.

    perform ya0-price-claim             thru	ya0-99-exit.

    if ss-basic-times = 0
    then
        subtract  1                     from ss-basic-times-desc-rec.
*   (else)
*   endif

    if flag-no-verif = "N"
    then
   	move "N"				     to flg-omacd-possible-addon-found
   	move "N"				     to flg-diag-possible-addon-found
   	move "N"				     to flg-addon-possible-addon-found
        perform la3-check-4-missing-addon-cd	thru la3-99-exit
                varying   ss
                from       1
                by         1
* 2010/05/27 - MC6 - Brad slipped on this one
*                until ss > 8
                until ss > 10
   	if        ( flg-omacd-possible-addon-found =  "Y"
	    	and flg-diag-possible-addon-found  =  "Y"
	        and flg-addon-possible-addon-found not = "Y")
   	   or     ( flg-omacd-possible-addon-found =  "Y"
	    	and flg-diag-possible-addon-found  not =  "Y"
	        and flg-addon-possible-addon-found =  "Y")
* 2011/04/11 - MC18 - add the third condtition
* 2011/05/19 - MC20 - user requested to remove third condition
*   	   or     ( flg-omacd-possible-addon-found not =  "Y"
*	        and flg-addon-possible-addon-found =  "Y")
* 2011/05/19 - end
* 2011/04/11 - end
 	then
	    move 111 				to err-ind
	    perform za0-common-error            thru za0-99-exit.
*	else
*	endif
*   endif

* 2008/04/30 - MC - oma code edit check from 'd001_newu701_oma_code_edit.rtn'
    if flag-no-verif = "N"
    then
* 2011/05/19 - MC20  

	perform  ab0a-oma-code-reset		thru ab0a-99-exit

* 2011/05/19 - end

* 2010/09/23 - MC14 
	move 0    	 to ws-sv-date-c1
			    ws-sv-date-c2.
* 2010/09/23 - end

        perform la4-oma-code-edit              	thru la4-99-exit
                varying   ss-clmdtl-oma
                from       1
                by         1
*		(brad1 - allow 10 details lines per screen) 
*                until ss-clmdtl-oma > 8
                until ss-clmdtl-oma > 10
        perform la5-oma-code-edit-check		thru la5-99-exit.
*   endif

* 2008/04/30 - end

ab0-25-enter-claim-desc.

*       (update ctr of nbr of description recs with # of 'basic + times' recs)
    move ss-basic-times-desc-rec        to ss-clmdtl-desc.

    if report-desc-required
    then
        add 1                           to ss-clmdtl-desc
	move "REPORT"                   to hold-desc(ss-clmdtl-desc)
        display scr-acpt-det-desc
    else
	if adjudication-desc-required
	then
	    add 1			 to ss-clmdtl-desc
* 2005/08/16 - MC
*	    move "REFER TO ADJUDICATION" to hold-desc(ss-clmdtl-desc)
	    move "G259A BILLED AT 85%"   to hold-desc(ss-clmdtl-desc)
* 2005/08/16 - end
            display scr-acpt-det-desc.
*	endif
*   endif

* 2008/04/30 - MC  - percentage visit preimium

* 2010/10/04 - MC15 - disable the edit check below

*     if        ws-annna = 'Y'
*        and    ws-gnnna = 'Y'
*        and    ws-k991-u997 = 'Y'
*     then
*        add 1                           to ss-clmdtl-desc
*	move "Pay visit premium"        to hold-desc(ss-clmdtl-desc)
*        display scr-acpt-det-desc
*        move 'Y'                        to clmhdr-manual-review
*        add 1                           to ss-clmdtl-desc
*        move "based on 'A---A' code"    to hold-desc(ss-clmdtl-desc) 
*        display scr-acpt-det-desc.
*       endif
*    endif

* 2010/10/04 - end

* 2008/04/30 - end

    perform la0-acpt-clmdtl-desc        thru la0-99-exit.

ab0-30-accept-verification.

    move "2"                            to flag.

    perform ma0-acpt-verification       thru ma0-99-exit.

    if flag-accept = "M"
    then
*       go to ab0-10-enter-claim
        perform ca0-acpt-hdr-data       thru ca0-99-exit
        go to ab0-30-accept-verification
    else
        if flag-accept = "D"
        then
            move "M"                    to flag-accept
            go to ab0-20-enter-claim-details
        else
            if flag-accept = "R"
            then
                go to ab0-25-enter-claim-desc
            else
                if flag-accept = "P"
                then
                    perform ab2-scr-acpt-pat thru ab2-99-exit
                    go to ab0-30-accept-verification
                else
                if flag-accept = "N"
                then
                    display scr-reject-entry
                    display confirm
                    accept confirm
                    display blank-line-24
                    perform ab1-subtract-1-from-claim-nbr   thru ab1-99-exit
                    go to ab0-processing
                else
                    if flag-accept = "S"
                    then
                        accept scr-last-claim
                        go to ab0-30-accept-verification
                    else
                    if flag-accept not = "Y"
                    then
*                       (invalid character input and not edited out -- re-enter)
                        go to ab0-30-accept-verification.
*                   (else)
*                   endif
*               endif
*           endif
*       endif
*     endif
*   endif

*    (reply = 'Y' - accepted - write out claim -- head rec followed by detail recs)

ab0-35-nbr-serv-check.

* 2008/05/05 - MC
    move ss-hold-clmdtl-oma		to ss-clmdtl-oma.
* 2008/05/05 - end

    move zero                           to claim-nbr-serv.
    move ss-clmdtl-oma                  to save-clmdtl-oma.
    perform ga9-sum-clmdtl-serv         thru ga9-99-exit
        varying ss-det-nbr from 1 by 1
         until  ss-det-nbr > ss-clmdtl-oma.

    if nbr-of-services not equal claim-nbr-serv
    then
        move 77                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to ab0-30-accept-verification.
*   endif

*   (ensure that confidentially flag and manual review flag and associated
*    description records are in sync) 
    perform ga1-check-for-confidentiality thru ga1-99-exit.

*   (if flag was set then ensure that an appropriate description record exists,
*    or create appropriate description record if necessary)
    if clmhdr-confidential-flag = "Y"
    then
	move "N"				to flag-confidential-desc-rec
        perform gc1-find-confidential-desc-rec	thru gc1-99-exit
                varying  ss-desc
                from 1 by 1
                until    ss-desc    > ss-clmdtl-desc
        if confidential-desc-not-found 
        then
            if ss-clmdtl-desc < ss-max-nbr-of-desc-rec-allow 
	    then
	        add 1				to            ss-clmdtl-desc
	        move "NO VERIFICATION PLEASE"	to  hold-desc(ss-clmdtl-desc)
	    else
*	        (max desc recs already defined - overwrite last one with msg)
*		SHOULD BE A WARNING HERE BUT NOT YET CODED !!!!!!!!
	        move "NO VERIFICATION PLEASE"	to  hold-desc(ss-clmdtl-desc)
*	    endif
	else
	    next sentence
*	endif
    else
	next sentence.
*   endif

* 2013/12/05 - MC35 - check if referring doctor is required
    move 'N'                            to flag-refer-doc. 
    perform ga2-check-refer-doc-needed  thru ga2-99-exit
        varying ss-det-nbr from 1 by 1
         until  ss-det-nbr > ss-clmdtl-oma.

*   if refer doc not require but keyer has entered one, then blank it out
    if refer-doc-not-require and clmhdr-refer-doc-nbr not = zeroes
    then
	move zeroes			to clmhdr-refer-doc-nbr.
*   endif

* 2013/12/05 - end
    move save-clmdtl-oma                to ss-clmdtl-oma.

    perform na0-write-clmhdr            thru na0-99-exit.

    move spaces                         to clmdtl-desc-rec.

*    (preset clmdtl rec data which is common to clmhdr rec data)
    perform zl2-preset-clmdtl-data       thru zl2-99-exit.

    move 0                              to ws-tot-claim-nbr-sv.
    perform pa0-write-clmdtl            thru pa0-99-exit
                varying  ss-det-nbr
                from 1 by 1
                until    ss-det-nbr > ss-clmdtl-oma.

    perform ra0-write-clmdtl-desc       thru ra0-99-exit
*mf             varying  ss-det-nbr
                varying  ss-desc
                from 1 by 1
*mf             until    ss-det-nbr > ss-clmdtl-desc.
                until    ss-desc    > ss-clmdtl-desc.

*   if there is an eligibiltiy changes on birth and/or version cd,
*   create a corrected pat record

    if elig-flag = 'Y'
    then
* 2004/02/19 - MC
*       (update f011 patient eligibility history information)
        perform yy0-process-pat-elig-change
                                     thru  yy0-99-exit

**        write pat-id-rec
**        add 1                   to ctr-write-corrected-pat
* 2004/02/19 - end
* 2010/06/21 - MC1
	  perform yy3-update-rejected-claim   thru    yy3-99-exit
* 2010/06/21 - end

          	move "N"                to elig-flag.
*   endif

*   if name has changed, create new acronym and delete the old one

    if name-change-flag = 'Y'
    then
*mf     move pat-old-surname    to ws-pat-surname
*mf     move pat-old-given-name to ws-pat-given-name
*mf     move old-acronym        to ws-pat-acronym
        perform ta0-update-patient-rec thru ta0-99-exit
*mf     perform ua1-delete-old-acronym thru ua1-99-exit
        perform ua0-create-new-acronym thru ua0-99-exit
    else
*       (re-write patient mstr with updated rec)
        perform ta0-update-patient-rec   thru ta0-99-exit.
*   endif

*    (update batch balancing '# of services' and 'dollar amt' totals)
    add ws-tot-claim-nbr-sv             to batctrl-svc-act,
                                           batctrl-svc-est.
    add clmhdr-tot-claim-ar-oma         to batctrl-amt-act,
                                           batctrl-amt-est.
    add clmhdr-tot-claim-ar-ohip        to batctrl-calc-ar-due
                                           batctrl-calc-tot-rev.
*   endif


    go to ab0-processing.


ab0-99-exit.
    exit.

* 2011/05/19 - MC20 
ab0a-oma-code-reset.

copy "d001_newu701_oma_code_variables_reset.rtn".

ab0a-99-exit.
    exit.

* 2011/05/19 - end




ab1-subtract-1-from-claim-nbr.

    subtract 1                          from    batctrl-nbr-claims-in-batch.

    subtract 1                          from    batctrl-last-claim-nbr
                                        giving  batctrl-last-claim-nbr
                                                clmhdr-claim-nbr
                                                clmhdr-orig-claim-nbr.
ab1-99-exit.
    exit.


ab2-scr-acpt-pat.

    move 'N'                            to elig-flag, name-change-flag.

ab2-acpt-version-cd.

    display scr-acpt-version-cd.
    accept  scr-acpt-version-cd.

* MC44
    if ws-pat-version-cd not = spaces
    then
	move 0				to  err-ind
*       (upshift version code if lower case)
        perform dd0-check-version-cd     thru dd0-99-exit
        display scr-acpt-version-cd
	if err-ind not = 0    
	then 	
	    perform za0-common-error	thru za0-99-exit
	    go to ab2-acpt-version-cd.
*       endif
* MC44 - end

ab2-acpt-expiry-date.

    display scr-acpt-expiry-yy.
    accept  scr-acpt-expiry-yy.

    display scr-acpt-expiry-mm.
    accept  scr-acpt-expiry-mm.


   if ws-pat-expiry-date = '0000'
    then
        next sentence
    else
        if ws-pat-expiry-mm < 1
        or ws-pat-expiry-mm > 12
        then
            move 75                     to err-ind
            perform za0-common-error    thru za0-99-exit
            go to ab2-acpt-expiry-date.
*       endif
*   endif

ab2-acpt-name.

    display scr-acpt-last-name.
    accept  scr-acpt-last-name.
    display scr-acpt-given-name.
    accept  scr-acpt-given-name.

ab2-verify-birth-date.

    display scr-acpt-birth-yy.
    accept  scr-acpt-birth-yy.
*y2k (default century of date, if not entered)
    if ws-pat-birth-date-yy <> zeros
    then
	move ws-pat-birth-date-yy           to      century-year
	perform y2k-add-century-to-year     thru    y2k-99-exit
	move century-year                   to      ws-pat-birth-date-yy.
*   endif

*       (validate yy entered)
*y2k below code uncommented to activiate - check with yas
* brad -check with yas
*   if   ws-pat-birth-date-yy > sys-yy
*   then
*       move 73         to err-ind
*       perform za0-common-error        thru za0-99-exit
*       go to ab2-verify-birth-date.
*   (else)
*   endif

    display scr-acpt-birth-mm.
    accept  scr-acpt-birth-mm.
    display scr-acpt-birth-dd.
    accept  scr-acpt-birth-dd.

    move "Y"                            to flag.
    if   ws-pat-birth-date-mm < 01
      or ws-pat-birth-date-mm > 12
    then
        move "N"                        to flag
    else
        if   ws-pat-birth-date-dd < 01
          or ws-pat-birth-date-dd > max-nbr-days (ws-pat-birth-date-mm)
        then
            move "N"                    to flag.
*   endif

    if not-ok
    then
        move 5                          to err-ind
        perform za0-common-error        thru za0-99-exit
        go to ab2-verify-birth-date.
*   (else)
*   endif

* brad - check with yas
*       (invalid if birth-date > current system date)
*   if ws-pat-birth-date > sys-date
*   then
*       move 74                 to err-ind
*       perform za0-common-error        thru za0-99-exit
*       go to ab2-verify-birth-date.
*   (else)
*   endif

ab2-acpt-subscr-addr.

    display scr-acpt-subscr-addr1.
    accept  scr-acpt-subscr-addr1.

    display scr-acpt-subscr-addr2.
    accept  scr-acpt-subscr-addr2.

    display scr-acpt-subscr-addr3.
    accept  scr-acpt-subscr-addr3.

    perform ac0-city-prov-check thru ac0-99-exit.

    display scr-acpt-postal-code.
    accept  scr-acpt-postal-code.

* 2002/06/17 - MC - drop country
*    if ws-pat-prov-cd = 'XX'
*   then
*       display scr-acpt-country
*       accept  scr-acpt-country.
* 2002/06/17 - end


*   determine if user has changed the name

    if    ws-pat-surname not = pat-old-surname
       or ws-pat-given-name not = pat-old-given-name
    then
        move 'Y'                to name-change-flag
        move ws-pat-acronym     to old-acronym
        move ws-pat-surname     to new-pat-surname, new-pat-surname6
        move ws-pat-given-name  to new-pat-given-name, new-pat-given-name3.
*   endif

*   determine if user has changed birth date or version cd

*y2k
* brad - look at this code !!!1
    if ws-pat-birth-date not = hold-pat-birth-date
    then
        move 'Y'                	to elig-flag
	move hold-pat-birth-date	to ws-pat-last-birth-date.

*	(y2k - code removed when date changed to regular 9(8) format)
*       compute hold-date rounded = (hold-pat-birth-yy * 512) +
*                                   (hold-pat-birth-mm * 32) +
*                                    hold-pat-birth-dd
*       move hold-date                  to special-date
*       move spec-date-2                to ws-pat-last-birth-date-r.
*   endif

    if ws-pat-version-cd not = hold-version-cd
    then
        move 'Y'                to elig-flag
        move hold-version-cd    to ws-pat-last-version-cd.
*   endif

    if elig-flag = 'Y'
    then
*y2k
*       compute hold-date rounded = (sys-yy * 512) +
*                                   (sys-mm * 32 ) +
*                                    sys-dd
*       move hold-date                   to special-date
*       move spec-date-2                 to ws-pat-date-last-elig-maint-r
	move sys-date			 to pat-date-last-elig-maint

        move spaces                      to ws-pat-mess-code
        move zero                        to ws-pat-no-of-letter-sent
        move clmhdr-pat-ohip-id-or-chart of claim-header-rec
                to clmhdr-pat-ohip-id-or-chart of pat-id-rec
        move ws-pat-last-birth-date
                to pat-last-birth-date of pat-id-rec
        move ws-pat-last-version-cd
                to pat-last-version-cd of pat-id-rec.
* brad check in debug if above code ok
*   endif


ab2-99-exit.
    exit.




ac0-city-prov-check.

    move 1                              to subs-table-addr.

ac0-10-check-addr-loop.

    if ws-subscr-addr3 = city-prov-short (subs-table-addr)
    then
        move city-prov-name (subs-table-addr)
                                        to ws-subscr-addr3
        display scr-acpt-subscr-addr3
    else
        add 1                           to subs-table-addr
        if subs-table-addr > max-nbr-addr
        then
            next sentence
        else
            go to ac0-10-check-addr-loop.
*       endif
*   endif

ac0-99-exit.
    exit.

ai0-read-claims-mstr.

    move zero                           to      claims-occur
                                                feedback-claims-mstr.

    read claims-mstr    into claim-header-rec     key is key-claims-mstr
        invalid key
                move "N"                to      flag
                go to ai0-99-exit.

    move "Y"                            to      flag.
    add  1                              to      ctr-read-claims-mstr.

ai0-99-exit.
    exit.
ba1-verify-mm-dd.

    move "Y"                            to flag.

    if   ws-mm < 1
      or ws-mm > 12
    then
        move "N"                        to flag
    else
        if   ws-dd < 1
          or ws-dd > max-nbr-days (ws-mm)
        then
            move "N"                    to flag.
*   endif

ba1-99-exit.
    exit.

ca0-acpt-hdr-data.

    if   flag-accept = 'M'
      or flag-accept = 'D'
      or flag-accept = 'R'
      or flag-accept = 'P'
    then
        next sentence
    else
*       ( clear header data for blank re-display )
        move zero                       to clmhdr-refer-doc-nbr
                                           clmhdr-diag-cd
                                           clmhdr-msg-nbr
                                           clmhdr-sub-nbr
                                           clmhdr-date-admit
                                           ws-pat-health-nbr

**        move spaces                     to clmhdr-hosp
	move spaces			to clmhdr-pat-acronym6
                                           ws-pat-mstr-rec
                                           ws-pat-ohip-mmyy
                                           ws-pat-version-cd
                                           ws-scr-health-nbr
                                           clmhdr-confidential-flag
*                                          last-claim-flag
        move 1                          to nbr-of-services
*       move zeroes to ws-pat-ohip-nbr
*                ws-pat-mm
*       move zeroes to
*                ws-pat-yy
*!        move zeroes to
        move spaces   to
                 ws-pat-last-doc-nbr-seen
        move zeroes to
                 ws-pat-birth-date
        move zeroes to
                 ws-pat-date-last-maint
        move zeroes to
                 ws-pat-date-last-visit
        move zeroes to
                 ws-pat-date-last-admit
        move zeroes to
                 ws-pat-phone-nbr
        move zeroes to
                 ws-pat-total-nbr-visits
        move zeroes to
                 ws-pat-total-nbr-claims
        move zeroes to
                 ws-pat-nbr-outstanding-claims
        move zeroes to
                 ws-pat-health-nbr
        move zeroes to
                 ws-pat-expiry-mm
        move zeroes to
                 ws-pat-expiry-yy
        move zeroes to
                 ws-subscr-dt-msg-no-eff-to
        move zeroes to
                 ws-subscr-date-last-statement
        move zeroes to
                 ws-pat-date-last-elig-mailing
        move zeroes to
                 ws-pat-date-last-elig-maint
        move zeroes to
                 ws-pat-last-birth-date
        move zeroes to
                ws-pat-birth-date-yy
        move zeroes to
                ws-pat-birth-date-mm
        move zeroes to
                ws-pat-birth-date-dd
        move zeroes to
                hold-last-birth-yy
        move zeroes to
                hold-last-birth-mm
        move zeroes to
                hold-last-birth-dd
        move zeroes to
                 ws-pat-no-of-letter-sent
        move zeros to ws-pat-birth-date-yy
        move zeros to ws-pat-birth-date-mm
        move zeros to ws-pat-birth-date-dd
        move zeros to hold-last-elig-maint-yy
        move zeros to hold-last-elig-maint-mm
        move zeros to hold-last-elig-maint-dd
        move zeros to hold-last-elig-mail-yy
        move zeros to hold-last-elig-mail-mm
        move zeros to hold-last-elig-mail-dd
        perform ca11-zero-variables thru        ca11-99-exit
                varying ss
                from   1
                by     1
*	(brad1 - allow 10 detail lines per screen)
*                until  ss > 8
                until  ss > 10
        display scr-acpt-clmhdr
*brad 
*display scr-acpt-clmhdr-century-dates
*mf     display scr-acpt-clmhdr-2
*mf     display scr-acpt-clmhdr-3
        display scr-acpt-pat-surname
        display blank-detail-lines
*S.B.
*        move zeros to   ws-highest-grp-nbr.
*        move zeros to   ws-highest-grp-tot.
*        display scr-acpt-det-desc.
        move zeros to   ws-highest-grp-nbr
        move zeros to   ws-highest-grp-tot
        display scr-acpt-det-desc.
*S.B.

*   endif

*       (accept claim header info)

*   perform fa0-acpt-admit-date         thru fa0-99-exit.

ca0-acpt-last-claim-flag.

*   move spaces                         to last-claim-flag.

    display scr-last-claim-lit.
    accept  scr-last-claim.

*   (check for end of job indicator)

*   if last-claim-flag = ' ' or '**'
    if last-claim = '*'  or last-claim is numeric
    then
        next sentence
    else
        move 76                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to ca0-acpt-last-claim-flag.
*   endif

*   if last-claim-flag = '**'
    if last-claim = '*'
    then
        perform ab1-subtract-1-from-claim-nbr   thru ab1-99-exit
*       (2006/sep/30 b.e. clear file containing batch in progress)
        open output d001-batch-in-progress
	close       d001-batch-in-progress
        go to ca0-99-exit.
*  (else)
*   endif

ca0-10-input-health-nbr.

    accept scr-pat-health-nbr.


*mf if ws-scr-health-nbr not = " "
    if ws-scr-health-nbr not = " " and ws-scr-health-nbr not = zeroes
    then
        if ws-scr-health-nbr is alphabetic
        then
            move "Y"                            to flag
*mf         move ws-scr-health-nbr              to acr-pat-acronym
            move ws-scr-health-nbr              to     pat-acronym
            perform da7-read-acr-pat-mstr-approx thru da7-99-exit
            go to ca0-30-invalid-pat
        else
            move ws-scr-health-nbr              to ws-pat-health-nbr
            move ws-pat-health-nbr                 to ws-chk-nbr-10
            perform db0a-mod10-check-digit-10       thru db0a-99-exit
            if ok
            then
                move "Y"                                to flag
*mf             move ws-pat-health-nbr          to hc-pat-health-nbr
* 2004/02/19 - MC
*                move ws-pat-health-nbr          to    pat-health-nbr
                move ws-pat-health-nbr          to    pat-health-nbr of pat-mstr
* 2004/02/19 - end
                perform da4-read-hc-pat-mstr    thru da4-99-exit
                go to ca0-30-invalid-pat
            else
                move 69                             to err-ind
                perform za0-common-error            thru za0-99-exit
                go to ca0-10-input-health-nbr.
*           endif
*   endif

ca0-20-input-id-chart.

*       (zero patient id if first pass thru logic)
    if flag-accept not = "M"
    then
*mf     move zero                       to ws-pat-ohip-mmyy.
        move spaces                     to ws-pat-ohip-mmyy.
*   (else)
*   endif

    perform da0-acpt-id-access-pat-subscr       thru da0-99-exit.

*   (pdr #458 - only allow ohip # = 11111119 if agent = "alternative funding')
    if ws-pat-ohip-nbr-r-alpha  =  "11111119"
    then
        if not def-agent-alternate-funding
        then
            move 26                             to err-ind
            move "N"                            to flag
        else
            next sentence
*       endif

*   copy "d001_ca0_20.rtn".
* 2001/may/14 M.C. - correct edit for all sites

    else     
	if    (   (    not def-agent-ifhp-direct
		   and not def-agent-ontario-direct
		   and not def-agent-foreign-direct
		   and not def-agent-quebec-direct
                   and site-id = "HSC"
	          )
	        or site-id = "RMA"
	      )
	  and 
	      (   ws-pat-ohip-nbr = spaces
               or ws-pat-ohip-nbr = zeros  
	      )
          and ws-pat-health-nbr = 0     
      then
          move 85                     to err-ind
          perform za0-common-error    thru za0-99-exit
          move "M"                    to flag-accept
  	  move zeros		      to ws-pat-health-nbr
          go to ca0-acpt-hdr-data.
*     endif
*  endif     
     
* 2006/sep/25 - MC - check exclusively for HSC
	if    (   	def-agent-reciprocal  
	          and	ws-pat-prov-cd =  'ON'   
                  and 	site-id = "HSC"
	      )
      then
          move 115                    to err-ind
          perform za0-common-error    thru za0-99-exit
          go to ca0-acpt-hdr-data.
*     endif
* 2006/sep/25 - end

* 2007/aug/02 - MC - check exclusively for HSC
	if    (   	def-agent-alternate-funding
	          and	ws-pat-prov-cd not =  'ON'   
                  and 	site-id = "HSC"
	      )
      then
          move 117                    to err-ind
          perform za0-common-error    thru za0-99-exit
          go to ca0-acpt-hdr-data.
*     endif
* 2007/aug/02 - end

ca0-30-invalid-pat.

    if not-ok
    then
*       (error -- no such patient found,
*                or surname input by keyer doesn't match patient's surname --
*         -- 'err-ind' set in 'ca0-10', 'da0' or 'ea0' indicates the error)
        perform za0-common-error        thru za0-99-exit
        display scr-acpt-patient-verif
        perform ca2-verify-new-err-pat  thru ca2-99-exit
        if err-patient
        then
            move spaces                 to reply-create-pat
            display scr-clear-pat-verif
*           display scr-pat-surname-lit
            move " "                    to ws-scr-health-nbr
            display scr-pat-health-nbr
            go to ca0-10-input-health-nbr
        else
           if new-patient
           then
                display scr-clear-pat-verif
                go to ca0-acpt-hdr-data
           else
                if request-pgm-m010
                then
                    display scr-loading-message
*==                 close corrected-pat
*mf change call to CLI into unix SYSTEM cll
                    move "quick auto=$pb_obj/m010.qkc" to macro
                    call "SYSTEM" using macro-line
*==                 open extend corrected-pat
                    display scr-title-claim-rec-data
                    display scr-last-claim-lit
                    display scr-claim-lit
                    display scr-acpt-clmhdr
*brad
*	    display scr-acpt-clmhdr-century-dates
                    display scr-acpt-det-desc
                    go to ca0-10-input-health-nbr
                else
                    next sentence.
*               endif
*           endif
*       endif
*   endif

    perform ca1-display-pat-info        thru ca1-99-exit.

*    copy "d001_ca0_30.rtn".
*       (if agent code is 'ohip' then the patient must have an ohip nbr
*        or health nbr)
*   (sms #113 - treat agent 4 as direct bill)

    if   def-agent-ohip
      or def-agent-alternate-funding
      or (    def-agent-ohip-wcb
          and site-id = "RMA"
	 ) 
    then
        if   (    (   ws-pat-ohip-nbr  not numeric
                   or ws-pat-ohip-nbr  = zeroes)
              and ws-pat-health-nbr = 0
              and (    ws-pat-prov-cd not = "NT"
                   and ws-pat-prov-cd not = "MB")
             )
          or (    (   ws-pat-ohip-nbr-MB  not numeric
                   or ws-pat-ohip-nbr  = zeroes)
              and ws-pat-health-nbr = 0
              and ws-pat-prov-cd  = "MB"
             )
          or (    (   ws-pat-ohip-nbr-NT  not numeric
                  or ws-pat-ohip-nbr  = zeroes)
              and ws-pat-ohip-nbr-NT-1-char <> "N"
              and ws-pat-ohip-nbr-NT-1-char <> "D"
              and ws-pat-ohip-nbr-NT-1-char <> "M"
              and ws-pat-ohip-nbr-NT-1-char <> "T"
              and ws-pat-health-nbr = 0
              and ws-pat-prov-cd = "NT"
             )
        then
            move 14                     to err-ind
            perform za0-common-error    thru za0-99-exit
            move "M"                    to flag-accept
            go to ca0-acpt-hdr-data
        else
            display scr-pat-health-nbr
*       endif
    else
        next sentence.
*   endif

*   (do not allow to enter claims with 'PQ' prov cd and it is ohip or wcb)
    if   def-agent-ohip
      or def-agent-alternate-funding
      or (    def-agent-ohip-wcb
          and site-id = "RMA"
         ) 
      and ws-pat-prov-cd not = "NT"
    then
        if ws-pat-prov-cd = 'PQ'
            move 65                     to err-ind
            perform za0-common-error    thru za0-99-exit
            go to ca0-acpt-hdr-data
        else
            move ws-pat-expiry-yy       to hc-expiry-date-yy
            move ws-pat-expiry-mm       to hc-expiry-date-mm
            if    ws-pat-expiry-date not = '0000'
              and hc-expiry-date < expiry-test-to-date
              and ws-pat-prov-cd = 'ON'
            then
                move 66                 to err-ind
                perform za0-common-error    thru za0-99-exit
                go to ca0-acpt-hdr-data.
*           endif
*       endif
*   endif

    move ws-key-pat-mstr                to clmhdr-pat-ohip-id-or-chart
                                                of claim-header-rec
                                           clmhdr-p-data
                                           clmdtl-p-data.

*   (preset patient surname and allow operator to override if not correct patient)
    move ws-pat-surname-first6          to clmhdr-pat-acronym6.
    display scr-clmhdr-pat-surname.
    perform ea0-acpt-pat-surname        thru ea0-99-exit.

*       (if first 6 chars of surname input don't match pat on file then error)
    if not-ok
    then
        go to ca0-30-invalid-pat.
*   (else)
*   endif

    move ws-pat-acronym                 to clmhdr-pat-acronym.

*   (display payroll)
    display scr-payroll.

    perform ga0-acpt-refer-doc          thru ga0-99-exit.
    perform ia0-acpt-loc                thru ia0-99-exit.
    perform ja0-acpt-hosp               thru ja0-99-exit
    perform ka0-acpt-i-o-pat-ind        thru ka0-99-exit.
    perform fa0-acpt-admit-date         thru fa0-99-exit.
*   perform laa-acpt-manual-review      thru laa-99-exit.

*   (sms #113 - treat agent 4 as direct bill)
    if   def-agent-bill-direct
      or def-agent-foreign-direct
      or def-agent-ifhp-direct
      or def-agent-ontario-direct
      or def-agent-quebec-direct
    then
        perform ca5-acpt-msg            thru ca5-99-exit
        perform ca6-acpt-sub            thru ca6-99-exit.
*   endif

*   2010/07/12 - MC11 - enter value 1 to 5 on payroll field for dept 41 or 42 or 43 or 75
    if site-id = 'RMA' 
    then 
        perform laa-acpt-payroll	thru laa-99-exit.
*   endif
*   2010/07/12 - end

ca0-99-exit.
    exit.


ca1-display-pat-info.

    move spaces                                 to pat-id-rec.
    move ws-pat-surname                         to pat-old-surname.
    move ws-pat-given-name                      to pat-old-given-name.
    move ws-pat-health-nbr                      to pat-old-health-nbr.
    move ws-pat-chart-nbr                       to pat-old-chart-nbr.
    move ws-subscr-addr1                        to pat-old-addr1.
    move ws-subscr-addr2                        to pat-old-addr2.
    move ws-subscr-addr3                        to pat-old-addr3.

* 2004/02/25 - MC - include chart-nbr-2 to 5 as well
    move ws-pat-chart-nbr-2                       to pat-old-chart-nbr-2.
    move ws-pat-chart-nbr-3                       to pat-old-chart-nbr-3.
    move ws-pat-chart-nbr-4                       to pat-old-chart-nbr-4.
    move ws-pat-chart-nbr-5                       to pat-old-chart-nbr-5.
* 2004/02/25 - end

    move ws-pat-birth-date                      to hold-pat-birth-date.
    move ws-pat-version-cd                      to hold-version-cd.

* brad check code ok to comment out
* (y2k)
    if ws-pat-last-birth-date not = 0
    then
	move ws-pat-last-birth-date	to hold-last-birth-date.
*       move ws-pat-last-birth-date     to hold-date
*       if   ws-pat-last-birth-date < 0
*       then
*            subtract hold-date from 65536 giving hold-date
*       end-if
*       divide hold-date by 512 giving hold-last-birth-yy
*               remainder rem1
*       divide rem1 by 32 giving hold-last-birth-mm
*               remainder hold-last-birth-dd.
*       endif

    if ws-pat-date-last-elig-maint not = 0
    then
    	move ws-pat-date-last-elig-maint 	to hold-last-elig-maint-date.
*       move ws-pat-date-last-elig-maint        to hold-date
*       if   ws-pat-date-last-elig-maint < 0
*       then
*            subtract hold-date from 65536 giving hold-date
*       end-if
*       divide hold-date by 512 giving hold-last-elig-maint-yy
*               remainder rem1
*       divide rem1 by 32 giving hold-last-elig-maint-mm
*               remainder hold-last-elig-maint-dd.
*       endif


    if ws-pat-date-last-elig-mailing not = 0
    then
        move ws-pat-date-last-elig-mailing      to hold-last-elig-mail-date.
*       move ws-pat-date-last-elig-mailing      to hold-date
*       if   ws-pat-date-last-elig-mailing < 0
*       then
*            subtract hold-date from 65536 giving hold-date
*       end-if
*       divide hold-date by 512 giving hold-last-elig-mail-yy
*               remainder rem1
*       divide rem1 by 32 giving hold-last-elig-mail-mm
*               remainder hold-last-elig-mail-dd.
*       endif

*mf (hold-last-birth-date contains blanks - can't determine where
*mf  it gets set so added check here - B.E. 98.Jan.20)
    if hold-last-birth-date not numeric
    then
        move zero                       to   hold-last-birth-date.
*   endif

* (y2k - removed duplicate definition of patient info and moved to clmhdr info)
*   display scr-pat-info.
    display scr-acpt-clmhdr.
*   display scr-acpt-clmhdr-century-dates.

ca1-99-exit.
    exit.

ca11-zero-variables.
        move zeros to hold-sv-date-yy(ss)
        move zeros to hold-sv-date-mm(ss)
        move zeros to hold-sv-date-dd(ss)

        move zeros to hold-sv-nbr-serv(ss)

        move zeros to hold-sv-nbr(ss,1)
        move zeros to hold-sv-nbr(ss,2)
        move zeros to hold-sv-nbr(ss,3)

        move zeros to hold-fee-oma (ss)
        move zeros to hold-fee-ohip(ss)
        move zeros to hold-flag-sec-group(ss).

ca11-99-exit.
    exit.

ca2-verify-new-err-pat.

    accept scr-clmhdr-pat-verif.

    if   new-patient
      or err-patient
      or request-pgm-m010
    then
        next sentence
    else
        move 1                          to err-ind
        perform za0-common-error        thru za0-99-exit
        go to ca2-verify-new-err-pat.

ca2-99-exit.
    exit.

ca5-acpt-msg.

    accept scr-msg-nbr.

    if clmhdr-msg-nbr not = zero
    then
        move msg-indexer                        to msg-sub-key-1
        move clmhdr-msg-nbr                     to msg-sub-key-23
        perform ca7-read-msg-sub-mstr           thru ca7-99-exit
        if msg-sub-missing
        then
            move 56                             to err-ind
            perform za0-common-error            thru za0-99-exit
            go to ca5-acpt-msg
        else
            move msg-reprint-flag               to clmhdr-reprint-flag
    else
        move 'Y'                                to clmhdr-reprint-flag.
*   endif

ca5-99-exit.

    exit.

ca6-acpt-sub.

    accept scr-sub-nbr.

    move sub-indexer                    to msg-sub-key-1.
    move space                          to msg-sub-key-2.
    move clmhdr-sub-nbr                 to msg-sub-key-3.

    perform ca7-read-msg-sub-mstr       thru ca7-99-exit.

    if msg-sub-missing
    then
        move 57                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to ca6-acpt-sub
    else
        move sub-fee-complex            to clmhdr-fee-complex
        move sub-auto-logout            to clmhdr-auto-logout.
*   endif

ca6-99-exit.

    exit.

ca7-read-msg-sub-mstr.

    read msg-sub-mstr
        invalid key
            move "N"                    to flag-msg-sub
            go to ca7-99-exit.

    move "Y"                            to flag-msg-sub.
    add 1                               to ctr-read-msg-sub-mstr.

ca7-99-exit.
    exit.

da0-acpt-id-access-pat-subscr.

*   accept scr-acpt-id-chart.

*2002/04/08 - MC - accept prefix
    if site-id = 'RMA'
    then
*       move spaces 		to ws-ohip-chart-flag 
        move '$'    		to ws-ohip-chart-flag 
        accept scr-ohip-chart-flag
        if ws-ohip-chart-flag = ' ' or '*'
        then
	    go to da0-99-exit
        else
 	if ws-ohip-chart-flag = '!' or '$'
	then
	    next sentence
	else
	    move 108			to err-ind
	    perform za0-common-error	thru za0-99-exit
	    go to da0-acpt-id-access-pat-subscr.
*	endif
*   endif

*2002/04/08 - end


    accept scr-clmhdr-ohip-chart.

*   (if no id was entered skip validation of patient and return to calling
*    logic which will catch error)
    if (   ws-pat-ohip-nbr = spaces
        or ws-pat-ohip-nbr = zeros)
    then
        go to da0-99-exit.
*   endif

    move spaces                           to flag-valid-ohip-or-chart.

    perform da1-chk-if-chart-or-valid-ohip      thru da1-99-exit.

*   if     ( qhip  and  (invalid-ohip or invalid-mmyy) )
*     or  (invalid-chart)
    if  invalid-chart
    then
        move 13                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to da0-acpt-id-access-pat-subscr.
*   (else)
*   endif

*   (note - subscr and pat mstr share same buffer area - subscr mstr read first,
*    data stored in working-storage and then patient rec read into area)
    move "Y"                                    to flag.
    move zero                                   to err-ind.

*   copy "d001_da0.rtn".
    if direct or qhip
    then
*       (access direct bill or ohip key)
*mf     move ws-pat-ohip-mmyy                   to od-pat-ohip-mmyy
        move ws-pat-ohip-mmyy                   to    pat-ohip-mmyy
        perform da5-read-od-pat-mstr            thru da5-99-exit
* 2002/06/17 - MC
	go to da0-99-exit
* 2002/06/17 - end
    else
        if chart
*       (access chart key)
        then
* 2002/06/17 - MC 
	    if site-id = 'RMA'
	    then
		perform da61-read-chrt-pat-mstr	thru da61-99-exit
	    else
* 2002/06/17 - end

*mf         move ws-pat-ohip-mmyy               to chrt-pat-chart-nbr
            move ws-pat-ohip-mmyy               to      pat-chart-nbr
* 2002/06/17 - MC
*            perform da6-read-chrt-pat-mstr      thru da6-99-exit
            perform da6-read-chrt-pat-mstr      thru da6-99-exit.
*	    endif
* 2002/06/17 - end


*           (if agent 'ohip' then check if patient identified by 'chart
*            nbr' has a valid 'ohip' key)

*   (sms #113 - treat agent 4 as direct bill)
            if   def-agent-ohip
              or def-agent-alternate-funding
              or (    def-agent-ohip-wcb
		  and site-id = "RMA"
		 ) 
            then
                if    (   (site-id = "HSC"
			  )
	 	       or (    ( pat-ohip-mmyy =   zero
                                             or spaces
			       )
		    	    and site-id = "RMA"
			  )
	    	       )
* 2004/02/19 - MC
*                   and  pat-health-nbr = 0
                   and  pat-health-nbr of pat-mstr-rec = 0
* 2004/02/19 - end
                then
                    move 14                     to err-ind
                    move "N"                    to flag
                else
                    display scr-pat-health-nbr.
*               endif
*           endif
*       endif
*   endif

da0-99-exit.
    exit.

*copy "d001_da1.rtn".
*   (if its not ohip or chart then error. - sms 98 by m.s.)
*   (if it's not ohip or chart or direct then error - sms 138 by m.c.)
da1-chk-if-chart-or-valid-ohip.     
    
*2002/04/08 - MC
    if site-id = 'RMA'
    then
 	if ws-ohip-chart-flag = '!'
	then
	    move "O"			to flag-ohip-vs-chart
            move "Y"                    to flag-valid-ohip-or-chart     
	    go to da1-99-exit
	else
        if ws-ohip-chart-flag = '$'
    	then
	    move "C"		        to flag-ohip-vs-chart
            move "Y"                    to flag-valid-ohip-or-chart     
	    go to da1-99-exit.
*	endif
*   endif

*2002/04/08 - end

 
    if ws-pat-direct-alpha is alphabetic     
    then     
        move "D"                        to flag-ohip-vs-chart     
*                                          key-pat-key-type     
*       move pat-ohip-mmyy              to key-pat-o-c-a     
        move "Y"                        to flag-valid-ohip-or-chart     
    else     
        if ws-pat-alpha1 = "*"     
        then     
            move "N"                    to flag-valid-ohip-or-chart     
        else     
            move zero                   to c-1     
            inspect ws-pat-ohip-mmyy tallying c-1 for all " "     
            if ws-pat-alpha1 is alphabetic     
                and (  (    c-1 < 7     
		        and site-id = "RMA"
		       )
		     or (    c-1 = 7     
		         and site-id = "HSC"
			)
	            )
            then     
                move "C"                to flag-ohip-vs-chart     
            else     
                move "O"                to flag-ohip-vs-chart.     
*           endif     
*       endif.     
*    endif.     
     
da1-99-exit.     
    exit. 


da4-read-hc-pat-mstr.

*mf read hc-pat-mstr into ws-pat-mstr-rec
    read    pat-mstr into ws-pat-mstr-rec
* 2004/02/19 - MC
*        key is pat-health-nbr
        key is pat-health-nbr of pat-mstr
* 2004/02/19 - end
        invalid key
            move 16                     to err-ind
            move "N"                    to flag
            go to da4-99-exit.

    add  1                              to ctr-read-pat-mstr.
    move feedback-pat-mstr-hc           to save-feedback-pat-mstr.
*mf move hc-pat-health-nbr              to ws-scr-health-nbr.
* 2004/02/19 - MC
*    move    pat-health-nbr              to ws-scr-health-nbr.
    move    pat-health-nbr of pat-mstr-rec              to ws-scr-health-nbr.
* 2004/02/19 - end

da4-99-exit.
    exit.

da5-read-od-pat-mstr.

*mf read od-pat-mstr into ws-pat-mstr-rec
    read    pat-mstr into ws-pat-mstr-rec
        key is pat-ohip-mmyy
        invalid key
            move 16                     to err-ind
            move "N"                    to flag
            go to da5-99-exit.

    add  1                              to ctr-read-pat-mstr.
    move feedback-pat-mstr-od           to save-feedback-pat-mstr.
*mf move od-pat-health-nbr              to ws-scr-health-nbr.
* 2004/02/19 - MC
*    move    pat-health-nbr              to ws-scr-health-nbr.
    move    pat-health-nbr of pat-mstr-rec              to ws-scr-health-nbr.
* 2004/02/19 - end

da5-99-exit.
    exit.

da6-read-chrt-pat-mstr.
*mf read chrt-pat-mstr into ws-pat-mstr-rec
    read      pat-mstr into ws-pat-mstr-rec
        key is pat-chart-nbr
        invalid key
            move 16                     to err-ind
            move "N"                    to flag
            go to da6-99-exit.

    add  1                              to ctr-read-pat-mstr.
    move feedback-pat-mstr-chrt         to save-feedback-pat-mstr.
*mf move chrt-pat-health-nbr            to ws-scr-health-nbr.
* 2004/02/19 - MC
*    move    pat-health-nbr              to ws-scr-health-nbr.
    move    pat-health-nbr of pat-mstr-rec              to ws-scr-health-nbr.
* 2004/02/19 - end

da6-99-exit.
    exit.

* 2002/06/17 - MC - determine which chart nbr index to be read
da61-read-chrt-pat-mstr.

    if ws-pat-alpha1 = 'M'
    then
       move ws-pat-ohip-mmyy            to pat-chart-nbr
       read      pat-mstr into ws-pat-mstr-rec
        key is pat-chart-nbr
        invalid key
            move 16                     to err-ind
            move "N"                    to flag
            go to da61-99-exit
    else
    if ws-pat-alpha1 = 'K'
    then
       move ws-pat-ohip-mmyy            to pat-chart-nbr-2
       read      pat-mstr into ws-pat-mstr-rec
        key is pat-chart-nbr-2
        invalid key
            move 16                     to err-ind
            move "N"                    to flag
            go to da61-99-exit
     else
    if ws-pat-alpha1 = 'H'
    then
       move ws-pat-ohip-mmyy            to pat-chart-nbr-3
       read      pat-mstr into ws-pat-mstr-rec
        key is pat-chart-nbr-3
        invalid key
            move 16                     to err-ind
            move "N"                    to flag
            go to da61-99-exit
    else
    if ws-pat-alpha1 = 'J'
    then
       move ws-pat-ohip-mmyy            to pat-chart-nbr-5
       read      pat-mstr into ws-pat-mstr-rec
        key is pat-chart-nbr-5
        invalid key
            move 16                     to err-ind
            move "N"                    to flag
            go to da61-99-exit
    else
       move ws-pat-ohip-mmyy            to pat-chart-nbr-4
       read      pat-mstr into ws-pat-mstr-rec
        key is pat-chart-nbr-4
        invalid key
            move 16                     to err-ind
            move "N"                    to flag
            go to da61-99-exit.
*   endif

    add  1                              to ctr-read-pat-mstr.
    move feedback-pat-mstr-chrt         to save-feedback-pat-mstr.
* 2004/02/19 - MC
*    move    pat-health-nbr              to ws-scr-health-nbr.
    move    pat-health-nbr of pat-mstr-rec              to ws-scr-health-nbr.
* 2004/02/19 - end

da61-99-exit.
    exit.
* 2002/06/17 - end


da7-read-acr-pat-mstr-approx.
    move 0                              to pat-occur-acr.
    move 0                              to feedback-pat-mstr-acr.
*mf move acr-pat-acronym                to ws-hold-acronym.
    move     pat-acronym                to ws-hold-acronym.
*mf read acr-pat-mstr key is acr-pat-acronym approximate
    start    pat-mstr
        key is greater than or equal to    pat-acronym
        invalid key
*mf             move 49                 to err-ind
                move "N"                to flag
                go to da7-99-exit.

    read     pat-mstr
        key is  pat-acronym
        invalid key
*mf             move 49                 to err-ind
                move "N"                to flag
                go to da7-99-exit.

da7-not-dialysis.

*mf if acr-pat-acronym  not = ws-hold-acronym
    if     pat-acronym  not = ws-hold-acronym
    then
        move 49                         to err-ind
        move "N"                        to flag
        go to da7-99-exit
    else
*mf     if acr-dialysis = "Y"
        if pat-dialysis = "Y"
        then
*mf         move acr-pat-mstr-rec       to ws-pat-mstr-rec
            move     pat-mstr-rec       to ws-pat-mstr-rec
            move ws-pat-health-nbr      to ws-scr-health-nbr
            go to da7-99-exit
        else
*mf         read acr-pat-mstr next
            read     pat-mstr next
                at end
*mf                 move 49             to err-ind
                    move 81             to err-ind
                    move "N"            to flag
                    go to da7-99-exit.
*       endif.
*    endif.

    go to da7-not-dialysis.

da7-99-exit.
    exit.
    copy "db0_mod10_check_digit.rtn".

    copy "db0a_mod10_check_digit_10.rtn".

*  (this subroutine is added on 88/11/01 by m.s. - sms 109)
copy "dc0_mod10_check_digit_alt.rtn".

* MC44
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
        move 183                        to err-ind.
* endif

dd0-99-exit.
    exit.

*MC44 - end

ea0-acpt-pat-surname.

    accept scr-clmhdr-pat-surname.

    if clmhdr-pat-acronym6 not = ws-pat-surname-first6
    then
*       (error msg printed from calling routine)
        move 27                         to err-ind
        move "N"                        to flag
    else
        move "Y"                        to flag.

ea0-99-exit.
    exit.


fa0-acpt-admit-date.

*y2k (default century in date, if not entered)
*   accept scr-clmhdr-date-admit-yy.
    accept scr-clmhdr-date-admit-yy-12.
    if clmhdr-date-admit-yy-12 <> zeros
    then
	if clmhdr-date-admit-yy-12 = "19" or = "20"
	then
*	    (assume user is entering full 4 digit year)
	    accept scr-clmhdr-date-admit-yy-34
	else
*	    (default the century for year and take what they entered
*	     as the lower order 2 digits)
	    move clmhdr-date-admit-yy-12	to   clmhdr-date-admit-yy-34
	    move zeros				to   clmhdr-date-admit-yy-12
 	    move clmhdr-date-admit-yy           to   century-year
	    perform y2k-add-century-to-year     thru y2k-99-exit
	    move century-year                   to   clmhdr-date-admit-yy
*	endif	    
*   endif

    display scr-clmhdr-date-admit-yy-12
    display scr-clmhdr-date-admit-yy-34.


* 2006/09/18 - MC - check for RMA only

   if 	site-id = 'RMA'
     and clmhdr-clinic-nbr-1-2 > "60"
* 2010/03/30 - include clinic 66
*     and clmhdr-clinic-nbr-1-2 < "66"
     and clmhdr-clinic-nbr-1-2 < "67"
* 2010/03/31 - end
* 2008/06/03 - MC - inclue M549 or M558
*     and clmhdr-loc = 'M500'
     and (clmhdr-loc of claim-header-rec = 'M500' or 'M549' or 'M558')
* 2008/06/03 - end  
     and clmhdr-i-o-pat-ind = 'I'
     and clmhdr-date-admit = zeroes    
   then
	move 114 		to err-ind
	perform za0-common-error	thru za0-99-exit
	go to fa0-acpt-admit-date.
*  endif    

* 2006/09/18 - end

* 2007/07/16 - MC - check for RMA only

   if 	site-id = 'RMA'
     and clmhdr-clinic-nbr-1-2 > "70"
     and clmhdr-clinic-nbr-1-2 < "76"
* 2008/06/03 - MC - inclue M549 or M558
*     and clmhdr-loc = 'M500'
     and (clmhdr-loc of claim-header-rec = 'M500' or 'M549' or 'M558')
* 2008/06/03 - end  
     and clmhdr-i-o-pat-ind = 'I'
     and clmhdr-date-admit = zeroes    
   then
	move 116 		to err-ind
	perform za0-common-error	thru za0-99-exit
	go to fa0-acpt-admit-date.
*  endif    

* 2006/07/16 - end

*   (zero admit date allowed at this point - as oma cds entered if they
*    require non-zero admit date date then it will be asked for again)
*y2k
*   if clmhdr-date-admit-yy    = '00'
    if clmhdr-date-admit-yy-12 = '00'
    then
        move zero                       to clmhdr-date-admit
        display scr-clmhdr-date-admit-yy-12
        display scr-clmhdr-date-admit-yy-34
        display scr-clmhdr-date-admit-mm
        display scr-clmhdr-date-admit-dd
        go to fa0-99-exit.
*   (else)
*   endif

*   (validate yy entered)
*y2k
*   if   clmhdr-date-admit-yy < 32
*     or clmhdr-date-admit-yy > sys-yy
    if   clmhdr-date-admit-yy > sys-yy
    then
        move 6		                to err-ind
        perform za0-common-error        thru za0-99-exit
        go to fa0-acpt-admit-date.
*       (else)
*       endif
*   endif

    accept scr-clmhdr-date-admit-mm.
    accept scr-clmhdr-date-admit-dd.

    move clmhdr-date-admit              to ws-date.
    perform ba1-verify-mm-dd            thru ba1-99-exit.
    if not-ok
        move 5                          to err-ind
        perform za0-common-error        thru za0-99-exit
        go to fa0-acpt-admit-date.
*   (else)
*   endif

*   (invalid if admit-date > current system date)
    if clmhdr-date-admit > sys-date
    then
        move 6		                to err-ind
        perform za0-common-error        thru za0-99-exit
        go to fa0-acpt-admit-date.
*   (else)
*   endif

* 2004/04/07 - MC
*   (invalid if admit-date >  birth date)
    if clmhdr-date-admit < ws-pat-birth-date
    then
        move 109                        to err-ind
        perform za0-common-error        thru za0-99-exit
        go to fa0-acpt-admit-date.
*   (else)
*   endif
* 2004/04/07 - end

fa0-99-exit.
    exit.
ga0-acpt-refer-doc.

*       (if referring doc # not 0 then validate it according to a mod 10
*        check digit routine --


    accept scr-clmhdr-refer-doc.

*   if    clmhdr-clinic-nbr-1-2 > "59" - pdr 561 by mc
* 2007/07/16 - MC - also check for clinic 71 to 75
*    if    clmhdr-clinic-nbr-1-2 > "60" and clmhdr-clinic-nbr-1-2 < "66"

* 2010/03/31 - MC5 - include clinic 66 as part of clinic 60's
*    if   (    (clmhdr-clinic-nbr-1-2 > "60" and clmhdr-clinic-nbr-1-2 < "66")
    if   (    (clmhdr-clinic-nbr-1-2 > "60" and clmhdr-clinic-nbr-1-2 < "67")
* 2010/03/30 - end
          or  (clmhdr-clinic-nbr-1-2 > "70" and clmhdr-clinic-nbr-1-2 < "76")
	 )
* 2007/07/16 - end
      and clmhdr-refer-doc-nbr = 0
    then
        move doc-ohip-nbr       to clmhdr-refer-doc-nbr
        display scr-clmhdr-refer-doc.
*   endif

*   if clmhdr-doc-nbr = 0 - commented on 93/03/08 by m.c.
    if clmhdr-refer-doc-nbr = 0
    then
        go to ga0-99-exit
    else
        move clmhdr-refer-doc-nbr       to ws-chk-nbr
        if ws-chk-nbr-8 =    1
                         or  2
        then
            perform dc0-mod10-check-digit-for-1-2  thru dc0-99-exit
         else
            perform db0-mod10-check-digit       thru db0-99-exit.
*        endif
*   endif


    if not-ok
    then
        move 84                         to err-ind
        perform za0-common-error        thru za0-99-exit.
*	      if continue-reply = "*"
*	      then
*	          go to ga0-acpt-refer-doc.
*   (else)
*   endif


*  pdr 481 - 91/04/26 by m.c.

* 2013/07/31 - MC32 - comment out the below edit
**  if    clmhdr-clinic-nbr-1-2 = '22'
**      and clmhdr-refer-doc-nbr = doc-ohip-nbr
* 2013/06/17 - MC29
**      and flag-refer-doc-needed-G-codes <> 'Y'
* 2013/06/17 - end
**    then
**        move 67                         to err-ind
**        perform za0-common-error        thru za0-99-exit
**        go to ga0-acpt-refer-doc.
*   endif
** 2013/07/31 - end

* 2013/06/17 - MC29
    if flag-refer-doc-needed-G-codes = 'Y' 
      and  clmhdr-refer-doc-nbr = 0
    then
	move doc-ohip-nbr		to clmhdr-refer-doc-nbr
        display scr-clmhdr-refer-doc.
*   endif
* 2013/06/17 - end

ga0-99-exit.
    exit.

* (this performs the routine "ga1-check-for-confidentiality" to set
* "Y"es for ministry confidentially and "R" for RMA purposes)
* 2000/may/26 - change rules for setting confidentially flag (now set
* both "Y"es for OHIP and "R" for RMA confidentially checking)
*    copy "d001_d003_confidentiality_check".
copy "d001_d003_confidentiality_check.rtn".

* 2013/12/05 - MC35 - check refer doc if needed
ga2-check-refer-doc-needed.

    if hold-oma-rec-ind (ss-det-nbr,ss-phy-ind) = 'Y'
    then
	move 'Y'			to flag-refer-doc.
*   endif

ga2-99-exit.
    exit.
* 2013/12/05 - end


ga9-sum-clmdtl-serv.

    add hold-sv-nbr-serv (ss-det-nbr)
        hold-sv-nbr (ss-det-nbr,1)
        hold-sv-nbr (ss-det-nbr,2)
        hold-sv-nbr (ss-det-nbr,3)      to  claim-nbr-serv.

ga9-99-exit.
    exit.

gc1-find-confidential-desc-rec.

    if hold-desc (ss-desc) = "NO VERIFICATION PLEASE"
    then
	move "Y"				to flag-confidential-desc-rec.
*   endif

gc1-99-exit.
    exit.
ha0-acpt-diag-cd.

*   accept scr-clmhdr-diag-cd.
    accept scr-hold-diag-cd.

*       (if blank or zero code entered accept as valid --
*       -- if code entered then existance of key in diag mstr is validity check)
*   if clmhdr-diag-cd = spaces
    if hold-diag-cd(ss-clmdtl-oma) = spaces
    then
*       move zero                       to clmhdr-diag-cd
        move zero                       to hold-diag-cd(ss-clmdtl-oma)
        go to ha0-99-exit
    else
*       if clmhdr-diag-cd = zero
        if hold-diag-cd(ss-clmdtl-oma) = zero
        then
            go to ha0-99-exit.
*       (else)
*       endif
*   endif

*   move clmhdr-diag-cd                 to diag-cd.
    move hold-diag-cd(ss-clmdtl-oma)    to diag-cd.

    if hold-diag-cd(ss-clmdtl-oma) = "100"
    then
        move "Y"                            to clmhdr-manual-review
        display scr-clmhdr-man-review.
*   endif.

*mf read  diag-mstr     suppress data record
    read  diag-mstr
        invalid key
            move 44                     to err-ind
            perform za0-common-error    thru za0-99-exit
            go to ha0-acpt-diag-cd.

    if first-diag-cd = 'Y'
    then
        move 'N'                            to first-diag-cd
        move hold-diag-cd(ss-clmdtl-oma)    to clmhdr-diag-cd
        display scr-clmhdr-diag-cd
        perform ha1-preset-diag-cd          thru ha1-99-exit
              varying  ss
              from     ss-clmdtl-oma
              by        1
*		(brad1 - allow 10 detail lines per screen)
*              until ss > 8.
              until ss > 10.

ha0-99-exit.
    exit.

ha1-preset-diag-cd.

* preset remaining diag-cd to first no zero code entered.
    move hold-diag-cd(ss-clmdtl-oma)    to hold-diag-cd(ss).

ha1-99-exit.
    exit.


ia0-acpt-loc.

    accept scr-clmhdr-loc.

*   (only verify if operator changed loc from what was entered for batctrl rec)
    if clmhdr-loc of claim-header-rec not = batctrl-loc
    then
*       (verify against doctor's valid locations)
        move clmhdr-loc of claim-header-rec                         to ws-loc
        perform zr0-verify-loc-for-doc          thru zr0-99-exit
        if not-ok
        then
            move 10                             to err-ind
            perform za0-common-error            thru za0-99-exit
            go to ia0-acpt-loc.
*       endif
*   endif

* AB ST
*   (verify location is in location master)
     move clmhdr-loc of claim-header-rec     			to loc-nbr.
     perform xb0-verify-location		thru xb0-99-exit.

     if loc-not-found
     then
        move 102				to err-ind
        perform za0-common-error          	thru za0-99-exit
        go to ia0-acpt-loc
     else
	if    loc-found
          and loc-active-for-entry = "N"
	then
            move 103				to err-ind
            perform za0-common-error          	thru za0-99-exit
            go to ia0-acpt-loc.
*	endif
*   endif
* AB EN

ia0-99-exit.
    exit.


ja0-acpt-hosp.
*   (hospital field no longer contains actual hospital code. 
*    The location code is used to obtain hospital when the ohip tape is 
*    created. If the clmhdr-hosp field was larger we could store the 4 digit
*    hospital number but because it's only 1 char we just blank the field.
*    Pmgs that need the hospital code/number should use location to access
*    f030 and pickup correct hospital.

*   (commented out 'accept' 00/sep/25 B.E.)
*   accept scr-clmhdr-hosp.
*   (commented out the blank of this field 2001/nov/06 B.E. when field began
*    to be used as payroll field)
***    move spaces				    to clmhdr-hosp.

*   (display hospital number from the location master)
    display scr-hosp-nbr.   

**    (only verify if operator changed hosp from what was entered for batctrl rec)
**        note -  operator allowed to use blank hospital -- if hosp code
**        is required by an oma code entered this will be checked later)

**   (sms #113 - treat agent 4 as direct bill)
**    if  (def-agent-bill-direct)
**      or
**        (    (clmhdr-hosp not = spaces)
**         and (clmhdr-hosp not = batctrl-hosp))
**    then
**        perform zs0-verify-hosp                 thru zs0-99-exit
*
*     if    clmhdr-hosp not = spaces
*       and clmhdr-hosp not = "Y"
*        if not-ok
*        then
*            move 11                             to   err-ind
*            perform za0-common-error            thru za0-99-exit
*            go to ja0-acpt-hosp.
**       (else)
**       endif
**    (else)
**    endif
*
*    move clmhdr-loc of claim-header-rec                             to ws-loc.

* 1999/may/05 B.E.
**    if (clmhdr-hosp not = spaces) and (clmhdr-hosp not = ws-loc-1)
**    then
**        move 83                                 to err-ind
**        perform za0-common-error                thru za0-99-exit
**        go to ja0-acpt-hosp.
***   endif

ja0-99-exit.
    exit.


ka0-acpt-i-o-pat-ind.

*   (the in/out indicator is obtained from the location master in field
*    called 'card colour'). 
    move loc-card-colour                    to clmhdr-i-o-pat-ind.
    display scr-clmhdr-i-o-pat-ind.
*    accept  scr-clmhdr-i-o-pat-ind.


*       (only verify if operator changed indicator from what was entered for batctrl rec)
*    if clmhdr-i-o-pat-ind not = batctrl-i-o-pat-ind
*    then
*        move clmhdr-i-o-pat-ind                 to ws-i-o-pat-ind
*        perform zt0-verify-i-o-pat-ind          thru zt0-99-exit
*        if not-ok
*        then
*            go to ka0-acpt-i-o-pat-ind.
**       (else)
**       endif
**    (else)
**    endif

ka0-99-exit.
    exit.

* 2011/04/20 - MC18- uncomment /reactivate 
la2-acpt-manual-review.

   accept scr-clmhdr-man-review.

   if clmhdr-manual-review = ' ' or 'Y'
   then
       next sentence
   else
       move 68                         to err-ind
       perform za0-common-error        thru za0-99-exit
       go to la2-acpt-manual-review.
*   endif

la2-99-exit.
   exit.
* 2011/04/20 - end

* 2010/07/12 - MC11 - enter value 1 to 5 on payroll field for dept 41 or 42 or 43 or 75
laa-acpt-payroll.      

    accept scr-payroll.     

    if ws-doc-dept = 41 or 42 or 43 or 75
    then 
* 2010/08/17 - MC12 - include value 0 as well 
*        if clmhdr-payroll  =  '1' or '2' or '3' or '4' or '5'
        if clmhdr-payroll  =  '0' or '1' or '2' or '3' or '4' or '5'
* 2010/08/17 - end
        then
            next sentence
	else
            move 156                        to err-ind
            perform za0-common-error        thru za0-99-exit
            go to laa-acpt-payroll 
*       endif
    else
	if clmhdr-payroll not = "A" 
        then
            move 157                        to err-ind
            perform za0-common-error        thru za0-99-exit
            go to laa-acpt-payroll. 
*       endif
	    
*   endif

laa-99-exit.
   exit.

* 2010/07/12 - end
la0-acpt-clmdtl-desc.

*       (accept description records --
*        note: the pricing algorithm may have generated some description
*               records.  if any anae or asst oma codes (suff = 'B' or 'C')
*               were entered then a 'basic + times' description record
*               is created.  2 'basic + times' descriptions are packed
*               into 1 description rec )

    if flag-no-verif = "N"
    then
        perform la1-check-for-diag-cd                thru la1-99-exit
                varying   ss
                from       1
                by         1
*		(brad1 - allow 10 detail lines per screen)
*              until ss > 8.
              until ss > 10.
*   endif

* MC37
la0-acpt-desc-1.
* MC37 - end

*   (00/sep/25 B.E. - users can enter 3 character 'short forms' and the 
*		      translation rtn will convert to long text)
    if ss-clmdtl-desc < 1
    then
        accept scr-hold-desc-1
* MC37
        move hold-desc(1)               to test-field
        move 'Y'                        to flag
        perform zf0-test-field          thru zf0-99-exit
        	varying i
        	from 1
        	by 1
        	until i > ss-max-field-check or not-ok
    	if not-ok
    	then
            move 182                        to err-ind
            perform za0-common-error        thru za0-99-exit
            go to la0-acpt-desc-1
*       endif
	else
* MC37 - end

        if hold-desc-1 = spaces
        then
            go to la0-99-exit
        else
            add 1                       to ss-clmdtl-desc
	    move hold-desc(1)	 	to hold-desc-tmp
	    perform desc-text-translation
					thru desc-text-translation-99-exit
	    move hold-desc-tmp		to hold-desc(1)
	    display scr-hold-desc-1.


*       endif
*   (else)
*    endif
   
* MC37
la0-acpt-desc-2.
* MC37 - end

    if ss-clmdtl-desc < 2
    then
        accept scr-hold-desc-2
* MC37
        move hold-desc(2)               to test-field
        move 'Y'                        to flag
        perform zf0-test-field          thru zf0-99-exit
        	varying i
        	from 1
        	by 1
        	until i > ss-max-field-check or not-ok
    	if not-ok
    	then
            move 182                        to err-ind
            perform za0-common-error        thru za0-99-exit
            go to la0-acpt-desc-2
*       endif
	else
* MC37 - end

        if hold-desc-2 = spaces
        then
            go to la0-99-exit
        else
            add 1                       to ss-clmdtl-desc
	    move hold-desc(2)	 	to hold-desc-tmp
	    perform desc-text-translation
					thru desc-text-translation-99-exit
	    move hold-desc-tmp		to hold-desc(2)
	    display scr-hold-desc-2.
*       endif
*   (else)
*    endif

* MC37
la0-acpt-desc-3.
* MC37 - end

    if ss-clmdtl-desc < 3
    then
        accept scr-hold-desc-3
* MC37
        move hold-desc(3)               to test-field
        move 'Y'                        to flag
        perform zf0-test-field          thru zf0-99-exit
        	varying i
        	from 1
        	by 1
        	until i > ss-max-field-check or not-ok
    	if not-ok
    	then
            move 182                        to err-ind
            perform za0-common-error        thru za0-99-exit
            go to la0-acpt-desc-3
*       endif
	else
* MC37 - end

        if hold-desc-3 = spaces
        then
            go to la0-99-exit
        else
            add 1                       to ss-clmdtl-desc
	    move hold-desc(3)	 	to hold-desc-tmp
	    perform desc-text-translation
					thru desc-text-translation-99-exit
	    move hold-desc-tmp		to hold-desc(3)
	    display scr-hold-desc-3.
*       endif
*   (else)
*    endif

* MC37
la0-acpt-desc-4.
* MC37 - end

    if ss-clmdtl-desc < 4
    then
        accept scr-hold-desc-4
* MC37
        move hold-desc(4)               to test-field
        move 'Y'                        to flag
        perform zf0-test-field          thru zf0-99-exit
        	varying i
        	from 1
        	by 1
        	until i > ss-max-field-check or not-ok
    	if not-ok
    	then
            move 182                        to err-ind
            perform za0-common-error        thru za0-99-exit
            go to la0-acpt-desc-4
*       endif
	else
* MC37 - end

        if hold-desc-4 = spaces
        then
            go to la0-99-exit
        else
            add 1                       to ss-clmdtl-desc
	    move hold-desc(4)	 	to hold-desc-tmp
	    perform desc-text-translation
					thru desc-text-translation-99-exit
	    move hold-desc-tmp		to hold-desc(4)
	    display scr-hold-desc-4.
*       endif
*   (else)
*    endif

* MC37
la0-acpt-desc-5.
* MC37 - end

    if ss-clmdtl-desc < 5
    then
        accept scr-hold-desc-5
* MC37
        move hold-desc(5)               to test-field
        move 'Y'                        to flag
        perform zf0-test-field          thru zf0-99-exit
        	varying i
        	from 1
        	by 1
        	until i > ss-max-field-check or not-ok
    	if not-ok
    	then
            move 182                        to err-ind
            perform za0-common-error        thru za0-99-exit
            go to la0-acpt-desc-5
*       endif
	else
* MC37 - end

        if hold-desc-5 = spaces
        then
            go to la0-99-exit
        else
            add 1                       to ss-clmdtl-desc
	    move hold-desc(5)	 	to hold-desc-tmp
	    perform desc-text-translation
					thru desc-text-translation-99-exit
	    move hold-desc-tmp		to hold-desc(5)
	    display scr-hold-desc-5.
*       endif
*   (else)
*    endif

la0-99-exit.
    exit.


la1-check-for-diag-cd.

*       (sms 103    display message if diag. code = 100   j.l. nov 26,1987)
        if hold-diag-cd (ss) = 100
        then
            move "Y"                            to flag-no-verif
            move 9                              to ss
            if hold-desc-1 = spaces
            then
                move "NO VERIFICATION PLEASE"   to   hold-desc-1
                display scr-hold-desc-1
                add 1                           to ss-clmdtl-desc
            else
            if hold-desc-2 = spaces
            then
                move "NO VERIFICATION PLEASE"   to   hold-desc-2
                display scr-hold-desc-2
                add 1                           to ss-clmdtl-desc
            else
            if hold-desc-3 = spaces
            then
                move "NO VERIFICATION PLEASE"   to   hold-desc-3
                display scr-hold-desc-3
                add 1                           to ss-clmdtl-desc
            else
            if hold-desc-4 = spaces
            then
                move "NO VERIFICATION PLEASE"   to   hold-desc-4
                display scr-hold-desc-4
                add 1                           to ss-clmdtl-desc
            else
            if hold-desc-5 = spaces
            then
                move "NO VERIFICATION PLEASE"   to   hold-desc-5
                display scr-hold-desc-5
                add 1                           to ss-clmdtl-desc.
*       endif

la1-99-exit.
    exit.

la3-check-4-missing-addon-cd.
*  2007/apr/04 b.e. added A262 to list below
        if hold-oma-cd (ss) =      "A071"
                                or "A073"
                                or "A074"
                                or "A078"
* MC39
*                               or "A131"
*				or "A133"
*				or "A134"
*				or "A138"
				or "A181"
				or "A183"
				or "A184"
				or "A188"
				or "A262"
				or "A263"
				or "A264"
				or "A283"
				or "A284"
				or "A310"
				or "A311"
				or "A313"
				or "A318"
				or "A340"
				or "A341"
				or "A343"
				or "A348"
*				or "A411"
*				or "A413"
*				or "A414"
*				or "A418"
				or "A471"
				or "A473"
				or "A474"
				or "A478"
				or "A481"
				or "A483"
				or "A484"
				or "A488"
*				or "A601"
*				or "A603"
*				or "A604"
*				or "A608"
				or "A611"
				or "A613"
				or "A614"
				or "A618"
				or "A623"
				or "A624"
				or "A621"
				or "A628"
				or "A661"
* 2011/04/20 - MC18 - add 16 more oma codes
				or "A153"
				or "A154"
				or "A151"
				or "A158"
*				or "A163"
*				or "A164"
*				or "A161"
*				or "A168"
* MC39 - end
				or "A443"
				or "A444"
				or "A441"
				or "A448"
				or "A463"
				or "A464"
				or "A461"
				or "A468"
* 2011/04/20 - end
	then
	    move "Y"			to flg-omacd-possible-addon-found.
*	end if

*	(2008/01/22 b.e. - added 299, 313, 315, 765 and 902 to list of 
*				diagnostic cod
        if hold-diag-cd (ss) =     042
				or 043
				or 044
				or 250
				or 286
				or 287
				or 290
				or 299
				or 313
				or 315
				or 332
				or 340
				or 343
				or 345
				or 402
				or 428
				or 491
				or 492
				or 493
				or 515
				or 555
				or 556
				or 571
				or 585
				or 710
				or 714
				or 720
				or 721
				or 758
				or 765
				or 902
	then
	    move "Y"			to flg-diag-possible-addon-found.
*	end if

        if hold-oma-cd (ss) = "E078"
	then
	    move "Y"			to flg-addon-possible-addon-found.
*	end if
la3-99-exit.
    exit.

* 2008/04/30 - MC

la5-oma-code-edit-check.

    if    ws-e020 = "Y"
       and ws-e022-e017-e016 = "N"
     then
          move 120                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-e719 = "Y"
       and ws-z570 = "N"
     then
          move 121                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-e720 = "Y"
       and ws-z571 = "N"
     then
          move 122                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif


* edit 5
     if    ws-e717 = "Y"
       and ws-z555-z580 = "N"
* 2013/04/10 - MC28
       and ws-z491-to-z499 = "N"
* 2013/04/10 - end
     then
          move 123                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-e702 = "Y"
       and ws-z515-z760 = "N"
     then
          move 124                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-g123 = "Y"
       and ws-g228 = "N"
     then
          move 125                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-g223 = "Y"
       and ws-g231 = "N"
     then
          move 126                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-g265 = "Y"
       and ws-g264 = "N"
     then
          move 127                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-g385 = "Y"
       and ws-g384 = "N"
     then
          move 128                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-g281 = "Y"
       and ws-g381 = "N"
     then
          move 129                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

* 2011/11/23 - MC22 - edit 13 check is no longer needed
*		      This can be deleted as it is captured in 'fee value of zero found' edit.

*     if    ws-e793 = "Y"
* 2010/04/14 - MC6 - add 18 more oma codes in ws-r905-s800
* 2011/04/11 - MC18 - add 3 more oma codes in ws-r905-s800
*       and ws-r905-s800 = "N"
*     then
*          move 131                        to      err-ind
*	  perform za0-common-error            thru za0-99-exit.
*   endif
* 2011/11/23 - end


* 2009/05/04 - MC2
     if    ws-c998 = "Y"
* 2010/04/14 - MC6 - include C985
        or ws-c985 = 'Y'
* 2010/04/14 - end
* 2011/04/11 - MC18 - include C983
        or ws-c983 = 'Y'
* 2011/04/11 - end
     then
          move 135                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-c999 = "Y"
     then
          move 136                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

     if    ws-e798 = "Y"
       and ws-z400 = "N"
     then
          move 137                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

* 2011/04/11 - MC18
*    if    ws-g400-other-codes = "Y"
     if    (   ws-g400-other-codes = "Y"
            or ws-g489-g376        = "Y"
           )
* 2011/04/11 - end
       and ws-e409-e410 = "Y"
     then
          move 138                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

* 2009/06/01 - MC4 -- RMA requests not to check this edit but still apply in newu701
*     if    ws-c990-to-c997 = "Y"
*       and ws-cnnn = "Y"
*     then
*          move 139                        to      err-ind
*	  perform za0-common-error            thru za0-99-exit.
*   endif
* 2009/06/01 - end

* 2010/06/10 - MC7 -- RMA requests to reinstate above edit check 
*		   -- there are more oma codes added in ws-c990-to-c997	
     if    ws-c990-to-c997 = "Y"
       and ws-cnnn = "Y"
* 2010/09/23 - MC14 - if two dates are the same
       and ws-sv-date-c1 = ws-sv-date-c2
* 2010/09/23 - end
     then
          move 139                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif
* 2010/06/10 - end

     if    ws-e450 = "Y"
       and ws-j315 = "N"
     then
          move 140                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

* 2009/05/04 - end

* 2010/may/27 - MC6 - 15 edit checks for error mssage 141 to 154

     if    ws-g222 = "Y"
       and ws-g248-g062 = "Y"
     then
          move 141                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

     if    ws-X9nn = "Y"
       and ws-a770-a775 = "Y"
     then
          move 142                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

* 2014/06/05 - MC38 - user decided to comment out this edit check
*    if    ws-hnnn = "Y"
*      and ws-h112-h113 = "Y"
*    then
*         move 144			  to      err-ind
*         perform za0-common-error            thru za0-99-exit.
*    endif
* 2014/06/05 - end

     if    ws-g222-z805 = 'Y'
       and ws-p014-p016 = "Y"
     then
          move 146                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

     if    ws-g221 = 'Y'
       and ws-g220 = "N"
      then
          move 148                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

     if    ws-g521-g395 = 'Y'
       and ws-h104-h124 = "Y"
     then
          move 151                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

     if    ws-g345-g339 = 'Y'
       and ws-annn = "Y" 
     then
          move 152                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

* 2010/05/27 - end

* 2011/04/12 - MC18  - check for error 158, 162, 165, 166, 167, 168, 169

     if    ws-j025 = 'Y'
       and (ws-j021 = 'Y' or ws-j022 = 'Y')
     then
          move 158                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

     if    ws-z608 = 'Y'
       and ws-z611-z602 = 'Y'
     then
          move 162                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

     if    ws-z403 = 'Y'
       and ws-z408 = 'Y'
       and clmhdr-manual-review not = 'Y'
     then
          move 165                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

* 2011/11/23 - MC22 - edit 45 is no longer needed
*		      This can be deleted as new billing guidelines have replaced this scenario.

*     if    ws-a195 = 'Y'
*       and ws-k002 = 'Y'
*       and clmhdr-manual-review not = 'Y'
*     then
*          move 166                        to      err-ind
*          perform za0-common-error            thru za0-99-exit.
*    endif
* 2011/11/23 - end

     if    ws-c122-c143 = 'Y'
       and ws-e083 not = 'Y'
     then
          move 167                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

     if    ws-c122-c982 not = 'Y'
       and ws-e083 = 'Y'
     then
          move 168                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

     if    ws-j021 not = 'Y'
       and ws-j022 = 'Y'
     then
          move 169                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

* 2011/04/12 - end

* 2011/11/23 - MC22 - add edit check for 53 to 63

     if    ws-k189 = 'Y'
       and ws-a190-a795 not = 'Y'
     then
          move 174                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

* edit 54 to 63
     if    (    ws-k960 = 'Y'
            and ws-k990 not = 'Y'
           )
       or  (    ws-k961 = 'Y'
            and ws-k992 not = 'Y'
           )
       or  (    ws-k962 = 'Y'
            and ws-k994 not = 'Y'
           )
       or  (    ws-k963 = 'Y'
            and ws-k998 not = 'Y'
           )
       or  (    ws-k964 = 'Y'
            and ws-k996 not = 'Y'
           )
       or  (    ws-c960 = 'Y'
            and ws-c990 not = 'Y'
           )
       or  (    ws-c961 = 'Y'
            and ws-c992 not = 'Y'
           )
       or  (    ws-c962 = 'Y'
            and ws-c994 not = 'Y'
           )
       or  (    ws-c963 = 'Y'
            and ws-c986 not = 'Y'
           )
       or  (    ws-c964 = 'Y'
            and ws-c996 not = 'Y'
           )
     then
          move 175                        to      err-ind
          perform za0-common-error            thru za0-99-exit.
*    endif

* 2011/11/23 - end
* 

* 2012/12/22 - MC26 - comment out the below if condition since the pricing for E676B is now corrected
* 2011/12/05 - MC22 - add edit check for 64 
*     if    ws-e676 = 'Y'
*     then
*          move 176                        to      err-ind
*          perform za0-common-error            thru za0-99-exit.
*    endif
* 2011/12/05 - end
* 2012/12/22 - end

* 2013/04/11 - MC28 - add edit 67 to 68
* edit 67 
     if    ws-g556 = "Y"
       and ws-g400-g620 = "N"
     then
          move 178                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

* edit 68 
     if    ws-a120 = "Y"
       and ws-z491-to-z499 = "N"
     then
          move 179                        to      err-ind
	  perform za0-common-error            thru za0-99-exit.
*   endif

* 2013/04/11 -end

la5-99-exit.
    exit.

* 2008/04/30 - end


ma0-acpt-verification.

*       ('flag' must be set before entering this routine --
*         flag = 1 allows 'Y', 'N', 'M'  only
*         flag = 2 allows 'Y', 'N', 'M', 'D' and 'R' and 'P' and 'S'
*                                        ==========================

    move space                          to flag-accept.

    if flag = "1"
    then
        display verification-screen-1
    else
        display verification-screen-2.
*   endif

    display scr-verification.
    accept  scr-verification.

    if flag-accept =   "Y"
                    or "N"
                    or "M"
                    or "P"
                    or "D"
                    or "S"
*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==**
*==*==*==*                  or "R"
*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==**
    then
        if    flag = "2"
           or (      (flag-accept not = "D")
                 and (flag-accept not = "R")  )
        then
            go to ma0-99-exit
        else
            next sentence
*       endif
    else
        next sentence.
*   endif


*       (invalid data input -- display error message and re-enter)
    move 1                              to err-ind.
    perform za0-common-error            thru za0-99-exit.
    go to ma0-acpt-verification.


ma0-99-exit.
    exit.

na0-write-clmhdr.

*       (update total fees for claim)
    move 0                              to clmhdr-tot-claim-ar-oma
                                           clmhdr-tot-claim-ar-ohip
                                           clmhdr-amt-tech-billed.

* 2003/11/19 - MC - initialize hold-date to 99999999 for each claim 
*		    before determining the earliest service date from each detail
    move 99999999			to hold-date.
* 2003/11/19 - end

    perform nb0-add-tot-claim-fees      thru nb0-99-exit
                varying   ss
                from 1 by 1
                until     ss > ss-clmdtl-oma.

**    the following 'add'  and 'if condition' are added on nov 2, 1988
**    by m.s. - sms 99

    add clmhdr-tot-claim-ar-oma                 to ws-batctrl-amt-act.

    if  ws-batctrl-amt-act > 99999.99
    then
*       (batctrl amt already exceed 99999.99 -- shut down batch with
*        message to re-number remaining claims)
        perform ab1-subtract-1-from-claim-nbr   thru ab1-99-exit
        display ring-bell
        display ring-bell
        display ring-bell
        display ring-bell
        display ring-bell
        move 61                         to err-ind
        perform za0-common-error        thru za0-99-exit
        perform zz0-end-of-batch        thru zz0-99-exit
        go to mainline-shutdown.
*   (else)
*   endif

*mf MF cobol requires zeros in numeric fields
    move zeros                          to clmhdr-serv-date
* MC9
*                                           clmhdr-submit-date.
                                           clmhdr-submit-date of claim-header-rec.

* 2003/11/19 - MC - Store the earliest service date to clmhdr-serv-date 
    move hold-date 			to clmhdr-serv-date.
* 2003/11/19 - end

    move ws-doc-dept                    to clmhdr-doc-dept.
    move ws-doc-ohip-nbr                to clmhdr-doc-nbr-ohip.
    move ws-doc-spec-cd                 to clmhdr-doc-spec-cd.
    move sys-date                       to clmhdr-date-sys.
    move spaces                         to clmhdr-reference.
*   (sms #113 - treat agent 4 as direct bill)
    if  not def-agent-bill-direct
      and not def-agent-foreign-direct
      and not def-agent-ifhp-direct
      and not def-agent-ontario-direct
      and not def-agent-quebec-direct
    then
        move zero                       to clmhdr-date-cash-tape-payment.
*   endif

    move zeros                          to clmhdr-manual-and-tape-paymnts
                                           clmhdr-status-ohip
                                           clmhdr-curr-payment.
    move def-claim-source               to clmhdr-adj-cd-sub-type.

*   (manual-review-flag  processing - 
*    if user created any description records then set manual review indicator 
*    to 'yes'. Note that the system may have created description records to 
*    record anae/asst 'basic + times' units and these are not considered when
*    when setting indicator to 'y'es.

    if    (ss-clmdtl-desc  > 0
       and ss-clmdtl-desc  not = ss-basic-times-desc-rec)
*         (if ic entered on the claim, print it on the blue card)
       or ic-entered
    then
        move "Y"                        to clmhdr-manual-review
        display scr-clmhdr-man-review.
*   (else)
*   endif

*       (write data rec and the 'batch-nbr' index)
*mf move "B"                            to key-clm-key-type.
*mf move clmhdr-claim-id                to key-clm-data
    move "B"                            to clmhdr-b-key-type.
    move clmhdr-claim-id                to clmhdr-b-data.
    move clmhdr-key-claims-mstr         to key-claims-mstr.
*   (build the 'patient-id' alternate index)
    move "P"                            to clmhdr-p-key-type.
    move clmhdr-pat-key-data            to clmhdr-p-data.
    move clmhdr-p-claims-mstr           to clmdtl-p-claims-mstr.

*mf write claims-mstr-hdr-rec   from  claim-header-rec  key is key-claims-mstr
    write claims-mstr-hdr-rec   from  claim-header-rec
        invalid key
            move 29                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform zz0-end-of-batch    thru zz0-99-exit
            go to mainline-shutdown.

*mf (write the 'patient-id' index)
*mf move "P"                            to key-clm-key-type.
*mf move clmhdr-pat-key-data            to key-clm-data.
*mf write  inverted  claims-mstr-hdr-rec                key is key-claims-mstr
*mf     invalid key
*mf         move 30                     to err-ind
*mf         perform za0-common-error    thru za0-99-exit
*mf         perform zz0-end-of-batch    thru zz0-99-exit
*mf         go to mainline-shutdown.

    add  1                              to ctr-writ-claims-mstr.

na0-99-exit.
    exit.



nb0-add-tot-claim-fees.

    add hold-fee-oma  ( ss )            to clmhdr-tot-claim-ar-oma.
    add hold-fee-ohip ( ss )            to clmhdr-tot-claim-ar-ohip.
    add hold-priced-tech(ss)            to clmhdr-amt-tech-billed.

* 2003/11/19 - MC - save the earliest service date from the detail
    if hold-sv-date (ss) < hold-date
    then
	move hold-sv-date (ss)		to hold-date.
*   endif
* 2003/11/19 - end

nb0-99-exit.
    exit.


nc0-set-hdr-diag-cd.

    if hold-diag-cd(ss) not = zero
    then
        move hold-diag-cd(ss)           to clmhdr-diag-cd
        move 10                         to ss
        display scr-clmhdr-diag-cd.
*   endif

nc0-99-exit.
    exit.

pa0-write-clmdtl.

*       (pa0 uses ss-det-nbr passed from calling routine to determine
*        which detail hold rec to move to claims-mstr rec)

    perform pb0-move-hold-to-oma-rec    thru pb0-99-exit.

*mf move "B"                            to key-clm-key-type.
*mf move clmdtl-id                      to key-clm-data.
    move "B"                            to clmdtl-b-key-type.
    move clmdtl-id                      to clmdtl-b-data.
*   (build the 'patient-id' alternate index using 'Z' so that it
*    won't appear in the normal P key sequence since P keys are
*    only needed for the header records - not the detail records)
    move "Z"                            to clmdtl-p-key-type.
    move clmhdr-pat-key-data            to clmdtl-p-data.

*mf write claims-mstr-rec       from  claim-detail-rec  key is key-claims-mstr
    write claims-mstr-rec       from  claim-detail-rec
        invalid key
            move 30                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform zz0-end-of-batch    thru zz0-99-exit
            go to mainline-shutdown.
    add 1                               to ctr-writ-claims-mstr.

pa0-99-exit.
    exit.



pb0-move-hold-to-oma-rec.

    move hold-oma-cd          (ss-det-nbr)      to clmdtl-oma-cd.
    move hold-oma-suff        (ss-det-nbr)      to clmdtl-oma-suff.
    move hold-sv-nbr-serv     (ss-det-nbr)      to clmdtl-nbr-serv.
    move hold-sv-date         (ss-det-nbr)      to clmdtl-sv-date.

    move hold-sv-nbr      ( ss-det-nbr, 1)      to clmdtl-sv-nbr ( 1 ).
    move hold-sv-day      ( ss-det-nbr, 1)      to clmdtl-sv-day ( 1 ).
    move hold-sv-nbr      ( ss-det-nbr, 2)      to clmdtl-sv-nbr ( 2 ).
    move hold-sv-day      ( ss-det-nbr, 2)      to clmdtl-sv-day ( 2 ).
    move hold-sv-nbr      ( ss-det-nbr, 3)      to clmdtl-sv-nbr ( 3 ).
    move hold-sv-day      ( ss-det-nbr, 3)      to clmdtl-sv-day ( 3 ).

*       (sum total nbr of services for claim for batctrl hash total --
*        -- note also used to update 'total nbr of visits' on patient record)
    add  hold-sv-nbr-serv ( ss-det-nbr)
         hold-sv-nbr      ( ss-det-nbr, 1)
         hold-sv-nbr      ( ss-det-nbr, 2)
         hold-sv-nbr      ( ss-det-nbr, 3)      to ws-tot-claim-nbr-sv.

    move zero                                   to clmdtl-rev-group-cd.

    move hold-diag-cd     (ss-det-nbr)          to clmdtl-diag-cd.

    move hold-fee-oma         (ss-det-nbr)      to clmdtl-fee-oma.
    move hold-fee-ohip        (ss-det-nbr)      to clmdtl-fee-ohip.
    move hold-priced-tech     (ss-det-nbr)      to clmdtl-amt-tech-billed.

** store the line no based on the sequence of data entry

    move hold-line-no   (ss-det-nbr)            to clmdtl-line-no.

pb0-99-exit.
    exit.

ra0-write-clmdtl-desc.

*       (ss-det-nbr) passed from calling routine to determine
*        which detail desc to write -- ss-det-nbr also used to update
*        oma suffix so that each detail rec will have a non-duplicate key)

*       (note - "ZZZZ" oma code is used for desc. recs to force them
*               after all possible oma detail records in isam keyed file)

*mf move "B"                            to key-clm-key-type.
    move "B"                            to clmdtl-b-key-type.
*   (build the 'patient-id' alternate index using 'Z' so that it
*    won't appear in the normal P key sequence since P keys are
*    only needed for the header records - not the detail records)
    move "Z"                            to clmdtl-p-key-type.
    move clmhdr-pat-key-data            to clmdtl-p-data.

    move "ZZZZ"                         to clmdtl-oma-cd.
*mf    move ss-det-nbr                  to clmdtl-oma-suff.
*   (ss-det-nbr is defined as pic 99, hence it  always passes 0 to oma suff
*    now use a new item ss-desc which is defined as pic 9)
    move ss-desc        to clmdtl-oma-suff.
    move zero                           to clmdtl-adj-nbr.
*mf move clmdtl-id                      to key-clm-data.
    move clmdtl-id                      to clmdtl-b-data.

*    move hold-desc (ss-det-nbr)         to clmdtl-desc.
*    move orig-desc (ss-desc)            to clmdtl-desc.
    move hold-desc (ss-desc)		to clmdtl-desc.

*mf write claims-mstr-rec       from  claim-detail-rec  key is key-claims-mstr
    write claims-mstr-rec       from  claim-detail-rec
        invalid key
            move 31                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform zz0-end-of-batch    thru zz0-99-exit
            go to mainline-shutdown.

    add  1                              to ctr-writ-claims-mstr.

ra0-99-exit.
    exit.


ta0-update-patient-rec.

*       (if this is not an h.s.o. patient then update location field)
    if    ws-pat-location-field > '100   '
      and ws-pat-location-field < '135   '
    then
        next sentence
    else
        move clmhdr-loc of claim-header-rec                 to ws-pat-location-field.
*   endif

    move hold-sv-date (1)               to ws-pat-date-last-visit.
    move clmhdr-i-o-pat-ind             to ws-pat-in-out.
*!  (appears to be bug below - doc-nbr = 3 char RMA number and f010's
*!   last doc seen is 6 digit MOH number)
*!    move clmhdr-doc-nbr                 to ws-pat-last-doc-nbr-seen.

*  2003/12/04 - MC - no bug now because f010's last doc seen must change
*                    from 6 digits to 3 char
    move clmhdr-doc-nbr                 to ws-pat-last-doc-nbr-seen.
* 2003/12/04 - end

    if clmhdr-date-admit not = zero
    then
        move clmhdr-date-admit          to ws-pat-date-last-admit.
*   (else)
*   endif

    add  1                              to ws-pat-total-nbr-claims
        on size error
            move 99999                  to ws-pat-total-nbr-claims.

    add  1                              to ws-pat-nbr-outstanding-claims
        on size error
            move 9999                   to ws-pat-nbr-outstanding-claims.

    add ws-tot-claim-nbr-sv             to ws-pat-total-nbr-visits
        on size error
            move 99999                  to ws-pat-total-nbr-visits.

       move sys-date                    to ws-pat-date-last-maint.
       move logon-id                    to ws-pat-last-mod-by.

       if ws-pat-health-nbr not = 0
       then
*mf     rewrite hc-pat-mstr-rec         from ws-pat-mstr-rec
        rewrite pat-mstr-rec    from ws-pat-mstr-rec
          invalid key
            move 48                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform zz0-end-of-batch    thru zz0-99-exit
            go to mainline-shutdown
       else
       if qhip or direct
       then
*mf     rewrite od-pat-mstr-rec         from ws-pat-mstr-rec
        rewrite pat-mstr-rec    from ws-pat-mstr-rec
          invalid key
            move 48                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform zz0-end-of-batch    thru zz0-99-exit
            go to mainline-shutdown
       else
       if chart
       then
*mf     rewrite chrt-pat-mstr-rec       from ws-pat-mstr-rec
        rewrite pat-mstr-rec    from ws-pat-mstr-rec
          invalid key
            move 48                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform zz0-end-of-batch    thru zz0-99-exit
            go to mainline-shutdown.
*   endif

ta0-99-exit.
    exit.


ua0-create-new-acronym.

*       create new acronym key pointing to the original data

    move zero                           to pat-occur.
    move save-feedback-pat-mstr         to feedback-pat-mstr-acr.
*mf move ws-pat-mstr-rec                to acr-pat-mstr-rec.
*mf move new-acronym                    to acr-pat-acronym.

*mf write inverted acr-pat-mstr-rec
*mf     invalid key
*mf         move 78                     to err-ind
*mf         perform za0-common-error    thru za0-99-exit.

*mf    move new-acronym                 to acr-pat-acronym.
*mf    move new-pat-surname             to acr-pat-surname.
*mf    move new-pat-given-name          to acr-pat-given-name.
*mf    move sys-date                    to acr-pat-date-last-maint.

*mf    rewrite acr-pat-mstr-rec.

*mf 98/07/21 -read pat mstr with ikey and then update with the new acronym

* 2004/02/19 - MC
*    move ws-key-pat-mstr                to key-pat-mstr.

*    read pat-mstr key is key-pat-mstr
    move ws-key-pat-mstr                to key-pat-mstr of pat-mstr.

    read pat-mstr key is key-pat-mstr of pat-mstr
* 2004/02/19 - end
        invalid key
            move 16                     to err-ind
            perform za0-common-error    thru za0-99-exit.

    move new-acronym                    to pat-acronym.

    rewrite pat-mstr-rec
        invalid key
            move 48                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform zz0-end-of-batch    thru zz0-99-exit
            go to mainline-shutdown.

ua0-99-exit.
    exit.


ua1-delete-old-acronym.

    move zero                           to pat-occur
                                           feedback-pat-mstr-acr.

*
*   (use the original acronym to access pat-mstr.)
*

*mf    move old-acronym                 to acr-pat-acronym.
    move old-acronym                    to pat-acronym.

*mf    read acr-pat-mstr key is acr-pat-acronym
    read     pat-mstr key is     pat-acronym
        invalid key
            move 80                     to err-ind
            perform za0-common-error    thru za0-99-exit
            go to ua1-99-exit.

ua1-10-check-pat-ikey.

*
*   (if found the correct acronym (same patient ikey),
*    delete the old acronym; otherwise read the next same acronym.)
*
*mf    if       acr-key-pat-mstr = ws-key-pat-mstr
* 2004/02/19 - MC
*    if           key-pat-mstr = ws-key-pat-mstr
    if key-pat-mstr of pat-mstr-rec = ws-key-pat-mstr
    then
        perform ua3-delete-acronym      thru ua3-99-exit
    else
        perform ua2-read-next-a-pat     thru ua2-99-exit
*mf     if acr-pat-acronym = old-acronym
        if     pat-acronym = old-acronym
        then
            go to ua1-10-check-pat-ikey.
*       endif
*   endif

ua1-99-exit.
    exit.



ua2-read-next-a-pat.

*mf    read acr-pat-mstr next
    read     pat-mstr next
        at end
            move 81                     to err-ind
            perform za0-common-error    thru za0-99-exit
            go to ua2-99-exit.
*tobefixed*
*mf    retrieve acr-pat-mstr key fix position
*mf     into acr-pat-acronym.

*mf if acr-pat-acronym not = old-acronym
    if     pat-acronym not = old-acronym
    then
        move 82                         to err-ind
        perform za0-common-error        thru za0-99-exit.
*   endif

ua2-99-exit.
    exit.


ua3-delete-acronym.

*mf delete acr-pat-mstr key is acr-pat-acronym
*mf    delete acr-pat-mstr
    delete     pat-mstr
        move 79                 to err-ind
        perform za0-common-error thru za0-99-exit.

ua3-99-exit.
    exit.

uj1-read-isam-const-mstr.

    move 'N'                            to flag-lock.

    read    iconst-mstr
        invalid key
            move "N"                    to flag
            go to uj1-99-exit.

    move "Y"                            to flag.

    add  1                              to ctr-read-const-mstr.

uj1-99-exit.
    exit.
uk0-zero-claim-hold-area.

    move zeros                          to hold-claim-detail-recs.

    move spaces                         to hold-oma-cd ( 1 )
                                           hold-oma-cd ( 2 )
                                           hold-oma-cd ( 3 )
                                           hold-oma-cd ( 4 )
                                           hold-oma-cd ( 5 )
                                           hold-oma-cd ( 6 )
*  sms 126 allow for 8 claim details instead of 6. s.f.
                                           hold-oma-cd ( 7 )
                                           hold-oma-cd ( 8 )
*  					   (brad1 - allow for 10 claim details instead of 8)
                                           hold-oma-cd ( 9 )
                                           hold-oma-cd (10 )
                                           hold-descriptions
                                           hold-basic-times-desc.

uk0-99-exit.
    exit.
va0-acpt-dtl.

*       (if 'basic + times' records have been created then blank them
*        and any other description records - they must then be reentered)
    if   ss-basic-times-desc-rec > 0
      or ss-basic-times          > 0
    then
        move 0                          to ss-basic-times-desc-rec
                                           ss-basic-times
                                           ss-clmdtl-desc
        move spaces                     to hold-basic-times-desc
                                           hold-descriptions.
*   (else)
*   endif

*   add ic-flag by m.c. on 89/08/04

    move 'N'                            to ic-flag.
    move "N"                            to flag-desc-report-required
    move "N"				to flag-adjudication-required
    move "N"                            to flag-diag-code-required.
    move "N"                            to ws-special-add-on-cd-entered.
    move 0                              to ss-clmdtl-oma.

    move "Y"                            to flag-err-data.
    perform wa0-acpt-clmhdr-detail      thru wa0-99-exit.

    if err-data
    then
        go to va0-99-exit.
*   (else)
*   endif

*   copy "d001_va0.rtn".
*   (sms #113 - treat agent 4 as direct bill)
    if   def-agent-ohip
      or def-agent-alternate-funding
      or (    def-agent-ohip-wcb
	  and site-id = "RMA"
	 )
    then
        perform wd0-verify-clmdtl-data  thru wd0-99-exit
        if err-data
        then
            move "M"                    to flag-accept
        else
            next sentence.
*       endif

**  else
*       (agent not 'ohip' so claim can't go onto ohip tape - set indicator
*        so that claim will be printed on blue/yellow cards)
**      move "N"                        to clmhdr-tape-submit-ind.
*   endif


va0-99-exit.
    exit.



wa0-acpt-clmhdr-detail.

    move "Y"                            to flag-err-data.

*    ('ss-conseq-dd' counts the nbr of "#S DD" input for detail line # 'ss-clmdtl-oma')
    move zero                           to ss-conseq-dd.
*    ('ss-clmdtl-oma' counts the nbr of oma detail lines entered)
    add  1                              to ss-clmdtl-oma.

wa0-10.
    if ss-clmdtl-oma not = 1
    then
        go to wa0-12.
*   (else)
*   endif


*   endif
*       (pre-set data unless 'm'odify pass of data)
    if flag-accept not = "M"
    then
        move 1                          to hold-sv-nbr-serv(ss-clmdtl-oma)
        move clmhdr-date-admit          to hold-sv-date(ss-clmdtl-oma)
        move "A"                        to hold-oma-suff(ss-clmdtl-oma)
        move 0                          to hold-diag-cd(ss-clmdtl-oma)
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif


*   ( this must be the first detail, therefore preset print line to 15 )
*   move 15                             to pline.
*  (brad1 - allow 10 claim details per screen rather than 8)
*    move 14                             to pline.
    move 11                            to pline.

    display scr-acpt-clmhdr-det.
    accept scr-hold-oma-cd.
*       (the 1st oma code can't be blank)
    if hold-oma-cd(ss-clmdtl-oma) = spaces
    then
        move 28                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to wa0-10
    else
        go to wa0-14.
*   endif

wa0-12.

*  sms 126 allow for 8 claim details instead of 6. s.f.
*   if ss-clmdtl-oma = 2 or 3 or 4 or 5 or 6
*   (allow 10 detail lines on the screen in stead of 8)
*    if ss-clmdtl-oma = 2 or 3 or 4 or 5 or 6 or 7 or 8
    if ss-clmdtl-oma = 2 or 3 or 4 or 5 or 6 or 7 or 8 or 9 or 10
    then
        if flag-accept = "M"
        then
            perform xa0-display-details thru xa0-99-exit
        else
            move 1                      to hold-sv-nbr-serv(ss-clmdtl-oma)
            subtract 1                  from ss-clmdtl-oma
                                        giving temp
            move hold-sv-date(temp)     to hold-sv-date(ss-clmdtl-oma)
*	    (default suffix to what user last typed in rather than what
*	     is on the last line since this line may have suffix created
*	     by computer)
*           (HSC default is suffix last typed in by user)
            move ws-last-typed-in-suffix    to hold-oma-suff(ss-clmdtl-oma)
	    if site-id = "RMA"
	    then
* 2010/06/16 - MC8 - if agent 1 and suffix 'M' is entered, stay as 'M' for next line; otherwise suffix is 'A'
	        if def-agent-in-pat-diag-billing  and ws-last-typed-in-suffix = 'M'
		then 	
                    perform xa0-display-details thru xa0-99-exit
		else
* 2010/06/16 - end
*               (RMA default is "A")
                move "A"                    to hold-oma-suff(ss-clmdtl-oma)
                perform xa0-display-details thru xa0-99-exit
	    else
                perform xa0-display-details thru xa0-99-exit
*	    endif
    else
*       (only  8  claim detail recs allowed per claim)
*       (only  10 claim detail recs allowed per claim)
        go to wa0-98.
*   endif

    accept scr-hold-oma-cd.

wa0-14.
*       (blank oma code indicates last detail line entered)
    if hold-oma-cd (ss-clmdtl-oma) = spaces
    then
        go to wa0-98.
*   (else)
*   endif

wa0-16.

    move ss-clmdtl-oma  to hold-line-no (ss-clmdtl-oma).

*       (verify oma code against mstr)
    move hold-oma-cd (ss-clmdtl-oma)            to ws-oma-cd.
    perform wb0-read-oma-mstr                   thru wb0-99-exit.
    if not-ok
    then
        move 28                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif
*   (ensure that code hasn't been disabled)
    if fee-active-for-entry <> "Y"
    then
        move 83                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif

* 2007/07/16 - MC
*    if    clmhdr-clinic-nbr-1-2 > "60" and clmhdr-clinic-nbr-1-2 < "66"
* 2010/03/30 - MC5 - iclude clinic 66
*    if    (   (clmhdr-clinic-nbr-1-2 > "60" and clmhdr-clinic-nbr-1-2 < "66")
    if    (   (clmhdr-clinic-nbr-1-2 > "60" and clmhdr-clinic-nbr-1-2 < "67")
* 2010/03/30 - end
           or (clmhdr-clinic-nbr-1-2 > "70" and clmhdr-clinic-nbr-1-2 < "76")
	  )
* 2007/07/16 - end
      and (  fee-icc-sec =    "CV"
                           or "SP" )
    then
        move 24                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif

copy "pricing_logic_check_for_special_addon_codes.rtn".

**       (set flag if special add on oma codes of e409 or e400
**        or e401 or e410 entered)
**    if ws-oma-cd =   "E400"
*                  or "E409"
*                  or "E401"
*                  or "E410"
*    then
*        move "Y"                               to ws-special-add-on-cd-entered.
**   (else)
**   endif

*       (print warning message if oma cd falls in range ?990 thru ?995)

*   if    ws-oma-cd-2-4 > 989
*     and ws-oma-cd-2-4 < 996
*   then
*       move 19                                 to err-ind
*       perform za0-common-error                thru za0-99-exit.
*   (else)
*   endif


*       (if 'ohip' agent then verify header rec in/out patient indicator against ind for oma rec)
*   (sms #113 - treat agent 4 as direct bill)
    if    not def-agent-ohip
      and not def-agent-alternate-funding
      and (    not def-agent-ohip-wcb
           and site-id = "RMA"
         )
    then
        go to wa0-18
    else
*       (input is ok - if oma rec ind is blank, allows 'b'oth, or equals indicator input)
        if   fee-i-o-ind = spaces
          or fee-i-o-ind = clmhdr-i-o-pat-ind
          or fee-i-o-ind        = "B"
          or clmhdr-i-o-pat-ind = "B"
        then
            go to wa0-18
        else
            if fee-i-o-ind = 'I'
            then
                move 36                         to err-ind
            else
                move 37                         to err-ind.
*           endif
*       endif
*   endif

    perform za0-common-error                    thru za0-99-exit.
    move "N"                                    to flag-err-data.
    move "M"                                    to flag-accept.
    go to wa0-99-exit.

wa0-18.
*       (if agent is 'ohip', verify doc specialty code in oma rec's range)
*   (sms #113 - treat agent 4 as direct bill)
    if   (    not def-agent-ohip
          and not def-agent-ohip-wcb
          and not def-agent-alternate-funding
          and (    not def-agent-ohip-wcb
               and site-id = "RMA"
	      )
	 )
      or (       fee-spec-fr = ws-doc-spec-cd
              or fee-spec-to = ws-doc-spec-cd
              or (    fee-spec-fr < ws-doc-spec-cd
                  and fee-spec-to > ws-doc-spec-cd)      )
    then
        next sentence
    else
        move 39                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        move "N"                                to flag-err-data
        move "M"                                to flag-accept
**      go to wa0-99-exit.
        go to wa0-10.
*   endif

*   (check if OMA code requires a hospital code)
    if    fee-hosp-nbr-ind = "Y"
      and loc-hospital-nbr = 0000
    then
        move 11                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        move "N"                                to flag-err-data
        move "M"                                to flag-accept
        go to wa0-10.
*   endif

wa0-20-input-oma-suff-cd.

    accept scr-hold-oma-suff.

*       (verify oma code suffix)
    move hold-oma-suff ( ss-clmdtl-oma)         to ws-oma-suff.
    if   ws-oma-suff = 'A'
      or ws-oma-suff = 'B'
      or ws-oma-suff = 'C'
      or ws-oma-suff = 'M'
    then
*        next sentence
*	(save what operator typed in  so that even if the computer changes
*	 this suffix due to ohip rules, we can default the next line based
*	 upon what the operator thinks they typed in)
	move ws-oma-suff 			to ws-last-typed-in-suffix
    else
        move 47                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-20-input-oma-suff-cd.

    if hold-oma-cd (ss-clmdtl-oma) = 'J318' or 'J319'
    then
        move 'B'                to hold-oma-suff (ss-clmdtl-oma)
        display scr-hold-oma-suff.
*   endif


*       (suffix for anae ('A') or asst ('C') are not allowed if oma code's icc
*        code is 'consultation' or 'visit' (ie. 'CV')
    if    (ws-oma-suff =   "B"
                        or "C")
      and (fee-icc-sec = "CV")
    then
        move 25                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif

* 2004/06/09 - MC
    if    (ws-iconst-clinic-card-colour = "O"
      and   (     (     (ws-oma-suff =   "B"
                                      or "A")
                    and (fee-icc-sec =   "DU"
		                      or "PF"
		                      or "NM")
		   )
	       or  fee-tech-ind = "Y"
	     )
	   )
    then
        move 110                                to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif

* 2013/04/11 - MC28 - new check on edit 66
     if    hold-oma-cd-alpha (ss-clmdtl-oma) = "K"
       and hold-oma-suff (ss-clmdtl-oma) = "C"       
     then
            move 177                        	to      err-ind
            perform za0-common-error            thru za0-99-exit
	    go to wa0-10.
*	endif
* 2013/04/11 - end

wa0-25-input-diag-cd.

    perform ha0-acpt-diag-cd                    thru ha0-99-exit.


*       (if suffix is not a 'B' or 'C' ie. it's an 'A' or 'M', then
*        check if a diagnostic code is required for the oma record --
*        if it is then set flag which will be checked later in verification of claim entred)

*  91/02/27 - sms 138
*  diag cd is required only for ohip or alternative funding claims

    if    (ws-oma-suff = "A" or "M")
*     and  clmhdr-diag-cd = zero
      and  hold-diag-cd(ss-clmdtl-oma) = zero
      and  fee-diag-ind = "Y"
      and  (   def-agent-ohip 
            or def-agent-alternate-funding
            or (    def-agent-ohip-wcb
                and site-id = "RMA"
               )
	   )
    then
        move "Y"                        to flag-diag-code-required
        move 8                          to err-ind
        perform za0-common-error        thru za0-99-exit
        perform ha0-acpt-diag-cd        thru ha0-99-exit
        go to wa0-25-input-diag-cd.
*   (else)
*   endif

*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==
*  do not put diag. code 100 for oma code s768a,s752a,s785a,s756a
*                       sms-103                 j.l. nov 26, 87
*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==
*
*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==
*  put diagnosis code 100 for oma code s768a,s752a,s785a,s756a
*                       pdr-298                 j.l. 3/4/87
*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==*==
*       if   ws-oma-cd = "S768"
*               or       "S752"
*               or       "S785"
*               or       "S756"
*               and   ( ws-oma-suff = "A" )
*       then
*               move    "Y"     to      flag-special-diag-code-req
*               move            100             to clmhdr-diag-cd
*               display         scr-clmhdr-diag-cd.


wa0-30-orig-sv-date-nbr.
    accept scr-hold-sv-date-yy-34.
*y2k 
*   (zeros 1st digits of service date so that century and be defaulted)
    move zero			        to   hold-sv-date-yy-12(ss-clmdtl-oma).
    move hold-sv-date-yy(ss-clmdtl-oma)	to   century-year.
    perform y2k-add-century-to-year     thru y2k-99-exit.
    move century-year                   to   hold-sv-date-yy(ss-clmdtl-oma).
*   endif 
    display scr-hold-sv-date-yy-12.

    accept scr-hold-sv-date-mm.
    accept scr-hold-sv-date-dd.
    accept scr-hold-sv-nbr-0.

*   (verify service date)
    move hold-sv-date (ss-clmdtl-oma)           to ws-date.
    perform ba1-verify-mm-dd                    thru ba1-99-exit.
    if   not-ok
    then
        move 5                                  to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-30-orig-sv-date-nbr.
*   endif
*   (y2k)
*   if  hold-sv-date-yy (ss-clmdtl-oma) < 32
    if  hold-sv-date(ss-clmdtl-oma) > sys-date
    then
        move 6                                  to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-30-orig-sv-date-nbr.
*   endif


    if hold-sv-date (ss-clmdtl-oma) < clmhdr-date-admit
    then
        move 33                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-30-orig-sv-date-nbr.

*   (verify service date 'not >' or '6 mths <' sys-date)
    perform wa3-verify-serv-sys-dates           thru wa3-99-exit.
    if not-ok
    then
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif

*   (pdr 503 - added on 91/07/10 by m.c.
*    copy "d001_wa0_30.rtn".
    if hold-sv-date(ss-clmdtl-oma) > '19910630'
       and ws-pat-health-nbr = 0
       and ws-pat-prov-cd    = "ON"
       and (   def-agent-ohip 
            or def-agent-alternate-funding
            or (    def-agent-ohip-wcb
	   	and site-id = "RMA"
	       )
	   )
    then
        move 70                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        move " "                                to flag-accept
        move "N"                                to flag-err-data
        go to wa0-99-exit.
*   endif


*   (# of serices must be > zero except for oma codes "E400" and "e401" whose "nbr of services"
*    are calculated based on the other oma codes in the claim)
    if    hold-sv-nbr-serv ( ss-clmdtl-oma ) = zero
      and ws-oma-cd not = "E400"
      and ws-oma-cd not = "E401"
    then
        move 1                                  to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif


*       (multiple fractional hrs units may be entered for anae's (suff 'b') and asst's (suff 'c')
*        -- if claim is for a surgeon (suff = 'a') then
*           verify # of services from 'dd' are within days in service-mm unless suffix = 'm'ultiple)
    move hold-sv-date-mm(ss-clmdtl-oma)         to temp-ss.
    if hold-oma-suff ( ss-clmdtl-oma )  = "A"
        if   hold-sv-date-dd  ( ss-clmdtl-oma )
           + hold-sv-nbr-serv ( ss-clmdtl-oma )
           - 1
*               > max-nbr-days ( hold-sv-date-mm(ss-clmdtl-oma) )
* brad changed to this  > temp-ss
                > max-nbr-days (temp-ss)
        then
            move 32                             to err-ind
            perform za0-common-error            thru za0-99-exit
            go to wa0-10.
*       endif
*   (else)
*   endif


* 2008/01/31 b.e. don't allow paediatric specialty (26) to bill A007 if service date is > 2007/12/31 

* 2011/09/07 - MC21 - disable the below edit check, it is similar to error 134
*    if	    hold-sv-date(ss-clmdtl-oma) > "20071231" 
*	and ws-doc-spec-cd = "26"
*	and hold-oma-cd (ss-clmdtl-oma) = "A007" 
*    then
*        move 118                            to err-ind
*        perform za0-common-error            thru za0-99-exit
*        go to wa0-10.
*    end if
* 2011/07/07 - end

* 2008/04/30 - MC
     
* 2010/04/14 - MC6 - do not include E007
*    if   (     (     (   hold-oma-cd (ss-clmdtl-oma) = 'E007'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E505'
* 2011/04/11 - MC18 - do not include E505C, E721C, E757C, E787C or E955C
*    if   (     (     (   hold-oma-cd (ss-clmdtl-oma) = 'E505'
     if   (     (     (   hold-oma-cd (ss-clmdtl-oma) = 'E722'
* 2010/04/14 - end
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E721'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E722'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E757'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E787'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E955'
* 2011/04/11 - end
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 1
                )
            or
* 2010/04/14 - MC4 - do not include E019C
*               (     (   hold-oma-cd (ss-clmdtl-oma) = 'E019'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E010'
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'E010'
* 2010/04/14 - end
* 2011/04/11 - MC18 - do not include E556C, E632C, E622C, E618C, E546C, E725C, E726C, E731C, E739C, E756C or E981C
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E556'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E632'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E622'
                       or hold-oma-cd (ss-clmdtl-oma) = 'E604'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E618'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E546'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E725'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E726'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E731'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E739'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E756'
                       or hold-oma-cd (ss-clmdtl-oma) = 'E956'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E981'
* 2011/04/11 - end
* 2013/04/10 - MC28 - include E022C
                       or hold-oma-cd (ss-clmdtl-oma) = 'E022'
* 2013/04/10 - end
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 2
                )
            or
* 2010/04/14 - MC6 - do not include E018C
*               (     (   hold-oma-cd (ss-clmdtl-oma) = 'E018'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E667'
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'E667'
* 2010/04/14 - end
* 2011/04/11 - MC18 - do not include E627C, E693C, E694C, E733C, E734C, E735C, E736C or E732C
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E627'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E693'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E694'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E733'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E734'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E735'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E736'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E723'
* 2011/04/11 - end
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 3
                )
            or
* 2010/04/14 - MC6 - do not include E009C
*               (     (   hold-oma-cd (ss-clmdtl-oma) = 'E009'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E011'
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'E011'
* 2010/04/14 - end
* 2012/05/17 - MC24 - temporary comment out for E022
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E022'
* 2012/05/17 - end  
                       or hold-oma-cd (ss-clmdtl-oma) = 'E020'
* 2011/04/11 - MC18 - include E024C
                       or hold-oma-cd (ss-clmdtl-oma) = 'E024'
* 2011/04/11 - end

                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 4
                )
            or
* 2010/04/14 - do not include E014C
*               (     (   hold-oma-cd (ss-clmdtl-oma) = 'E014'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E012'
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'E012'
* 2010/04/14 - end
* 2013/04/10 - MC28 - include E137C to E141C, E143C to E147C, E149C, Z606C, Z607C, Z491C to Z499C, Z555C, Z580C
			or (     hold-oma-cd (ss-clmdtl-oma) >= 'E137'
			     and hold-oma-cd (ss-clmdtl-oma) <= 'E141'
			   )
			or (     hold-oma-cd (ss-clmdtl-oma) >= 'E143'
			     and hold-oma-cd (ss-clmdtl-oma) <= 'E147'
			   )
                        or hold-oma-cd (ss-clmdtl-oma) = 'E149'
                        or hold-oma-cd (ss-clmdtl-oma) = 'Z606'
                        or hold-oma-cd (ss-clmdtl-oma) = 'Z607'
			or (     hold-oma-cd (ss-clmdtl-oma) >= 'Z491'
			     and hold-oma-cd (ss-clmdtl-oma) <= 'Z499'
			   )
                        or hold-oma-cd (ss-clmdtl-oma) = 'Z555'
                        or hold-oma-cd (ss-clmdtl-oma) = 'Z580'
* 2013/04/10 - end
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 5
                )
            or
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'P014'
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 6
                )
            or
* 2011/11/23 - MC22 - edit 1 to include the check of E676B - >= 20110901 - nbr of svc must be 6
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'E676'
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'B'
	         and  hold-sv-date (ss-clmdtl-oma) >= fee-effective-date
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 6
                )
            or
* 2011/11/23 - end
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'E021'
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
* 2009/05/04 - MC2 - change from 9 to 4
*                and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 9
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 4
* 2009/05/04 - end
                )
            or
* 2011/04/11 - MC18 - do not include E004C
*               (     (   hold-oma-cd (ss-clmdtl-oma) = 'E004'
*                      or hold-oma-cd (ss-clmdtl-oma) = 'E017'
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'E017'
* 2011/11/23 - MC22 - edit 1 to include the check of E025C
                       or hold-oma-cd (ss-clmdtl-oma) = 'E025'
* 2011/11/23 - end
* 2011/04/11 - end
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 10
                )
            or
                (     (   hold-oma-cd (ss-clmdtl-oma) = 'E016'
                      )
                 and  hold-oma-suff  (ss-clmdtl-oma) = 'C'
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) not = 20
                )
         )
    then
        move 119                                to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif

 
* 2010/04/14 - MC6 - include G060 and G061
*    if   (     (    (hold-oma-cd (ss-clmdtl-oma) = 'G123'  or  hold-oma-cd (ss-clmdtl-oma) = 'E719')
     if   (     (    (    hold-oma-cd (ss-clmdtl-oma) = 'G123'
                       or hold-oma-cd (ss-clmdtl-oma) = 'E719'
                       or hold-oma-cd (ss-clmdtl-oma) = 'G060'
                       or hold-oma-cd (ss-clmdtl-oma) = 'G061'
* 2013/04/10 - MC28 - include J022
                       or hold-oma-cd (ss-clmdtl-oma) = 'J022'
* 2013/04/10 - end  

                     )
* 2010/04/14 - end
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) > 4
                )
            or
* 2010/04/14 - MC6 - include G292
*               (    (hold-oma-cd (ss-clmdtl-oma) = 'G265')
                (    (   hold-oma-cd (ss-clmdtl-oma) = 'G265'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G292'
* 2011/11/23 - MC22 - edit 12 to include check of E837 and G285
                      or hold-oma-cd (ss-clmdtl-oma) = 'E837'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G285'
* 2011/11/23 - end
                     )
* 2010/04/14 - end
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) > 3
                )
            or
* 2010/0R4/14 - M64 - include G218, G219, H104, H134, H124, H154
*               (    (hold-oma-cd (ss-clmdtl-oma) = 'G385'  or  hold-oma-cd (ss-clmdtl-oma) = 'E720')
                (    (   hold-oma-cd (ss-clmdtl-oma) = 'G385'
                      or hold-oma-cd (ss-clmdtl-oma) = 'E720'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G218'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G219'
                      or hold-oma-cd (ss-clmdtl-oma) = 'H104'
                      or hold-oma-cd (ss-clmdtl-oma) = 'H134'
                      or hold-oma-cd (ss-clmdtl-oma) = 'H124'
                      or hold-oma-cd (ss-clmdtl-oma) = 'H154'
* 2011/04/11 - MC18 - include G480, G482, G483, G372, G379, G215 or E542
                      or hold-oma-cd (ss-clmdtl-oma) = 'G480'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G482'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G483'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G372'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G379'
* 2011/11/23 - MC22 - edit 12 to exclude the check of G215
*                     or hold-oma-cd (ss-clmdtl-oma) = 'G215'
* 2011/11/23 - end
                      or hold-oma-cd (ss-clmdtl-oma) = 'E542'
* 2011/04/11 - end
                     )
* 2010/04/14 - end
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) > 2
                )
            or
* 2010/04/14 - MC6 - include G223, G220, G291, G237, Z316, G395, G523, G443, G530
*               (    (hold-oma-cd (ss-clmdtl-oma) = 'E702'  or  hold-oma-cd (ss-clmdtl-oma) = 'E717')
                (    (   hold-oma-cd (ss-clmdtl-oma) = 'E702'
                      or hold-oma-cd (ss-clmdtl-oma) = 'E717'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G223'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G220'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G291'
* 2011/11/23 - MC22 - edit 12 to exclude the check of G237 but include the check of G286, G700, Z546, Z566
*                     or hold-oma-cd (ss-clmdtl-oma) = 'G237'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G286'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G700'
                      or hold-oma-cd (ss-clmdtl-oma) = 'Z546'
                      or hold-oma-cd (ss-clmdtl-oma) = 'Z566'
* 2011/11/23 - end

* MC36 - edit 12 to exclude the check of Z316
*                     or hold-oma-cd (ss-clmdtl-oma) = 'Z316'
* MC36 - end

                      or hold-oma-cd (ss-clmdtl-oma) = 'G395'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G523'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G443'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G530'
* 2011/04/11 - MC18 - include E082, E083, E409, E410, Z441, G370, G328, G420, E158, E159, J025, G521
                      or hold-oma-cd (ss-clmdtl-oma) = 'E082'
                      or hold-oma-cd (ss-clmdtl-oma) = 'E083'
                      or hold-oma-cd (ss-clmdtl-oma) = 'E409'
                      or hold-oma-cd (ss-clmdtl-oma) = 'E410'
* MC43 - error applies to Z441A only
*                     or hold-oma-cd (ss-clmdtl-oma) = 'Z441'
                      or (    hold-oma-cd (ss-clmdtl-oma) = 'Z441'
	                  and hold-oma-suff (ss-clmdtl-oma) = 'A'
			)	
* MC43 - end
                      or hold-oma-cd (ss-clmdtl-oma) = 'G370'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G328'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G420'
* 2011/05/19 - MC20 - include suffix A for E158 or E159
*                     or hold-oma-cd (ss-clmdtl-oma) = 'E158'
*                     or hold-oma-cd (ss-clmdtl-oma) = 'E159'
  		      or (    hold-oma-cd (ss-clmdtl-oma) = 'E158'
                          and hold-oma-suff(ss-clmdtl-oma) = 'A'
                         )
                      or (    hold-oma-cd (ss-clmdtl-oma) = 'E159'
                          and hold-oma-suff(ss-clmdtl-oma) = 'A'
                         )
* 2013/04/10 - MC28 - include J021
                      or hold-oma-cd (ss-clmdtl-oma) = 'J021'
* 2013/04/10 - end
* 2011/05/19 - end
                      or hold-oma-cd (ss-clmdtl-oma) = 'J025'
                      or hold-oma-cd (ss-clmdtl-oma) = 'G521'
* 2011/04/11 - end

                     )
* 2010/04/14 - end
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) > 1
                )
* 2010/04/14 - MC6 - include new condition
            or
                (    (   hold-oma-cd (ss-clmdtl-oma) = 'G221'
* 2011/04/11 - MC18 - include G489
                      or hold-oma-cd (ss-clmdtl-oma) = 'G489'
* 2011/04/11 - end
* 2015/07/27 - MC40 - include G371
                      or hold-oma-cd (ss-clmdtl-oma) = 'G371'
* 2015/07/27 - end
                     )
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) > 5
                )
* 2010/04/14 - end
 
* 2011/11/23 - MC22 - include new condition
            or
                (    (   hold-oma-cd (ss-clmdtl-oma) = 'K630'
                     )
                 and  hold-sv-nbr-serv (ss-clmdtl-oma) > 6
                )
* 2011/11/23 - end
         )
    then
        move 130                                to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-10.
*   (else)
*   endif

* 2010/04/14 - MC6 - error 132 & 133 are  no longer needed
*   if	    hold-sv-date(ss-clmdtl-oma) > "20080131" 
*	and hold-oma-cd (ss-clmdtl-oma) = "P022" 
*   then
*       move 132                            to err-ind
*       perform za0-common-error            thru za0-99-exit
*       go to wa0-10.
*    end if

*   if	    hold-sv-date(ss-clmdtl-oma) > "20080131" 
*	and hold-oma-cd (ss-clmdtl-oma) = "K120" 
*   then
*       move 133                            to err-ind
*       perform za0-common-error            thru za0-99-exit
*       go to wa0-10.
*    end if
* 2010/04/14 - end

* 2010/04/14 - MC6 - no check on date
*   if	    hold-sv-date(ss-clmdtl-oma) > "20071231" 
*	and ws-doc-spec-cd not = "00"
* 2011/08/22 - MC21
*   if      ws-doc-spec-cd not = "00"
    if      ws-doc-spec-cd = "26"
* 2011/08/22 - end
* 2010/04/14 - end
	and hold-oma-cd (ss-clmdtl-oma) = "A007" 
    then
        move 134                            to err-ind
        perform za0-common-error            thru za0-99-exit
        go to wa0-10.
*    end if

* 2008/04/30 - end

* 2010/05/27 - MC6 - more edit check
* 2011/04/11 - MC18 -comment out - no longer needed
*     if    hold-oma-cd (ss-clmdtl-oma) = "Z432"
*       and hold-oma-suff (ss-clmdtl-oma) = "C"
*       and hold-sv-date (ss-clmdtl-oma) > "20090930"
*     then
*         move 143                        to      err-ind
*          perform za0-common-error            thru za0-99-exit
*	  go to wa0-10.
*    endif
* 2011/04/11 - end

    if   hold-oma-cd(ss-clmdtl-oma) = 'G489' or 'S323'
*           (check the patient's age )
    then
        move    hold-sv-date(ss-clmdtl-oma)     to ws-sv-date
        move    ws-pat-birth-date               to ws-birth-date
        compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000
        if  date-difference-in-days < 16
        then
          move 145                        to      err-ind
          perform za0-common-error            thru za0-99-exit
	  go to wa0-10.
*       endif
*    endif

* 2011/04/11 - MC18 - comment out
**     if    hold-oma-cd-alpha(ss-clmdtl-oma) =   "H"
**       and batctrl-agent-cd not = 2                  
* 2010/09/21 - MC13
**       and batctrl-agent-cd not = 9                  
* 2010/09/21 - end
**       and batctrl-bat-clinic-nbr-1-2 = 22  
* 2010/12/08 - MC11 - change to H1xx or H055 or H065
*      and hold-oma-cd (ss-clmdtl-oma) not = "H007"
*      and hold-oma-cd (ss-clmdtl-oma) not = "H001"
*      and hold-oma-cd (ss-clmdtl-oma) not = "H002"
*      and hold-oma-cd (ss-clmdtl-oma) not = "H003"
**       and (     hold-oma-cd (ss-clmdtl-oma) = 'H055'
**            or  hold-oma-cd (ss-clmdtl-oma) = 'H065'
**             or (    hold-oma-cd (ss-clmdtl-oma) >= 'H100'
**                 and hold-oma-cd (ss-clmdtl-oma) <= 'H199'
**                )
**           )
* 2010/12/08 - end
**     then
**          move 147                        to      err-ind
**          perform za0-common-error            thru za0-99-exit
**	  go to wa0-10.
*    endif
* 2011/04/11 - end

* 2011/11/23 - MC22 - edit 20 to exclude the check of A197 and A198
*   if   hold-oma-cd(ss-clmdtl-oma) = 'S322' or 'S326' or 'A197' or 'A198'
    if   hold-oma-cd(ss-clmdtl-oma) = 'S322' or 'S326' 
* 2011/11/23 - end
*           (check the patient's age )
    then
        move    hold-sv-date(ss-clmdtl-oma)     to ws-sv-date
        move    ws-pat-birth-date               to ws-birth-date
        compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000
        if  date-difference-in-days > 15
        then
          move 149                        to      err-ind
          perform za0-common-error            thru za0-99-exit
	  go to wa0-10.
*       endif
*    endif

    if    hold-oma-cd(ss-clmdtl-oma) = 'H267'
    then
*           (check the patient's age )
        move    hold-sv-date(ss-clmdtl-oma)     to ws-sv-date
        move    ws-pat-birth-date               to ws-birth-date
        if    ws-sv-date not = ws-birth-date
        then
          move 150                        to      err-ind
          perform za0-common-error            thru za0-99-exit
	  go to wa0-10.
*	endif
*    endif

* IF code is Gnnnc except if the code is G431c or G478c or G479c
* 2011/04/11 - MC18 - include E409, E410 or E411
*    if    hold-oma-cd-alpha(ss-clmdtl-oma) =   "G"
     if    (   hold-oma-cd-alpha(ss-clmdtl-oma) =   "G"
            or hold-oma-cd(ss-clmdtl-oma) = 'E409'
            or hold-oma-cd(ss-clmdtl-oma) = 'E410'
            or hold-oma-cd(ss-clmdtl-oma) = 'E111'
            )
* 2011/04/11 - end
       and hold-oma-suff  (ss-clmdtl-oma) =  "C"
       and (   (hold-oma-cd (ss-clmdtl-oma) not = "G431"
            and hold-oma-cd (ss-clmdtl-oma) not = "G478"
            and hold-oma-cd (ss-clmdtl-oma) not = "G479")
             or hold-oma-suff (ss-clmdtl-oma) not = "C"   
	   )
     then
          move 153                        to      err-ind
          perform za0-common-error            thru za0-99-exit
	  go to wa0-10.
*    endif

    if   hold-oma-cd(ss-clmdtl-oma) = 'A765' or 'C765'
*           (check the patient's age )
    then
        move    hold-sv-date(ss-clmdtl-oma)     to ws-sv-date
        move    ws-pat-birth-date               to ws-birth-date
        compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000
        if  date-difference-in-days > 16
        then
          move 154                        to      err-ind
          perform za0-common-error            thru za0-99-exit
	  go to wa0-10.
*       endif
*    endif


* 2011/12/05 - edit 34  
    if    ws-doc-spec-cd = 7
*           (check the patient's age )
    then
        move    hold-sv-date(ss-clmdtl-oma)     to ws-sv-date
        move    ws-pat-birth-date               to ws-birth-date
        compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000
       if       (hold-oma-cd(ss-clmdtl-oma) = 'A775' or 'W775' or 'C775')
              and date-difference-in-days < 65
              and hold-diag-cd (ss-clmdtl-oma) not = 290
        then
          move 155                        to      err-ind
          perform za0-common-error            thru za0-99-exit
	  go to wa0-10.
*	endif
*    endif

* 2011/12/05 - MC22 - edit 65 to use same error message 155 as for edit 34 above
    if    ws-doc-spec-cd = 19
*           (check the patient's age )
    then
        move    hold-sv-date(ss-clmdtl-oma)     to ws-sv-date
        move    ws-pat-birth-date               to ws-birth-date
        compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000
       if       (hold-oma-cd(ss-clmdtl-oma) = 'A191' or 'A192')
              and date-difference-in-days < 65
              and hold-diag-cd (ss-clmdtl-oma) not = 290
        then
          move 155                        to      err-ind
          perform za0-common-error            thru za0-99-exit
	  go to wa0-10.
*	endif
*    endif

* 2011/12/05 - end


* 2010/05/27 - end

* 2011/11/23 - MC22 - add edit check 52

    if   hold-oma-cd(ss-clmdtl-oma) = 'A197' or 'A198'
*           (check the patient's age )
    then
        move    hold-sv-date(ss-clmdtl-oma)     to ws-sv-date
        move    ws-pat-birth-date               to ws-birth-date
        compute date-difference-in-days = (ws-sv-date - ws-birth-date) / 10000
        if  date-difference-in-days > 21
        then
          move 173                        to      err-ind
          perform za0-common-error            thru za0-99-exit
	  go to wa0-10.
*       endif
*    endif
* 2011/11/23 - end


* 2011/04/13 - MC18 - add edit check for error 159, 160, 161, 163, 164, 170

wa0-30-oma-refer.

     if    hold-oma-cd(ss-clmdtl-oma) = 'A253'
        or hold-oma-cd(ss-clmdtl-oma) = 'A256'
     then
         move clmhdr-refer-doc-nbr              to ws-chk-nbr
         if ws-chk-nbr-3  not = 8
         then
            move 159                        to      err-ind
            perform za0-common-error            thru za0-99-exit
            perform ga0-acpt-refer-doc         thru ga0-99-exit
	    go to wa0-10.
*	endif
*    endif

     if    hold-oma-cd(ss-clmdtl-oma) = 'A813'
        or hold-oma-cd(ss-clmdtl-oma) = 'A815'
        or hold-oma-cd(ss-clmdtl-oma) = 'C813'
        or hold-oma-cd(ss-clmdtl-oma) = 'C815'
* 2011/11/23 - MC22 - edit 40 to include the check of A800, C800, A801, C801, A802, C802, K224, A816, C816
        or hold-oma-cd(ss-clmdtl-oma) = 'A800'
        or hold-oma-cd(ss-clmdtl-oma) = 'C800'
        or hold-oma-cd(ss-clmdtl-oma) = 'A801'
        or hold-oma-cd(ss-clmdtl-oma) = 'C801'
        or hold-oma-cd(ss-clmdtl-oma) = 'A802'
        or hold-oma-cd(ss-clmdtl-oma) = 'C802'
        or hold-oma-cd(ss-clmdtl-oma) = 'K224'
        or hold-oma-cd(ss-clmdtl-oma) = 'A816'
        or hold-oma-cd(ss-clmdtl-oma) = 'C816'
* 2011/11/23 - end
     then
         move clmhdr-refer-doc-nbr                to ws-chk-nbr
         if ws-chk-nbr-3  not = 7
         then
            move 160                        to      err-ind
            perform za0-common-error            thru za0-99-exit
            perform ga0-acpt-refer-doc         thru ga0-99-exit
	    go to wa0-10.
*	endif
*    endif

** 2013/06/20 - MC30 - after implementation on Jun 11, 2013, now users complained problem with this edit
**                     and this one is similar to edit 39 which has removed on 2011/May/18
**                   - now that they agree to remove this edit as well. (comment out for reference)

* 2013/04/11 - MC28 - add edit 69
**     if     hold-oma-cd(ss-clmdtl-oma) not = 'A813'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'A815'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'C813'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'C815'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'A800'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'C800'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'A801'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'C801'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'A802'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'C802'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'K224'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'A816'
**        and hold-oma-cd(ss-clmdtl-oma) not = 'C816'
**     then
**         move clmhdr-refer-doc-nbr                to ws-chk-nbr
**         if ws-chk-nbr-3  = 7
**         then
**            move 180                        to      err-ind
**            perform za0-common-error            thru za0-99-exit
**            perform ga0-acpt-refer-doc         thru ga0-99-exit
**            go to wa0-10.
*	endif
*    endif

* 2013/04/11 - end


* 2011/05/19 - MC20 - user requested to remove the edit
*     if    hold-oma-cd(ss-clmdtl-oma) not = 'A253'
*       and hold-oma-cd(ss-clmdtl-oma) not = 'A256'
*     then
*         move clmhdr-refer-doc-nbr              to ws-chk-nbr
*         if ws-chk-nbr-3  = 8
*         then
*            move 161                        to      err-ind
*            perform za0-common-error            thru za0-99-exit
*            perform ga0-acpt-refer-doc         thru ga0-99-exit
*	    go to wa0-10.
*	endif
*    endif
* 2011/05/19 - end

     if   (    hold-oma-cd(ss-clmdtl-oma) = 'Z176'
            or hold-oma-cd(ss-clmdtl-oma) = 'Z154'
          ) 
* 2011/05/19 - MC20 - include suffix A
      and  hold-oma-suff(ss-clmdtl-oma) = 'A'
      and  clmhdr-manual-review not = 'Y'
      and  hold-sv-nbr-serv (ss-clmdtl-oma) > 5
     then
            move 163                        to      err-ind
* 2012/04/16 - MC23
*           perform za0-common-error            thru za0-99-exit
            perform za0-common-error            thru za0-99-exit.
*           perform la2-acpt-manual-review 	thru la2-99-exit
*	    go to wa0-10.
* 2012/04/16 - end
*	endif

     if   (    hold-oma-cd(ss-clmdtl-oma) = 'Z175'
            or hold-oma-cd(ss-clmdtl-oma) = 'Z177'
            or hold-oma-cd(ss-clmdtl-oma) = 'Z179'
            or hold-oma-cd(ss-clmdtl-oma) = 'Z190'
            or hold-oma-cd(ss-clmdtl-oma) = 'Z191'
            or hold-oma-cd(ss-clmdtl-oma) = 'Z192'
          )
* 2011/05/19 - MC20 - include suffix A
      and  hold-oma-suff(ss-clmdtl-oma) = 'A'
      and  clmhdr-manual-review not = 'Y'
      and  hold-sv-nbr-serv (ss-clmdtl-oma) > 1
     then
            move 164                        to      err-ind
* 2012/04/16 - MC23
*           perform za0-common-error            thru za0-99-exit
            perform za0-common-error            thru za0-99-exit.
*           perform la2-acpt-manual-review 	thru la2-99-exit
*	    go to wa0-10.
* 2012/04/16 - end
*	endif

* 2011/11/23 - MC22 - edit 50 to exclude the check of G567 but include the check of G571 & G584
*    if   (    hold-oma-cd(ss-clmdtl-oma) = 'G567'
     if   (    hold-oma-cd(ss-clmdtl-oma) = 'G571'
            or hold-oma-cd(ss-clmdtl-oma) = 'G578'
            or hold-oma-cd(ss-clmdtl-oma) = 'G581'
            or hold-oma-cd(ss-clmdtl-oma) = 'G584'
* 2011/11/23 - end
          )
      and  clmhdr-loc of claim-header-rec = 'G430'
      and  clmhdr-date-admit = zeros or spaces
      then
            move 170                        	to      err-ind
            perform za0-common-error            thru za0-99-exit
	    perform fa0-acpt-admit-date		thru fa0-99-exit
	    go to wa0-10.
*	endif

* 2011/04/13 - end


* 2011/05/19 - MC20  - check for sli oma code suffix
    move hold-oma-cd (ss-clmdtl-oma)            to sli-oma-code.
    move hold-oma-suff(ss-clmdtl-oma)           to sli-oma-suff.
    move loc-service-location-indicator         to sli-code.

    read  sli-oma-code-suff-mstr
        invalid key
            go to wa0-31.      

    if sli-admit-ind = 'Y' and (clmhdr-date-admit = spaces or zeroes)
    then
            move 171                        	to      err-ind
            perform za0-common-error            thru za0-99-exit
	    perform fa0-acpt-admit-date		thru fa0-99-exit
	    go to wa0-10.
*   endif

    if sli-admit-ind = 'N' and (clmhdr-date-admit not = spaces and not = zeroes)
    then
            move 172                        	to      err-ind
            perform za0-common-error            thru za0-99-exit
	    perform fa0-acpt-admit-date		thru fa0-99-exit
	    go to wa0-10.
*   endif

wa0-31.      
* 2011/05/19 - end

*       (move oma rec values needed later to calc cost to hold area --
*        note that current or previous fees are used according to year of service date entered above)

    perform wc0-move-oma-data-to-hold           thru wc0-99-exit.


*   (2001/sep/02 B.E. - removed this edit - only now warn operator if the
*    final priced OHIP amount is zero)
*   (print warning if asst/anae suffix entered and the oma code's 
*    corresponding basic value = zero)
*    if   (   (    ws-oma-suff = "B" 
*	      and  hold-oma-fee-asst (ss-clmdtl-oma, ohip) = zero
*	     )
*          or (    ws-oma-suff = "C"  
*	      and  hold-oma-fee-anae (ss-clmdtl-oma, ohip) = zero
*	     )
*         )
*     and not (   hold-icc-sec(ss-clmdtl-oma) =   "NM" 
*					      or "PF" 
*					      or "DU"
*	     )
*    then
*        move 50                                 to err-ind
*        perform za0-common-error                thru za0-99-exit.
**   (else)
**   endif

wa0-40-conseq-sv-date-nbr-1.


    perform we0-input-details-3-6               thru we0-99-exit.
    if not-ok
    then
        go to wa0-10.
*   (else)
*   endif


wa0-90-input-price-for-ic.

*       (if oma code entered has special-m-suffix-indicator set to 'y'es
*        then code may have been entered with an 'm' suffix which must be
*        changed to 'a')

    if    hold-oma-suff    (ss-clmdtl-oma )   = "M"
      and hold-oma-rec-ind (ss-clmdtl-oma, ss-special-m-suffix-ind) = "Y"
    then
        move "A"                                to hold-oma-suff (ss-clmdtl-oma).
*   (else)
*   endif


*       (zero out any non-used consecutive day fields)
    if hold-sv-day (ss-clmdtl-oma, 1) = zero
    then
        move zero                               to hold-sv-nbr (ss-clmdtl-oma, 1)
                                                   hold-sv-day (ss-clmdtl-oma, 2)
                                                   hold-sv-nbr (ss-clmdtl-oma, 2)
                                                   hold-sv-day (ss-clmdtl-oma, 3)
                                                   hold-sv-nbr (ss-clmdtl-oma, 3)
    else
        if hold-sv-day (ss-clmdtl-oma, 2) = zero
        then
            move zero                           to hold-sv-nbr (ss-clmdtl-oma, 2)
                                                   hold-sv-day (ss-clmdtl-oma, 3)
                                                   hold-sv-nbr (ss-clmdtl-oma, 3)
        else
            if hold-sv-day (ss-clmdtl-oma, 3) = zero
            then
                move zero                       to hold-sv-nbr (ss-clmdtl-oma, 3).
*           (else)
*           endif
*       endif
*   endif


*       (if an independent consideration procedure was entered then input price
*         -- otherwise go to 'end of input for line' to do final line edits)

    if     hold-sv-day ( ss-clmdtl-oma, 1) not = "MR" and not = "OP"
    then
	go to wa0-97-end-of-input-line.
*         go to wa0-acpt-clmhdr-detail.
*   endif

*       ('ic' require that operator input price)
*       ('MR' and 'OP' require that operator input price) -  91/02/13

    accept scr-hold-fee-oma.

    if hold-fee-oma (ss-clmdtl-oma) = 0
    then
        move 58                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to wa0-90-input-price-for-ic.
*   (else)
*   endif

wa0-95.
*   copy "d001_wa0_95.rtn".
    if   (    site-id = "RMA"
          and (
	           not def-agent-in-pat-diag-billing
               and not def-agent-bill-direct
	      )
         )
      or (    site-id = "HSC"
          and (
	          def-agent-alternate-funding  
      	       or def-agent-ohip        
               or def-agent-reciprocal 
	      )
         )
    then
        move "1"                                to flag
        perform ma0-acpt-verification           thru ma0-99-exit
        if flag-accept = 'Y'
        then
            next sentence
        else
            if flag-accept = 'M'
            then
                go to wa0-90-input-price-for-ic
            else
                if flag-accept = 'N'
                then
                    move 0                      to hold-fee-oma (ss-clmdtl-oma)
                    go to wa0-10
                else
                    move 1                      to err-ind
                    perform za0-common-error    thru za0-99-exit
                    go to wa0-95.
*               endif
*           endif
*       endif
*   endif


wa0-97-end-of-input-line.


copy "tech_prof_suff_split_part1.rtn".


    go to wa0-acpt-clmhdr-detail.


wa0-98.
    if ss-clmdtl-oma = 2
    then
        display blank-det-line-2
    else
    if ss-clmdtl-oma = 3
    then
        display blank-det-line-3
    else
    if ss-clmdtl-oma = 4
    then
        display blank-det-line-4
    else
    if ss-clmdtl-oma = 5
    then
        display blank-det-line-5
    else
    if ss-clmdtl-oma = 6
    then
        display blank-det-line-6
    else
*  sms 126 allow for 8 claim details instead of 6. s.f.
    if ss-clmdtl-oma = 7
    then
        display blank-det-line-7
    else
    if ss-clmdtl-oma = 8
    then
        display blank-det-line-8
    else
    if ss-clmdtl-oma = 9
    then
        display blank-det-line-9
    else
    if ss-clmdtl-oma = 10
    then
        display blank-det-line-10.
*   (allow 10 detail lines per screen in stead of 8)
*   (else)
*   endif


*       (subscript counting # of detail lines is 1 greater than # entered)
    subtract  1                                 from ss-clmdtl-oma.

wa0-99-exit.
    exit.
wa2-verify-nbr-svc.

*       (suffix can = a,b,c, and m.  only if suffix = a verify the
*         service date and # of services -- unless 'dd' entered is
*        'BI'lateral','M'anual 'R'review, or 'O'verride 'P'rice or 'E'mergency 'R'oom

    if   (hold-sv-day   (ss-clmdtl-oma, ss-conseq-dd) =   "BI"
                                                       or "MR"
* 2009/01/22 - MC1
						       or "ER"
* 2009/01/22 - end
                                                       or "OP")
      or (hold-oma-suff (ss-clmdtl-oma) not = "A")
    then
        go to wa2-99-exit.
*   (else)
*   endif


    move "Y"                            to flag.

*       (error if 'day' not numeric or 'nbr' = zero)
    if    hold-sv-day ( ss-clmdtl-oma, ss-conseq-dd) not numeric
       or hold-sv-nbr ( ss-clmdtl-oma, ss-conseq-dd) = 0
    then
        move "N"                        to flag
        move 1                          to err-ind
        perform za0-common-error        thru za0-99-exit
        go to wa2-99-exit.
*   (else)
*   endif

*       (err if # services from 'dd' are not within service mth unless oma suffix = 'm'ultiple)

    if hold-oma-suff ( ss-clmdtl-oma) = "M"
    then
*       ('m'ultiple service days must be within max days in mth)
        move hold-sv-date-mm (ss-clmdtl-oma)   to temp-ss
        if   hold-sv-day-num (ss-clmdtl-oma, ss-conseq-dd)
*mf             > max-nbr-days (hold-sv-date-mm (ss-clmdtl-oma) )
                > max-nbr-days (temp-ss)
        then
            move 32                     to err-ind
            go to wa2-98-err
        else
            next sentence
*       endif
    else
*       (consecutive services must fall within max days in mth)
        move hold-sv-date-mm (ss-clmdtl-oma)   to temp-ss
        if   hold-sv-day-num (ss-clmdtl-oma, ss-conseq-dd)
           + hold-sv-nbr     (ss-clmdtl-oma, ss-conseq-dd)
           - 1
*mf             > max-nbr-days (hold-sv-date-mm (ss-clmdtl-oma) )
                > max-nbr-days (temp-ss)
        then
            move 32                     to err-ind
            go to wa2-98-err.
*       (else)
*       endif
*   (else)
*   endif

*       (if oma suffix = 'm'ultiple verify 'dd' > previous 'dd' entered --
*       -- else check if 1st conseq 'dd' falls in original service consecutive sequence)
    if ss-conseq-dd = 1
        if hold-oma-suff (ss-clmdtl-oma) = "M"
        then
            if hold-sv-date-dd (ss-clmdtl-oma) < hold-sv-day-num (ss-clmdtl-oma, ss-conseq-dd)
            then
                go to wa2-99-exit
            else
                move 41                 to err-ind
                go to wa2-98-err
*           endif
        else
            if    hold-sv-date-dd  (ss-clmdtl-oma)
                + hold-sv-nbr-serv (ss-clmdtl-oma)
                     > hold-sv-day-num (ss-clmdtl-oma, ss-conseq-dd)
            then
                move 41                 to err-ind
                go to wa2-98-err
            else
                go to wa2-99-exit
*           endif
*       endif
    else
*       (if oma suffix = 'm'ultiple verify 'dd' > previous 'dd' entered --
*       -- else check if "DD" falls within previous "dd's" consecutive sequence)
        subtract  1                             from   ss-conseq-dd
                                                giving ss
        if hold-oma-suff (ss-clmdtl-oma) = "M"
        then
            if   hold-sv-day-num (ss-clmdtl-oma, ss)
               < hold-sv-day-num (ss-clmdtl-oma, ss-conseq-dd)
            then
                go to wa2-99-exit
            else
                move 41                 to err-ind
                go to wa2-98-err
*           endif
        else
            if   hold-sv-day-num ( ss-clmdtl-oma, ss)
              +  hold-sv-nbr     ( ss-clmdtl-oma, ss)
                    > hold-sv-day-num (ss-clmdtl-oma, ss-conseq-dd)
            then
                move 41                 to err-ind
                go to wa2-98-err
            else
                go to wa2-99-exit.

*           endif
*       endif
*   endif



wa2-98-err.
    perform za0-common-error                    thru za0-99-exit.
    move "N"                                    to flag.

wa2-99-exit.
    exit.



wa3-verify-serv-sys-dates.

*   (service date must not be > sys-date or 6 mths < sys-date)

    if hold-sv-date (ss-clmdtl-oma) > sys-date
    then
        move 45                 to err-ind
        move "N"                to flag
        go to wa3-99-exit.
*   endif

*   copy "d001_wa3.rtn".
*  (verify service is not 'stale dated' ie. 6 months before system date)
*  NOTE: site dependent edits!!!!!!!

*   (sms #113 - treat agent 4 as direct bill)
*   DO CASE
    if site-id = "RMA"
    then
       if      (   def-agent-ohip
               or def-agent-alternate-funding
               or def-agent-ohip-wcb
	       )
*           93/04/06 m.c. - do not check for clinic 80
*           06/05/16 b.e. - re apply edit for clniic 80
*           and clmhdr-clinic-nbr-1-2 not = '80'
           and clmhdr-manual-review = ' '
           and
               (( hold-sv-date-yy (ss-clmdtl-oma) * 365)
             + ( hold-sv-date-mm (ss-clmdtl-oma) *  30)
*               97/01/20 y.b. changed to 190 days for thekla and gordon req.
*               (6 months times 30 days + 10 days per request)
* 2011/01/26 - MC17  - change to 6 months + 20 days per Yasemin
*            +  190
* 2013/07/10 - MC31  - change to 7 months per Linda O & Yasemin
*            +  200
* MC41  - change to 232 days per Yasemin
*             +  210
             +  232
* MC41 - end
* 2013/07/10 - end
* 2011/01/26 - end
             + ( hold-sv-date-dd (ss-clmdtl-oma)      )

           <   (sys-yy * 365) + (sys-mm * 30) + sys-dd )
* 2002/05/01 - MC - temporary edit check (ignore if sv date >= 20010901)
**           and hold-sv-date (ss-clmdtl-oma) < 20010901
* 2002/05/01 - end
**           and hold-sv-date (ss-clmdtl-oma) < 20120701
        then
            move 40                 to err-ind
            move "N"                to flag
        else
            move "Y"                to flag
*	endif
    else
    if site-id = "HSC"
    then
      if      (   def-agent-ohip
               or def-agent-alternate-funding
               or def-agent-reciprocal
	      )
         and clmhdr-manual-review = ' '
         and
              (( hold-sv-date-yy (ss-clmdtl-oma) * 365)
             + ( hold-sv-date-mm (ss-clmdtl-oma) *  30)
*               (6 months times 30 days)
             +  180
             + ( hold-sv-date-dd (ss-clmdtl-oma)      )

           <   (sys-yy * 365) + (sys-mm * 30) + sys-dd )
        then
            move 40                 to err-ind
            move "N"                to flag
        else
            move "Y"                to flag.
*	endif
*   endif
*   ENDCASE


wa3-99-exit.
    exit.



wb0-read-oma-mstr.

    move ws-oma-cd      to fee-oma-cd.

    read oma-fee-mstr
        invalid key
            move "N"    to flag
            go to wb0-99-exit.

    move "Y"            to flag.
    add  1              to ctr-read-oma-mstr.

wb0-99-exit.
    exit.



wc0-move-oma-data-to-hold.
*        (move oma rec's data to the detail entry's hold area)

    move fee-tech-ind        to hold-oma-rec-ind      (ss-clmdtl-oma, ss-tech-ind       ).
    move fee-diag-ind        to hold-oma-rec-ind      (ss-clmdtl-oma, ss-diag-ind       ).
    move fee-phy-ind         to hold-oma-rec-ind      (ss-clmdtl-oma, ss-phy-ind        ).
    move fee-hosp-nbr-ind    to hold-oma-rec-ind      (ss-clmdtl-oma, ss-hosp-nbr-ind   ).
    move fee-i-o-ind         to hold-oma-rec-ind      (ss-clmdtl-oma, ss-i-o-ind        ).
    move fee-admit-ind       to hold-oma-rec-ind      (ss-clmdtl-oma, ss-admit-ind      ).
    move fee-special-m-suffix-ind to hold-oma-rec-ind (ss-clmdtl-oma, ss-special-m-suffix-ind).

    move fee-icc-sec         to hold-icc-sec         (ss-clmdtl-oma).
    move fee-icc-grp         to hold-icc-grp         (ss-clmdtl-oma).

*   (move oma rec's fees according to whether service is current or
*    previous fees
*    -- if service date is < constants mstr "CURRENT PRICES EFFECT DATE" 
*       then use previous rates)
*   (change to use f040 oma fee code's effective date rather than 
*    constants master's date)
*     if hold-sv-date (ss-clmdtl-oma) < const-effective-date (curr)
    if hold-sv-date (ss-clmdtl-oma) < fee-effective-date 
    then
        move prev                       to hold-ss-curr-prev(ss-clmdtl-oma)
    else
        move curr                       to hold-ss-curr-prev(ss-clmdtl-oma).
*   endif

    move hold-ss-curr-prev(ss-clmdtl-oma)
				      to ss-curr-prev.
    move fee-1    (ss-curr-prev, oma) to hold-oma-fee-1    (ss-clmdtl-oma, oma)
    move fee-2    (ss-curr-prev, oma) to hold-oma-fee-2    (ss-clmdtl-oma, oma)
    move fee-anae (ss-curr-prev, oma) to hold-oma-fee-anae (ss-clmdtl-oma, oma)
    move fee-asst (ss-curr-prev, oma) to hold-oma-fee-asst (ss-clmdtl-oma, oma)
    move fee-1    (ss-curr-prev,ohip) to hold-oma-fee-1    (ss-clmdtl-oma,ohip)
    move fee-2    (ss-curr-prev,ohip) to hold-oma-fee-2    (ss-clmdtl-oma,ohip)
    move fee-anae (ss-curr-prev,ohip) to hold-oma-fee-anae (ss-clmdtl-oma,ohip)
    move fee-asst (ss-curr-prev,ohip) to hold-oma-fee-asst (ss-clmdtl-oma,ohip).

    move fee-min  (ss-curr-prev,ohip) to hold-fee-min      (ss-clmdtl-oma,ohip).
    move fee-max  (ss-curr-prev,ohip) to hold-fee-max      (ss-clmdtl-oma,ohip).
*   (be2)
    move fee-min  (ss-curr-prev,ohip) to hold-fee-min      (ss-clmdtl-oma,oma ).
    move fee-max  (ss-curr-prev,ohip) to hold-fee-max      (ss-clmdtl-oma,oma ).

    move fee-add-on-cd (ss-curr-prev,1) to hold-oma-add-on-cd (ss-clmdtl-oma,1).
    move fee-add-on-cd (ss-curr-prev,2) to hold-oma-add-on-cd (ss-clmdtl-oma,2).
    move fee-add-on-cd (ss-curr-prev,3) to hold-oma-add-on-cd (ss-clmdtl-oma,3).
    move fee-add-on-cd (ss-curr-prev,4) to hold-oma-add-on-cd (ss-clmdtl-oma,4).
    move fee-add-on-cd (ss-curr-prev,5) to hold-oma-add-on-cd (ss-clmdtl-oma,5).
    move fee-add-on-cd (ss-curr-prev,6) to hold-oma-add-on-cd (ss-clmdtl-oma,6).
    move fee-add-on-cd (ss-curr-prev,7) to hold-oma-add-on-cd (ss-clmdtl-oma,7).
    move fee-add-on-cd (ss-curr-prev,8) to hold-oma-add-on-cd (ss-clmdtl-oma,8).
    move fee-add-on-cd (ss-curr-prev,9) to hold-oma-add-on-cd (ss-clmdtl-oma,9).
    move fee-add-on-cd (ss-curr-prev,10) to hold-oma-add-on-cd (ss-clmdtl-oma,10).
    move fee-oma-ind-card-requireds(ss-curr-prev) to hold-oma-ind-card-requireds(ss-clmdtl-oma).


*   (oma fee mstr records for SP add-ons should have data duplicated
*    in fee-1 and fee-2 for 'F'lat or 'P'erc rates. Some do not and
*    therefore require this logic patch)
*   (00/aug/08 B.E.
*    recognize 'add on' codes by "P"ercent/"F"lat designation rather
*    than having to have a specific ICC code)
*   if hold-icc-cd (ss-clmdtl-oma) = 'SP98'
*                                 or 'SP99'
    if fee-add-on-perc-or-flat-ind(ss-curr-prev) =   "P"
						  or "F"
    then
        perform wc1-addon-fee-fix	thru wc1-99-exit.
*   endif

    if fee-add-on-perc-or-flat-ind(ss-curr-prev) =   "P"
						  or "F"
    then
        move fee-add-on-perc-or-flat-ind(ss-curr-prev)
                 to hold-oma-rec-ind (ss-clmdtl-oma,ss-add-on-perc-or-flat-ind)
    else
        move " " to hold-oma-rec-ind (ss-clmdtl-oma,ss-add-on-perc-or-flat-ind).
*   endif

wc0-99-exit.
    exit.


wc1-addon-fee-fix.

*   (format of f040 file fees is: 99.999 allowing only 3 decimals. 2001/apr/23
*    requirement was for 4 decimal positions only for PERCENTAGE based addons.
*    Percentages were originally stored using only the numbers after the 
*    decimal place. Conversion run to multiply by 100 and now percentages
*    that were stored as .605 were stored as 60.500 . This means that 
*    when pricing claims the Percentage rates must be divided by 100 before
*    moving into pricing hold variables.
    if fee-add-on-perc-or-flat-ind(ss-curr-prev) =   "P"
    then
        compute hold-oma-fee-1 (ss-clmdtl-oma,  oma) =
 	        hold-oma-fee-1 (ss-clmdtl-oma,  oma) / 100
        compute hold-oma-fee-2 (ss-clmdtl-oma,  oma) =
 	        hold-oma-fee-2 (ss-clmdtl-oma,  oma) / 100
        compute hold-oma-fee-1 (ss-clmdtl-oma, ohip) =
 	        hold-oma-fee-1 (ss-clmdtl-oma, ohip) / 100
        compute hold-oma-fee-2 (ss-clmdtl-oma, ohip) =
 	        hold-oma-fee-2 (ss-clmdtl-oma, ohip) / 100.
*   endif

*       (if 'oma' fee-1  rate is zero, then use fee-2 and visa versa)
    if        hold-oma-fee-1 (ss-clmdtl-oma,  oma) = 0
    then
       move  hold-oma-fee-2 (ss-clmdtl-oma,  oma)       to hold-oma-fee-1(ss-clmdtl-oma,  oma)
    else
        if        hold-oma-fee-2 (ss-clmdtl-oma,  oma) = 0
        then
            move  hold-oma-fee-1 (ss-clmdtl-oma,  oma)  to hold-oma-fee-2(ss-clmdtl-oma,  oma)
        else
            next sentence.
*       endif
*   endif

*       (if 'ohip' fee-1  rate is zero, then use fee-2 and visa versa)
    if        hold-oma-fee-1 (ss-clmdtl-oma, ohip) = 0
    then
        move  hold-oma-fee-2 (ss-clmdtl-oma, ohip)      to hold-oma-fee-1(ss-clmdtl-oma, ohip)
    else
        if        hold-oma-fee-2 (ss-clmdtl-oma, ohip) = 0
        then
            move  hold-oma-fee-1 (ss-clmdtl-oma, ohip)  to hold-oma-fee-2(ss-clmdtl-oma, ohip)
        else
            next sentence.
*       endif
*   endif
*

wc1-99-exit.
    exit.


wd0-verify-clmdtl-data.

*    (if an error occurs in verifying the claim data that requires that
*     the operator re-enter the claim again , then set 'flag-err-data'
*     to "N" and return to calling routine. it will check this flag
*     and loop back thru claim data if required)

    move "Y"                            to flag-err-data.


wd0-20-verify-hosp-nbr.

*   (00/sep/25 B.E. - hospital is calculated from the location so it is
*		      longer necessary to enter/verify this value)

*   (01/nov/06 B.E. - commented out the moving of "Y' to this field when 
*    the field was then changed over to represent the PAYROLL)
*    move "Y"			to clmhdr-hosp.

*    if clmhdr-hosp = spaces
*    then
*        move "Y"                        to flag
*        move ss-hosp-nbr-ind            to ss-ind
*        perform wd1-verify-ind          thru wd1-99-exit
*                    varying ss
*                    from 1 by 1
*                    until   not-ok
*                         or ss > ss-clmdtl-oma
*        if not-ok
*        then
*            move 35                     to err-ind
*            perform za0-common-error    thru za0-99-exit
** 	    (99/may/05 B.E. - default "Y"es flag automatically
**	       perform ja0-acpt-hosp       thru ja0-99-exit
*	    move "Y"			to clmhdr-hosp
*            go to wd0-20-verify-hosp-nbr
*        else
*            next sentence
**       endif
*    else
*        next sentence.
**   endif

wd0-30-verify-admit-date.

    if clmhdr-date-admit = zero
    then
        move "Y"                        to flag
        move ss-admit-ind               to ss-ind
        perform wd1-verify-ind          thru wd1-99-exit
                    varying ss
                    from 1 by 1
                    until   not-ok
                         or ss > ss-clmdtl-oma
        if not-ok
        then
            move 38                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform fa0-acpt-admit-date thru fa0-99-exit
            go to wd0-30-verify-admit-date
        else
            next sentence
*       endif
    else
*       (verify that non-zero admit date entered is < all service dates)
        if   ( (hold-sv-date (1 ) not = zero) and (hold-sv-date (1 ) < clmhdr-date-admit) )
          or ( (hold-sv-date (2 ) not = zero) and (hold-sv-date (2 ) < clmhdr-date-admit) )
          or ( (hold-sv-date (3 ) not = zero) and (hold-sv-date (3 ) < clmhdr-date-admit) )
          or ( (hold-sv-date (4 ) not = zero) and (hold-sv-date (4 ) < clmhdr-date-admit) )
          or ( (hold-sv-date (5 ) not = zero) and (hold-sv-date (5 ) < clmhdr-date-admit) )
          or ( (hold-sv-date (6 ) not = zero) and (hold-sv-date (6 ) < clmhdr-date-admit) )
*            (sms 126 allow for 8 claim details instead of 6. s.f.)
          or ( (hold-sv-date (7 ) not = zero) and (hold-sv-date (7 ) < clmhdr-date-admit) )
          or ( (hold-sv-date (8 ) not = zero) and (hold-sv-date (8 ) < clmhdr-date-admit) )
*  	     (brad1 - allow 10 detail lines per screen instead of 8)
          or ( (hold-sv-date (9 ) not = zero) and (hold-sv-date (9 ) < clmhdr-date-admit) )
          or ( (hold-sv-date (10) not = zero) and (hold-sv-date (10) < clmhdr-date-admit) )
        then
            move 33                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform fa0-acpt-admit-date thru fa0-99-exit
            go to wd0-30-verify-admit-date
        else
            next sentence.
*       endif
*   endif


wd0-40-verify-refer-phy.

    if clmhdr-refer-doc-nbr = zero
    then
        move "Y"                        to flag
        move ss-phy-ind                 to ss-ind
* 2013/06/17 - MC29
	move "N" 			to flag-refer-doc-needed-G-codes
* 2013/06/17 - end
        perform wd1-verify-ind          thru wd1-99-exit
                    varying ss
                    from 1 by 1
                    until   not-ok
                         or ss > ss-clmdtl-oma
* 2013/06/17 - MC29
* 2013/10/31 - MC34
*       if not-ok and  flag-refer-doc-needed-G-codes = 'Y'
        if flag-refer-doc-needed-G-codes = 'Y'
* 2013/10/31 - end
	then
      	    move doc-ohip-nbr		to clmhdr-refer-doc-nbr
	    display scr-clmhdr-refer-doc
        else
* 2013/06/17 - end
        if not-ok
        then
            move 34                     to err-ind
            perform za0-common-error    thru za0-99-exit
            perform ga0-acpt-refer-doc  thru ga0-99-exit
            go to wd0-40-verify-refer-phy
        else
            next sentence
*       endif
*       endif
    else
        next sentence.
*   endif

wd0-90-set-ohip-tape-submt-ind.

*       (if 'ohip' agent then check oma codes entered against file of codes
*         that can't go on tape but must be on blue/yellow cards)

*   (sms #113 - treat agent 4 as direct bill)
    if   def-agent-ohip
      or (    def-agent-ohip-wcb
          and site-id = "RMA"
         ) 
**    (commented on oct. 31 1990 by b. langendock  sms-134)
**    or def-agent-alternate-funding
    then
*       move "Y"                             to clmhdr-tape-submit-ind
        perform wd2-verify-oma-cd-submit-ind thru wd2-99-exit
                varying ss
                from 1 by 1
                until    ss > ss-clmdtl-oma.
*                    or  clmhdr-tape-submit-ind = "N"
*   else
*       (agent not 'ohip' so claim can't go on tape)
*       move "N"                             to clmhdr-tape-submit-ind.
*   endif


wd0-99-exit.
    exit.
wd1-verify-ind.

*       (search for any oma code with a 'y' indicator -- note !!
*          -- note: the indicator must be set to 'y'es for a particular
*                   oma code and the suffix of that code must be "A" or "M" )

    if     (hold-oma-rec-ind (ss , ss-ind) = "Y")
      and  ((hold-oma-suff    (ss ) =    "A"
                                     or "M")
       or  (hold-icc-sec(ss) = 'NM' or 'PF' or 'DU'))
    then
        move "N"                        to flag.
*   (else)
*   endif

* 2013/06/17 - MC29 - check for fee-phy-ind = (ss-ind) = 2  (refer doc = 'Y'), not-ok = found records match if condition 
* 2013/10/15 - MC34 - include check of oma code starts with 'J' or 'X'
*		      and do not need to check on suffix any more
*    if    ss-ind = 2
*      and hold-oma-cd-alpha (ss) = 'G'
* 2013/09/05 - MC33- include suffix M as well
*     and hold-oma-suff  (ss) = 'A'
*      and (hold-oma-suff  (ss) = 'A' or 'M')
* 2013/09/05 - end
*      and not-ok
    
    if     (hold-oma-rec-ind (ss , ss-ind) = "Y")
      and  (ss-ind = 2)                              
      and  (   hold-oma-cd-alpha (ss) = 'G'
            or hold-oma-cd-alpha (ss) = 'J'
            or hold-oma-cd-alpha (ss) = 'X'
	   )
* 2013/10/15 - end
    then 
	move 'Y'			to flag-refer-doc-needed-G-codes.
*   endif
* 2013/06/17 - end

wd1-99-exit.
    exit.
wd2-verify-oma-cd-submit-ind.

    if hold-oma-suff(ss) = "A" or "M"
    then
        move 1 to ss-suffix
    else
        if hold-oma-suff(ss) = "B"
        then
            move 2 to ss-suffix
        else
            move 3 to ss-suffix.
*   endif

*   if hold-oma-ind-card-required(ss,ss-suffix) = "R" or "y"
    if hold-oma-ind-card-required(ss,ss-suffix) = "R"
    then
*       move "N"                        to clmhdr-tape-submit-ind
        move "Y"                        to clmhdr-manual-review
*       if hold-oma-ind-card-required(ss,ss-suffix) = "R"
*       then
            move "Y"                    to flag-desc-report-required
            move 9                      to ss.
*       else
*           move 9                      to ss.
*   endif

wd2-99-exit.
    exit.
we0-input-details-3-6.

*mf    if flag-accept not = "M"
*mf    then
*mf     move 0                                  to hold-sv-day (ss-clmdtl-oma, 1)
*mf                                                hold-sv-nbr (ss-clmdtl-oma, 1)
*mf                                                hold-sv-day (ss-clmdtl-oma, 2)
*mf                                                hold-sv-nbr (ss-clmdtl-oma, 2)
*mf                                                hold-sv-day (ss-clmdtl-oma, 3)
*mf                                                hold-sv-nbr (ss-clmdtl-oma, 3).
    if flag-accept not = "M"
    then
        move 0                                  to hold-sv-nbr (ss-clmdtl-oma, 1)
                                                   hold-sv-nbr (ss-clmdtl-oma, 2)
                                                   hold-sv-nbr (ss-clmdtl-oma, 3)
        move spaces                             to hold-sv-day (ss-clmdtl-oma, 1)
                                                   hold-sv-day (ss-clmdtl-oma, 2)
                                                   hold-sv-day (ss-clmdtl-oma, 3).
*   (else)
*   endif

    move 1                                      to ss-conseq-dd.

    accept scr-hold-sv-day-1.

*   if user enters 'M'anual 'R'eview, set the claim to be printed on card.
    if hold-sv-day(ss-clmdtl-oma,1) = "MR"
    then
        move "Y"                        to ic-flag.
*   endif

* 2009/01/22 - MC1
*   if hold-sv-day(ss-clmdtl-oma,1) = zero or " " or "BI" or "MR" or "OP"
    if hold-sv-day(ss-clmdtl-oma,1) = zero or " " or "BI" or "MR" or "OP" or "ER"
* 2009/01/22 - end
    then
        go to we0-99-exit
    else
        accept scr-hold-sv-nbr-1.
*   endif

*       (verify # of services from 'service-dd' are within days in service-mm --
*       unless oma-suff = 'm'ultiple or procedure is 'bi'lateral or an 'ic' independent consideration)
    perform wa2-verify-nbr-svc                  thru wa2-99-exit.
    if not-ok
    then
        move "N"                                to flag
        go to we0-99-exit.
*   (else)
*   endif



we0-50-conseq-sv-date-nbr-2.

    move  2                                     to ss-conseq-dd.

    accept scr-hold-sv-day-2.
    if hold-sv-day(ss-clmdtl-oma,2) = zero
    then
        go to we0-99-exit
    else
        accept scr-hold-sv-nbr-2.
*   endif

*       (verify # of services from 'service-dd' are within days in service-mm --
*       unless oma-suff = 'm'ultiple or procedure is 'bi'lateral or an 'ic' independent consideration)
    perform wa2-verify-nbr-svc                  thru wa2-99-exit
    if not-ok
    then
        move "N"                                to flag
        go to we0-99-exit.
*   (else)
*   endif


we0-60-conseq-sv-date-nbr-3.

    move  3                                      to ss-conseq-dd.

    accept scr-hold-sv-day-3.
    if hold-sv-day(ss-clmdtl-oma,3) = zero
    then
        go to we0-99-exit
    else
        accept scr-hold-sv-nbr-3.
*   endif

*       (verify # of services from 'service-dd' are within days in service-mm --
*       unless oma-suff = 'm'ultiple or procedure is 'bi'lateral or an 'ic' independent consideration)
    perform wa2-verify-nbr-svc                  thru wa2-99-exit
    if not-ok
    then
        move "N"                                to flag
        go to we0-99-exit.
*   (else)
*   endif

    move "Y"                                    to flag.

we0-99-exit.
    exit.


xa0-display-details.

    add ss-clmdtl-oma
*  sms 126 allow for 8 claim details instead of 6. s.f.
*       14                              giving pline.
*       13                              giving pline.
*       (brad1 - allow for 10 claim details instead of 8) b.e.
         10                             giving pline.

    display scr-acpt-clmhdr-det.

xa0-99-exit.
    exit.


xb0-verify-location.

    move "Y"				to flag-loc-code. 

    read loc-mstr
        invalid key
            move "N"                    to flag-loc-code
	    go to xb0-99-exit.

    add 1                               to ctr-read-loc-mstr.

* 2004/02/26 - MC - preset the value for ws-clmhdr-hosp
    move spaces				to ws-clmhdr-hosp.

* 2004/05/19 - MC - cannot recall what is 'S' stand for - ignore this value
*    if ws-iconst-clinic-card-colour = 'Y' or 'S'
    if ws-iconst-clinic-card-colour = 'Y' 
* 2004/05/19 - end
    then
	move loc-hospital-code 		to ws-clmhdr-hosp
    else 
	move loc-hospital-nbr		to ws-clmhdr-hosp.
*   endif

    display scr-hosp-nbr.   
* 2004/02/26 - end  

xb0-99-exit.
    exit.


*  copybook contains 'ya0-price-claim' logic.
copy "pricing_logic.rtn".



za0-common-error.

    move err-msg (err-ind)              to err-msg-comment.
    display err-msg-line.

    move spaces                         to continue-reply.
    display confirm.
    accept  confirm.

    if err-ind =    4
                or  9
                or 14
                or 29
                or 30
                or 31
                or 43
                or 46
                or 48
                or 51
                or 52
                or 53
		or 59
                or 84
*                or 86
*                or 87
		or 101
		or 104
		or 105
		or 106
		or 107
		or 111
* 2012/04/16 - MC23
		or 163
		or 164
* 2012/04/16 - end
    then
        if   continue-reply = "!"
*          or continue-reply = "*"
        then
            next sentence
        else
            go to za0-common-error
*       endif
    else
        next sentence.
*   endif

    display blank-line-24.

za0-99-exit.
    exit.

za1-make-them-notice-error.

    display "ENTER ! AND [NL] TO CONTINUE:".
    accept continue-reply.
    if continue-reply not = "!"
       then
          display "INVALID RESPONSE PLEASE ENTER AN ! TO CONTINUE:"
       else
          next sentence.
*   endif.
za1-99-exit.
    exit.

* MC37
zf0-test-field.

    if test-field-occ(i)  = '~'
    then
        move 'N'                        to flag
        go to zf0-99-exit.
* endif

zf0-99-exit.
exit.
* MC37 - end

zh0-initialization.

    move zeros                  to counters
                                   batctrl-rec
                                   batctrl-adj-cd
                                   clmhdr-date-admit
                                   claims-occur
                                   feedback-claims-mstr
*mf move zeros to these values
                                   ws-highest-grp-nbr
                                   ws-highest-grp-tot.

    move spaces                 to batctrl-batch-type
                                   batctrl-hosp
                                   batctrl-i-o-pat-ind
                                   claim-header-rec
                                   claim-detail-rec.

    perform uk0-zero-claim-hold-area thru uk0-99-exit.

*   (set "O"line, "W"eb, or "D"iskette source flag so that pricing logic
*    knows how to handle pricing and set 'retain' prices flag so that
*    common pricing code won't try to look at 'incoming' prices as it
*    does for 'web'/diskette uploaded claims pricing. This flag
*    also allows code to know if 'display to screen' type logic is
*    returned or not)
    move "O"                            to	flag-claim-source.
    move "N"				to	flag-retain-prices.

zh0-10-acpt-old-new-batch-opt.

    display blank-screen.
    display scr-title-batch-control-data.

*   (check if existing in progress batch and if found - fix it)
    perform zi0-process-in-progress-batch
					thru	zi0-99-exit.
    display scr-title-batch-control-data.

    display scr-old-or-new-batch-option.
    perform zh1-acpt-old-or-new-batch-opt       thru    zh1-99-exit.

*       (allow operator to shut down)
    if stop-option
    then
        go to zh0-99-exit.
*   (else)
*   endif

    if old-batch
    then
        display scr-acpt-batch-nbr
        display scr-dis-week-day
        accept  scr-acpt-batch-nbr
        accept  scr-acpt-week-day
        perform zh2-read-batctrl-file           thru    zh2-99-exit
        if   not-ok
          or batctrl-batch-type not = "C"
        then
*           (batch nbr not found in ctrl file or batch found was not a 'c'laims batch)
            move 2                              to      err-ind
            perform za0-common-error            thru    za0-99-exit
            go to zh0-10-acpt-old-new-batch-opt
        else
*           (read batch's doctor rec in doc mstr)
* MC9
*            move batctrl-bat-doc-nbr            to      doc-nbr
            move batctrl-bat-doc-nbr            to      doc-nbr of doc-mstr-rec
            perform zp0-read-doc-mstr           thru    zp0-99-exit
            if not-ok
            then
*               (serious condition !!! -- the batch's doctor has been
*                                         deleted from the doctor mstr)
                move 9                          to      err-ind
                perform za0-common-error        thru    za0-99-exit
                perform zz0-end-of-batch        thru zz0-99-exit
                go to mainline-shutdown
            else
*               (can't access batch whose status indicates it has 'gone to ohip' --
*                check password for special override privledges -- dyad personnel only)
                move "Y"                         to flag
                perform zh00-verify-batch-status thru zh00-99-exit
                if not-ok
                then
                    go zh0-10-acpt-old-new-batch-opt
                else
                    if batctrl-adj-cd-sub-type = "D"
                    then
                        move 62                 to      err-ind
                        perform za0-common-error
                        perform zz0-end-of-batch thru zz0-99-exit
                        go to zh0-10-acpt-old-new-batch-opt
                    else
*      (allow operator to override old batch ctrl estimates)
*      (set batctrl-adj-cd-sub-type to def-claim-source for existing batch)
                        move batctrl-adj-cd-sub-type    to      def-claim-source
                        perform zm0-disp-batctrl-data  thru     zm0-99-exit
                        move "Y"                        to      change-reply
                        perform zm1-allow-change-of-estimates
                                                thru    zm1-99-exit
                                until  change-reply = "N"
**  the following move statement is added by m.s. - sms 99
                        move batctrl-amt-act to ws-batctrl-amt-act
*                       (display last claim in batch if it exists)
                        if batctrl-last-claim-nbr = 0
                        then
                                next sentence
                        else
                                display scr-title-claim-rec-data
                                display scr-claim-lit
                                perform zh3-disp-last-claim-in-batch
                                                thru    zh3-99-exit
*                       endif
*                   endif
*               endif
*           endif
*       endif
    else
*     new-batch (-- prompt for batch header info)
        perform zh4-acpt-new-batch-hdr-info     thru    zh4-99-exit

*
*   (if the first character of loc-code = "*", return to 'old/new batch'
*    option -- added on 86/03/06 by m.s. - pdr 301.)

        if batctrl-loc1 = "*"
        then
            move spaces                         to batctrl-loc
            go to zh0-10-acpt-old-new-batch-opt
        else


*       (if duplicate batch # or operator rejects batch # entered then
*        return to 'old/new batch' option -- else input batctrl hash totals)
        if flag-accept = "Y"
        then
*           perform zm2-input-batctrl-est       thru    zm2-99-exit
            move "Y"                            to      change-reply
            perform zm1-allow-change-of-estimates thru  zm1-99-exit
                      until   change-reply = "N"
            move zero                           to      batctrl-last-claim-nbr
            display scr-title-claim-rec-data
            display scr-claim-lit
        else
*           (return to input another batch #)
            go to zh0-10-acpt-old-new-batch-opt.
*       endif

*   (move agent to def variable to that value can be tested later)
    move batctrl-agent-cd                       to def-agent-code.

*   (store the batch being worked in file in user's HOME directory in case
*    a recover from network loss is needed)
    perform zk0-store-in-progress-batch
					thru	zk0-99-exit.
zh0-99-exit.
    exit.



Zi0-process-in-progress-batch.

    open i-o d001-batch-in-progress.

    if status-cobol-batch-in-progress <> "00"
    then
*	(not file found so obviously no outstanding batch)
	close d001-batch-in-progress
	go to zi0-99-exit.
*   endif

*   (file found - read record and get the batch number)
    read d001-batch-in-progress
	at end 
	    close d001-batch-in-progress
	    go to zi0-99-exit.

    display ""
    display " "
    display ""
    display "           !!!!! WARNING !!!!!"
    display ""
    display " "
    display "An OUTSTANDING BATCH was found - " "[ " d001-batch-nbr " ]"
    display " "

*   (read batch and update values)
    move d001-batch-nbr 		to 	batctrl-batch-nbr.
    perform zh2-read-batctrl-file	thru    zh2-99-exit.
    if ok 
    then
*	(existing f001 record found for batch - verify all values are there)
	move "Y"			to 	d001-f001-exists-ind
	if    batctrl-batch-nbr = "        " or batctrl-batch-nbr = "00000000" 
	   or batctrl-loc = "    "           or batctrl-loc = "0000" 
	   or batctrl-agent-cd = " " 
	   or (     batctrl-i-o-pat-ind <> "I" 
		and batctrl-i-o-pat-ind <> "O" 
		and batctrl-i-o-pat-ind <> "B" 
	      )
	   or batctrl-payroll = " " or batctrl-payroll = "0"
	then
*	    (have to prompt for paramters)
	    perform zi1-ask-user-for-parameters thru zi1-99-exit
	else
	    display "LOCATION was: " batctrl-loc
	    display "AGENT    was: " batctrl-agent-cd
	    display "PAT I/O  was: " batctrl-i-o-pat-ind
	    display "PAYROLL  was: " batctrl-payroll
	    move batctrl-loc		to	d001-loc
	    move batctrl-agent-cd	to	d001-agent-cd
	    move batctrl-i-o-pat-ind	to	d001-i-o-pat-ind
	    move batctrl-payroll    	to	d001-payroll     
*	endif
    else
*	(existing f001 record not found for batch - if values not in $HOME
*	 file then prompt for them)
	if    d001-batch-nbr = "        " or d001-batch-nbr = "00000000" 
	   or d001-loc = "    " 	  or d001-loc = "0000" 
	   or d001-agent-cd = " " 
	   or (     d001-i-o-pat-ind <> "I" 
		and d001-i-o-pat-ind <> "O" 
		and d001-i-o-pat-ind <> "B" 
	      )
	   OR d001-payroll = " " or d001-payroll = "0"
	then
*	    (have to prompt for paramters)
	    perform zi1-ask-user-for-parameters thru zi1-99-exit
  	else
	    display "LOCATION was: " d001-loc
	    display "AGENT    was: " d001-agent-cd
	    display "PAT I/O  was: " d001-i-o-pat-ind
	    display "PAYROLL  was: " d001-payroll.
*	endif
*   endif

    display "Recovery of the batch will now commence - Press ENTER to BEGIN Process ...".
    accept confirm-space.
    close d001-batch-in-progress.
*   (setup macro and call process to correct the batch)
    move d001-recovery-command-line		to	macro
    call "SYSTEM" using macro.
* 2008/12/18 - MC empty the file
    open output d001-batch-in-progress.
    close d001-batch-in-progress.
* 2008/12/18 - end

zi0-99-exit.
    exit.

zi1-ask-user-for-parameters.
    display "Unfortunately all required parameters were not available.".
    display " ".
    display "For the displayed batch, please re-enter the parameters, as prompted below:".
    display " ".
    display "Enter a 6 character BATCH NUMBER:".
    accept  d001-batch-nbr.
    display "Enter a 4 character LOCATION:".
    accept  d001-loc.
    display "Enter a 1 character AGENT:".
    accept  d001-agent-cd.
    display "Enter a 1 character Patient IN/OUT:".
    accept  d001-i-o-pat-ind.
    display "Enter a 1 character Payroll:".                
    if site-id = 'RMA'
    then
     accept  d001-payroll
    else if site-id = 'HSC'
    then move 'A'	to d001-payroll
	 display d001-payroll.      
*   endif
    move "N"			   to d001-f001-exists-ind.
    display " ".
    display "Thank you!".

zi1-99-exit.
    exit.


Zk0-store-in-progress-batch.

    open output d001-batch-in-progress.

    if status-cobol-batch-in-progress <> "00"
    then
	display ""
	display " "
	display ""
	display " "
	display ""
	display "           !!!!! ERROR !!!!!"
	display ""
	display " "
	display ""
	display " "
	display "The file which stores the batch you were working on CAN'T BE READ!"
	display "Report this error to DYAD."
	display " "
	close d001-batch-in-progress
	go to zk0-99-exit.
*   endif

*   (file found - put current batch values into record and write to file)
    move ws-d001-command-part-1		to d001-command-part-1.
    move ws-d001-command-part-2		to d001-command-part-2.
    move spaces				to d001-space-1
					   d001-space-2
					   d001-space-3
					   d001-space-4
					   d001-space-5
					   d001-space-6
					   d001-space-7.
    move batctrl-batch-nbr		to d001-batch-nbr.
    move batctrl-loc     		to d001-loc.
    move batctrl-agent-cd		to d001-agent-cd.
    move batctrl-i-o-pat-ind		to d001-i-o-pat-ind.
    move batctrl-payroll		to d001-payroll.
 
    write d001-batch-in-progress-rec.
    close d001-batch-in-progress.

zk0-99-exit.
    exit.


zh00-verify-batch-status.

*       (unless operator supplies special password don't allow access
*        to any batch with status 'sent to ohip' or greater)


    if batctrl-batch-status > "1"
    then
        move 51                                 to      err-ind
        perform za0-common-error                thru    za0-99-exit
        display scr-acpt-change-password
        accept  scr-acpt-change-password
        if password-input = password-special-privledges
        then
            move "Y"                            to      flag
        else
            move "N"                            to      flag.
*       endif
*   (else)
*   endif

zh00-99-exit.
    exit.
zh1-acpt-old-or-new-batch-opt.

    accept scr-old-or-new-batch-option.
    if   old-batch
      or new-batch
      or stop-option
    then
        next sentence
    else
        move 1                          to      err-ind
        perform za0-common-error        thru    za0-99-exit
        go to zh1-acpt-old-or-new-batch-opt.

zh1-99-exit.
    exit.



zh2-read-batctrl-file.

    move batctrl-batch-nbr                      to key-batctrl-file.

    read batch-ctrl-file  key is key-batctrl-file
        invalid key
                move "N"                        to      flag
                go to zh2-99-exit.

    move "Y"                                    to      flag.
    add  1                                      to      ctr-read-batctrl-mstr.

zh2-99-exit.
    exit.



zh3-disp-last-claim-in-batch.

*       (read last claim's header rec)
    move batctrl-batch-nbr              to      clmhdr-batch-nbr.
    move batctrl-last-claim-nbr         to      clmhdr-claim-nbr.
    move zeros                          to      clmhdr-zeroed-oma-suff-adj.

*mf move "B"                            to      key-clm-key-type.
*mf move clmhdr-claim-id                to      key-clm-data.
    move "B"                            to      clmhdr-b-key-type.
    move clmhdr-claim-id                to      clmhdr-b-data.
    move clmhdr-key-claims-mstr         to      key-claims-mstr.

    perform ai0-read-claims-mstr        thru    ai0-99-exit.
    if not-ok
    then
*       (serious data base error !!! --
*         -- last claim nbr as stored in header rec can't be found)
        move 4                          to      err-ind
        perform za0-common-error        thru    za0-99-exit
        perform zz0-end-of-batch        thru    zz0-99-exit
        go to mainline-shutdown.
*   (else)
*   endif

* MC42 
    move clmhdr-doc-spec-cd of claim-header-rec to ws-doc-spec-cd.
* MC42 - end

*    (obtained claim hdr -- read the claim detail recs
*                        -- then display header and details)

    perform zj0-read-all-clmdtl         thru    zj0-99-exit.

    display scr-acpt-clmhdr.

*   move spaces                         to      ws-pat-ohip-mmyy.
*   display scr-clmhdr-ohip-chart.

    move clmhdr-pat-ohip-id-or-chart of claim-header-rec
* 2004/02/19 - MC
*                                        to key-pat-mstr.
                                        to key-pat-mstr of pat-mstr.
* 2004/02/19 - end

    read pat-mstr into ws-pat-mstr-rec
        invalid key
                move spaces             to ws-pat-mstr-rec.

    move ws-pat-health-nbr              to ws-scr-health-nbr.
    perform ca1-display-pat-info        thru ca1-99-exit.

    display scr-clmhdr-pat-surname.

    move ss-clmdtl-oma                  to ss-hold-clmdtl-oma.

    if ss-hold-clmdtl-oma > 0
    then
        move 1                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif

    if ss-hold-clmdtl-oma > 1
    then
        move 2                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif

    if ss-hold-clmdtl-oma > 2
    then
        move 3                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif

    if ss-hold-clmdtl-oma > 3
    then
        move 4                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif

    if ss-hold-clmdtl-oma > 4
    then
        move 5                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif

    if ss-hold-clmdtl-oma > 5
    then
        move 6                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif

*  sms 126 allow for 8 claim details instead of 6. s.f.
    if ss-hold-clmdtl-oma > 6
    then
        move 7                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif

    if ss-hold-clmdtl-oma > 7
    then
        move 8                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif
*   (brad1 - allow 10 detail lines per screen instead of 8)
    if ss-hold-clmdtl-oma > 8
    then
        move 9                          to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif
    if ss-hold-clmdtl-oma > 9
    then
        move 10                         to ss-clmdtl-oma
        perform xa0-display-details     thru xa0-99-exit.
*   (else)
*   endif

    move ss-hold-clmdtl-oma             to ss-clmdtl-oma.

    display scr-acpt-det-desc.

    display confirm.
    accept confirm.

zh3-99-exit.
    exit.


zh4-acpt-new-batch-hdr-info.

    display scr-acpt-batch-type.
*   (this pgm inputs 'c'laim type batches only)
    move "C"                            to      batctrl-batch-type.
    display scr-acpt-batch-type.

*   (determine if claim has been entered from a true 'S'ource document or from a
*    document that is 'C'omputer generated)
zh4-20-acpt-source.
    move "S"                            to      def-claim-source.
    display scr-claim-source.
    accept  scr-claim-source.

    if   source-computer-genned
      or source-source-document
    then
        move def-claim-source           to batctrl-adj-cd-sub-type
    else
        move 1                          to      err-ind
        perform za0-common-error        thru    za0-99-exit
        go to zh4-20-acpt-source.
*   endif

    move zero                           to      batctrl-batch-nbr.
    display scr-acpt-batch-nbr.
    move zero                           to      ws-hold-screen-dept.
    perform zh42-acpt-batch-nbr         thru    zh42-99-exit.

*       (allow operator to reject batch nbr entered -- if rejected then 'flag accept'
*        will direct control back to the entry of 'new/old batch' option)

    move "1"                            to      flag.
    perform ma0-acpt-verification       thru    ma0-99-exit.

    if     flag-accept = "M"
    then
        go to zh4-acpt-new-batch-hdr-info
    else
        if flag-accept = "N"
        then
            go to zh4-99-exit
        else
            next sentence.
*       endif
*   endif

*    (#######   update doc rec with new 'batch nbr' ########)
*mf rewrite     doc-mstr-rec    key is doc-nbr
    rewrite     doc-mstr-rec
        invalid key
            move 55                     to      err-ind
            perform za0-common-error    thru    za0-99-exit
*               (only display closing screen -- don't update batch rec )
            perform zz0-10              thru    zz0-99-exit
            go to mainline-shutdown.

*   (save the clinic's current 'period-end-date' and 'cycle')
    move ws-iconst-clinic-cycle-nbr     to      batctrl-cycle-nbr.
    move ws-iconst-date-period-end      to      batctrl-date-period-end.
    display scr-val-batch-period-cycle.

    display scr-acpt-mask.
    perform zh46-acpt-loc               thru    zh46-99-exit.

*   (if the first character of loc-code = "*", return to 'old/new batch'
*    option screen.  modified by m.s. on 86/03/06 - pdr 301.)

    if batctrl-loc1 = "*"
    then
        go to zh4-99-exit.
*   endif


zh4-30-acpt-agent. 

    accept scr-batctrl-agent-cd.

* 2013/01/29 - MC27 - verify agent code

    perform zh4-30-verify-agent		thru zh4-30-99-exit.

* 2013/01/29 - end

* 2005/12/15 - MC - check for agent cd
*
    if  (    site-id = "RMA"

* 2013/01/29 - MC27 - check invalid-agent-cd instead
*	and (batctrl-agent-cd = 3 or 5 or 7 or 8 )
        and invalid-agent-cd
* 2013/01/29 - end
	)
    then	
	move 112			to err-ind
	perform za0-common-error	thru za0-99-exit
        go to zh4-30-acpt-agent. 
*   endif
* 2005/12/15 - end


* 2006/07/04 - MC - check for agent cd 6 with clinic 98
*
    if  (    site-id = "RMA"
	and (batctrl-agent-cd not = 6)                  
	and (batctrl-bat-clinic-nbr-1-2 = 98) 
	)
    then	
	move 113			to err-ind
	perform za0-common-error	thru za0-99-exit
        go to zh4-30-acpt-agent. 
*   endif
* 2005/12/15 - end

*   (move agent to def variable to that value can be tested later)
    move batctrl-agent-cd                       to def-agent-code.

*   (default payroll to 'regular clinic 22' payroll)
    move "A"				to	batctrl-payroll.
    display scr-batctrl-payroll.
    perform zh48-acpt-payroll           thru    zh48-99-exit.
*   (default all claim header values' to batctrl payroll)
    move batctrl-payroll		to	clmhdr-payroll.

*    (write batctrl rec now so that another operator can't use same batch # --
*      -- set batch status to 'unbalanced')

    move "0"                            to      batctrl-batch-status.
    perform zh9-write-batctrl-file      thru    zh9-99-exit.
*   (if attempt to enter duplicate batch then 'flag accept'
*    will direct control back to the entry of 'new/old batch' option)
    if not-ok
    then
        move "N"                        to      flag-accept
        move 42                         to      err-ind
        perform za0-common-error        thru    za0-99-exit
        go to zh4-99-exit.
*    (else)
*   endif

*   (batch type must be 'C'laim and 'adjustment-code' not needed thus set to 0)
    move  0                             to      batctrl-adj-cd.

* AB ST
*   (in/out indicator defaulted from location so don't bother to accept)
*   perform zh49-acpt-i-o-pat-ind       thru    zh49-99-exit.
* AB EN

    move zero                           to      batctrl-calc-ar-due
                                                batctrl-calc-tot-rev
                                                batctrl-manual-pay-tot
                                                batctrl-amt-est
                                                batctrl-amt-act
                                                ws-batctrl-amt-act
                                                batctrl-svc-est
                                                batctrl-svc-act
                                                ws-batctrl-amt-diff
                                                ws-batctrl-svc-diff.

    display scr-lit-batctrl-data.
    display scr-val-batctrl-data.

zh4-99-exit.
    exit.

* 2013/01/29 - MC27 
copy "verify_agent_code.rtn"
     replacing  ==xx00-verify-agent==   by ==zh4-30-verify-agent==
                ==xx00-99-exit==        by ==zh4-30-99-exit==
                ==agent-2b-tested==     by ==batctrl-agent-cd==.
* 2013/01/29 - end

zh42-acpt-batch-nbr.

    accept scr-acpt-clinic-nbr-1-2.

*   added on 91/04/12 by m.c. to accept only clinic 22 and 60
*   added on 92/06/15 by m.c. to accept only clinic 22 and 60 to 65
*   pdr 561 - 93/02/10 clinic 60 no longer valid for data entry, it
*                      terminated on 92/06/30.

*   change to allow clinic 22 to 99 except for clinic 60, but such
*   clinic must define in constants mstr - sms 140 93/03/16 by m.c.


    if      batctrl-bat-clinic-nbr-1-2 > 21
        and batctrl-bat-clinic-nbr-1-2 < 100
        and batctrl-bat-clinic-nbr-1-2 not = 60
   then
        next sentence
    else
        move 64                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to zh42-acpt-batch-nbr.

    move batctrl-bat-clinic-nbr-1-2             to      iconst-clinic-nbr-1-2
                                                        ws-iconst-clinic-nbr-1-2.

*       (access isam constants master to determine if valid 2 digit clinic identifier)
    perform uj1-read-isam-const-mstr    thru    uj1-99-exit.

    if not-ok
    then
        move 20                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to zh42-acpt-batch-nbr.
*   endif


*       (display warning message if p.e.d. less than system date
*                                        pdr - 360       l.w. jan 20,88)

     if sys-date-long-r > iconst-date-period-end
     then
         move 60                        to      err-ind
         perform za0-common-error       thru    za0-99-exit
     else
         next sentence.



    if rec-locked
    then
        go to zh42-acpt-batch-nbr.
*   (else)
*   endif

* 2004/03/01 - MC - don't know why is this ?
** if not-ok
**    then
* 2004/03/01- end
*   (else)
*   endif


*       (save iconst data in working-storage area since i-o buffer area
*        is shared with other files)

    move iconst-clinic-card-colour              to ws-iconst-clinic-card-colour.
    move iconst-clinic-cycle-nbr                to ws-iconst-clinic-cycle-nbr.
    move iconst-clinic-nbr                      to ws-iconst-clinic-nbr.
    move iconst-date-period-end                 to ws-iconst-date-period-end.

*       (preset claim header clinic nbr with 4 digit clinic nbr)
    move ws-iconst-clinic-nbr                   to batctrl-clinic-nbr.

    accept scr-acpt-doc-nbr.

*    (verify batch's doc nbr, dept nbr --

*       (verify that batch nbr's doc nbr is on the doc mstr)
* MC9
*    move batctrl-bat-doc-nbr                    to doc-nbr.
    move batctrl-bat-doc-nbr                    to doc-nbr of doc-mstr-rec.
    perform zp0-read-doc-mstr                   thru zp0-99-exit.
    if not-ok
    then
        move 7                                  to err-ind
        perform za0-common-error                thru za0-99-exit
        go to zh42-acpt-batch-nbr.
*   (else)
*   endif

* 2013/07/09 - MC31
*   (warn if doctor is not active for billing (ie doc start date > system run date)
    if    doc-date-fac-start > sys-date-long
    then
	move 181 				to err-ind
        perform za0-common-error                thru za0-99-exit.
*   endif
* 2013/07/09 - end

*   (warn if doctor is terminated)
    if    doc-date-fac-term <> zero
* 2002/09/19 - MC
      and doc-date-fac-term <> spaces
* 2002/09/19 - end
      and doc-date-fac-term <  sys-date-long
    then
	move 107 				to err-ind
        perform za0-common-error                thru za0-99-exit.
*   endif

*   validate the clinic nbr with doctor master - 92/06/15 by m.c.

    if batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr
    then
        next sentence
    else
    if doc-clinic-nbr-2 not equal 0 and batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-2
    then
        next sentence
    else
    if doc-clinic-nbr-3 not equal 0 and batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-3
    then
        next sentence
    else
    if doc-clinic-nbr-4 not equal 0 and batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-4
    then
        next sentence
    else
    if doc-clinic-nbr-5 not equal 0 and batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-5
    then
        next sentence
    else
    if doc-clinic-nbr-6 not equal 0 and batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-6
    then
        next sentence
    else
        move 72                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to zh42-acpt-batch-nbr.
*   endif
*   endif
*   endif
*   endif
*   endif
*   endif

    display scr-acpt-doc-name.

    display scr-acpt-dept-nbr.
    accept scr-acpt-dept.

    if Ws-hold-screen-dept not = doc-dept
    then
        move doc-dept                           to ws-hold-screen-dept
        move 54                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to zh42-acpt-batch-nbr.
*   (else)
*   endif


*== verify that dept not equal "8" ,if clinic equal "22" or "61" to "65" ==
*== do not include clinic 60 - pdr 561 by mc

    if (ws-hold-screen-dept        = 8)        and
* 2007/07/16 - MC - do not include clinic 70's 
*       (batctrl-bat-clinic-nbr-1-2 = 22 or 61 or 62 or 63 or 64 or 65)
* 2010/03/30 - MC5 - include clinic 66
*       (batctrl-bat-clinic-nbr-1-2 = 22 or 61 or 62 or 63 or 64 or 65 or 71 or 72 or 73 or 74 or 75)
       (batctrl-bat-clinic-nbr-1-2 = 22 or 61 or 62 or 63 or 64 or 65 or 66 or 71 or 72 or 73 or 74 or 75)
* 2010/03/30 - end
* 2007/07/16 - end
    then
        move 54                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to zh42-acpt-batch-nbr.
*   (else)
*   endif


    display scr-acpt-spec-cd.

    accept scr-acpt-spec.

    if ws-doc-spec-cd = doc-spec-cd
    then
        next sentence
    else
    if ws-doc-spec-cd = doc-spec-cd-2
    then
        next sentence
    else
    if ws-doc-spec-cd = doc-spec-cd-3
    then
        next sentence
    else
        move 71                         to err-ind
        perform za0-common-error        thru za0-99-exit
        go to zh42-acpt-batch-nbr.
*   endif
*   endif
*   endif

* 2002/07/16 - MC - use the appropriate next batch nbr for each clinic nbr

    if batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr
    then 
        if doc-nx-avail-batch not < 999
        then
            move 1                                  to doc-nx-avail-batch
    	    move doc-nx-avail-batch                 to batctrl-bat-week-day-r
    	else
            add  1                                  to doc-nx-avail-batch
    	    move doc-nx-avail-batch                 to batctrl-bat-week-day-r.
*  	endif
*   endif

    if batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-2
    then 
        if doc-nx-avail-batch-2 not < 999
        then
            move 1                                  to doc-nx-avail-batch-2
    	    move doc-nx-avail-batch-2                 to batctrl-bat-week-day-r
    	else
            add  1                                  to doc-nx-avail-batch-2
    	    move doc-nx-avail-batch-2                 to batctrl-bat-week-day-r.
*  	endif
*   endif

*   move doc-nx-avail-batch                     to batctrl-bat-week-day-r.

    if batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-3
    then 
        if doc-nx-avail-batch-3 not < 999
        then
            move 1                                  to doc-nx-avail-batch-3
    	    move doc-nx-avail-batch-3                 to batctrl-bat-week-day-r
    	else
            add  1                                  to doc-nx-avail-batch-3
    	    move doc-nx-avail-batch-3                 to batctrl-bat-week-day-r.
*  	endif
*   endif

    if batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-4
    then 
        if doc-nx-avail-batch-4 not < 999
        then
            move 1                                  to doc-nx-avail-batch-4
    	    move doc-nx-avail-batch-4                 to batctrl-bat-week-day-r
    	else
            add  1                                  to doc-nx-avail-batch-4
    	    move doc-nx-avail-batch-4                 to batctrl-bat-week-day-r.
*  	endif
*   endif

    if batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-5
    then 
        if doc-nx-avail-batch-5 not < 999
        then
            move 1                                  to doc-nx-avail-batch-5
    	    move doc-nx-avail-batch-5                 to batctrl-bat-week-day-r
    	else
            add  1                                  to doc-nx-avail-batch-5
    	    move doc-nx-avail-batch-5                 to batctrl-bat-week-day-r.
*  	endif
*   endif

    if batctrl-bat-clinic-nbr-1-2 = doc-clinic-nbr-6
    then 
        if doc-nx-avail-batch-6 not < 999
        then
            move 1                                  to doc-nx-avail-batch-6
    	    move doc-nx-avail-batch-6                 to batctrl-bat-week-day-r
    	else
            add  1                                  to doc-nx-avail-batch-6
    	    move doc-nx-avail-batch-6                 to batctrl-bat-week-day-r.
*  	endif
*   endif

* 2002/07/16 - end

    display scr-dis-week-day.
    move doc-ohip-nbr                           to batctrl-doc-nbr-ohip.

zh42-99-exit.
    exit.


zh46-acpt-loc.

    accept scr-batctrl-loc.

*   (if the first character of loc-code = "*", then return to 'old/new
*    batch' option screen.  modified by m.s. on 86/03/06 - pdr 301.)

    if batctrl-loc1 = "*"
    then
        go to zh46-99-exit.
*   endif


*       (error if location not valid for doctor)
    move batctrl-loc                            to ws-loc.
    perform zr0-verify-loc-for-doc              thru zr0-99-exit.
    if not-ok
    then
        move 10                                 to err-ind
        perform za0-common-error                thru za0-99-exit
        go to zh46-acpt-loc.
*   (else)
*    endif

* AB ST
    move batctrl-loc     			to loc-nbr.
    perform xb0-verify-location			thru xb0-99-exit.
    if loc-not-found
    then
         move 102				to err-ind
	 perform za0-common-error		thru xa0-99-exit
         go to zh46-acpt-loc
    else
        if    loc-found
          and loc-active-for-entry = "N"
        then
            move 103                            to err-ind
            perform za0-common-error            thru za0-99-exit
            go to ia0-acpt-loc.
*	endif
*   endif
  
*   (2001/02/26 - MC: default i/o indicator from location and display) 
    move loc-card-colour        		to batctrl-i-o-pat-ind.
    display scr-batctrl-i-o-pat-ind.
* AB EN

zh46-99-exit.
    exit.



zh48-acpt-payroll.

*   2006/sep/21 b.e. HSC doesn't need to enter
    if site-id = "RMA"
    then
        accept scr-batctrl-payroll
    else
        move "A"			to batctrl-payroll
        display scr-batctrl-payroll.
*   end if


*   ('A' - normal '22' payroll
*    'B' - ICU payroll)
    if batctrl-payroll     <> "A"
		       and <> "B"
    then
	move 104				to err-ind
	perform za0-common-error		thru za0-99-exit
	go to zh48-acpt-payroll
    else
*	(doctors in dept   15 are paid only in payroll "B")
*	CASE

*   2004/03/03 - MC - temporary comment out the edit below  
* 	if    doc-dept = 15
*         and batctrl-payroll <> "B" 	
*	then	
*	    move 105				to err-ind
*	    perform za0-common-error		thru za0-99-exit
*	    go to zh48-acpt-payroll
*	else
* 2004/03/03 - end

*   2004/03/04 - MC - reinstate comment out the edit above
*                    and add additional check with doc-afp-paym-group


* 2004/07/13 - MC - comment out the edit below, there is no more payroll B
**        if    doc-dept = 15
**          and batctrl-payroll <> "B"
**          and doc-afp-paym-group = ' '
**        then
**            move 105                            to err-ind
**            perform za0-common-error            thru za0-99-exit
**            go to zh48-acpt-payroll
**        else
* 2004/07/13 - end

* 2004/03/04 - end

* 2004/07/08 - MC - Yasemin requested to comment out the following edit check
*	(warning if not payroll B and doctor does bill in ICU (clinic 81)
**	if    batctrl-payroll <> "B" 	
*	  and (   doc-clinic-nbr-2 = "81"
*              or doc-clinic-nbr-3 = "81"
*	       or doc-clinic-nbr-4 = "81"
*	       or doc-clinic-nbr-5 = "81"
*	       or doc-clinic-nbr-6 = "81"
*	      )
*	then	
*	    (warning only)
*	    move 106				to err-ind
*	    perform za0-common-error		thru za0-99-exit
*	else	

* 2004/07/08 - end
  	    next sentence.
*	ENDCASE
*   endif


zh48-99-exit.
    exit.

* AB ST
*zh49-disp-i-o-pat-ind.
*   move batctrl-loc     to loc-nbr.
*   read loc-mstr
*        invalid key
*        move "LOCATIONS is not found in the LOACTION MASTER file" to err-msg-comment
*        display err-msg-line
*        go to zh49-999-exit.
*   display scr-batctrl-i-o-pat-ind.
*zh49-999-exit.
*exit
* AB EN

zh9-write-batctrl-file.

    move sys-date                               to batctrl-date-batch-entered.

    move batctrl-batch-nbr                      to key-batctrl-file.

*mf write   batctrl-rec   key is  key-batctrl-file
    write   batctrl-rec
        invalid key
            move "N"                            to flag
            go to zh9-99-exit.

    move "Y"                                    to flag.
    add  1                                      to ctr-writ-batctrl-file.

zh9-99-exit.
    exit.
zj0-read-all-clmdtl.

    move zero                           to ss-clmdtl-oma
                                           ss-clmdtl-desc.
zj0-10-read-index-rec.
    perform zj00-read-clmdtl-rec        thru zj00-99-exit.

*    (if rec read represents a detail rec within the same claim --
*       - then move record to hold area)
    if  ok
    then
        perform zj02-move-clmdtl-to-hold-area   thru zj02-99-exit
*       (stop data entry if max # of entries have been made)
        if ss-clmdtl-desc < ss-max-nbr-of-desc-rec-allow
        then
            go to zj0-10-read-index-rec
        else
            next sentence
*       endif
    else
        next sentence.
*   endif

zj0-99-exit.
    exit.
zj00-read-clmdtl-rec.

    read    claims-mstr    next   into claim-detail-rec
        at end
            move "N"                            to flag
            go to zj00-99-exit.

*       (check if this record belongs to the claim)

*tobefixed*
*mf    retrieve claims-mstr     key fix position
*mf     into key-claims-mstr.
*mf if    (key-clm-key-type  = "B")
    if    (clmdtl-b-key-type  = "B")
      and (    clmdtl-batch-nbr = clmhdr-batch-nbr
           and clmdtl-claim-nbr = clmhdr-claim-nbr)
    then
        move "Y"                                to flag
    else
        move "N"                                to flag.
*   endif

zj00-99-exit.
    exit.
zj02-move-clmdtl-to-hold-area.

    if clmdtl-oma-cd = "ZZZZ"
    then
*       (description rec)
        add 1                           to           ss-clmdtl-desc
        move clmdtl-desc                to hold-desc (ss-clmdtl-desc)
    else
*       (claim detail rec)
        add 1                           to                   ss-clmdtl-oma
        move clmdtl-oma-cd              to hold-oma-cd      (ss-clmdtl-oma)
        move clmdtl-oma-suff            to hold-oma-suff    (ss-clmdtl-oma)
        move clmdtl-nbr-serv            to hold-sv-nbr-serv (ss-clmdtl-oma)
        move clmdtl-sv-date             to hold-sv-date     (ss-clmdtl-oma)
        move clmdtl-diag-cd             to hold-diag-cd     (ss-clmdtl-oma)
        perform zj020-move-conseq-sv-day thru zj020-99-exit
                    varying   ss
                    from  1 by 1
                    until     ss > 3
        move clmdtl-fee-oma             to hold-fee-oma     (ss-clmdtl-oma)
        move clmdtl-fee-ohip            to hold-fee-ohip    (ss-clmdtl-oma).
*    endif

zj02-99-exit.
    exit.



zj020-move-conseq-sv-day.

    move clmdtl-sv-nbr (ss)     to hold-sv-nbr (ss-clmdtl-oma, ss).
    move clmdtl-sv-day (ss)     to hold-sv-day (ss-clmdtl-oma, ss).

zj020-99-exit.
    exit.

zl2-preset-clmdtl-data.

*       (preset clmdtl rec data which is common to clmhdr rec data)

    move spaces                         to claim-detail-rec.
    move clmhdr-claim-id                to clmdtl-id.

    move clmhdr-cycle-nbr               to clmdtl-cycle-nbr.
    move clmhdr-date-period-end         to clmdtl-date-period-end.
    move clmhdr-agent-cd                to clmdtl-agent-cd.
    move clmhdr-adj-cd                  to clmdtl-adj-cd.
    move clmhdr-orig-batch-id           to clmdtl-orig-batch-id.

zl2-99-exit.
    exit.

zm0-disp-batctrl-data.

    display scr-acpt-batch-type.
    display scr-val-batch-period-cycle.
    display scr-claim-source.
    display scr-acpt-mask.
    display scr-lit-batctrl-data.

    subtract batctrl-amt-act                    from      batctrl-amt-est
                                                giving ws-batctrl-amt-diff.
    subtract batctrl-svc-act                    from      batctrl-svc-est
                                                giving ws-batctrl-svc-diff.
    display scr-val-batctrl-data.

zm0-99-exit.
    exit.



zm1-allow-change-of-estimates.

    display scr-acpt-change-verification.
    accept  scr-acpt-change-verification.

    if change-reply = "Y"
    then
        display scr-acpt-change-password
        accept  scr-acpt-change-password
        if password-input  =  password  or password-special-privledges
        then
            perform zm2-input-batctrl-est       thru zm2-99-exit
            go to zm1-allow-change-of-estimates
        else
            move 3                              to err-ind
            perform za0-common-error            thru za0-99-exit
            go to zm1-allow-change-of-estimates.
*       endif
*    (else)
*    endif

zm1-99-exit.
    exit.



zm2-input-batctrl-est.

*     (input estimate of total fee amounts in batch -- if special password used then allow changing of 'actual' values)

    accept scr-amt-est.

*       (if special password is entered then allow updating of the
*        the batch control rec's actual values -- this is to be done
*        only by dyad staff to correct the batctrl rec when it
*        differs from the actaul value of records in the batch. this
*        would happen if the data entry program crashed or if the system
*        went down while the data entry program was running (d001).
*        this discrepancy would be shown in reports r002a or r002b)

    if password-input = password-special-privledges
    then
        accept scr-amt-act.
    subtract batctrl-amt-act                    from      batctrl-amt-est
                                                giving ws-batctrl-amt-diff.
    display scr-amt-diff.

*     (input estimate of total number of services in batch)
    accept scr-svc-est.
    if password-input = password-special-privledges
    then
        accept scr-svc-act.
    subtract batctrl-svc-act                    from      batctrl-svc-est
                                                giving ws-batctrl-svc-diff.
    display scr-svc-diff.

zm2-99-exit.
    exit.

zp0-read-doc-mstr.

*mf    read doc-mstr
*MC9
*    read doc-mstr      key is doc-nbr
    read doc-mstr      key is doc-nbr of doc-mstr-rec
        invalid key
                move "N"                to flag
                go to zp0-99-exit.

    move "Y"                            to flag.
    add  1                              to ctr-read-doc-mstr.

*       (save doc data in working-storage since i-o buffer area
*        is shared with other files)

    move doc-nx-avail-batch                     to ws-doc-nx-batch-nbr.
    move doc-dept                               to ws-doc-dept.
    move doc-ohip-nbr                           to ws-doc-ohip-nbr.
    move doc-spec-cd                            to ws-doc-spec-cd.
    move doc-locations                          to ws-doc-locations.


zp0-99-exit.
    exit.

zr0-verify-loc-for-doc.

*
*   (add the following edit check for doc-loc on 85/12/18 by m.s.-pdr291.)
*

    if ws-loc = spaces
    then
        move "N"                                to flag
        go to zr0-99-exit.
*   endif

*       (if clmhdr's loc matches any of the doc rec's loc values then
*        the flag is set to 'ok' upon return from zr1)

    move "N"                                    to flag.
    perform zr1-search-doc-loc-tbl              thru zr1-99-exit
                varying  ss
                from  1  by 1
                until   ss > ss-max-nbr-locs-in-doc-rec
                     or flag = "Y".

zr0-99-exit.
    exit.


zr1-search-doc-loc-tbl.

    if ws-loc = ws-doc-loc(ss)
    then
        move "Y"                                to flag
    else
        if ws-doc-loc(ss) = spaces
        then
            move ss-max-nbr-locs-in-doc-rec     to ss.
*       (else)
*       endif
*    endif

zr1-99-exit.
    exit.



zs0-verify-hosp.

    copy "hospital.dc".

*   copy "d001_zs0.rtn".
    if  (    site-id = "RMA"
         and clmhdr-hosp =   "A"
	  		  or "B"
                          or "C"
                          or "D"
                          or "E"
                          or "F"
                          or "G"
                          or "H"
                          or "I"
                          or "J"
                          or "K"
                          or "L"
                          or "M"
                          or "N"
                          or "O"
                          or "P"
                          or "Q"
                          or "R"
                          or "S"
                          or "T"
                          or "U"
                          or "V"
                          or "W"
                          or "X"
                          or "Y"
                          or "Z"
                          or "1"
                          or "2"
                          or "3"
                          or "4"
                          or "5"
                          or "6"
                          or "7"
                          or "8"
                          or "9"
	)
     or (
	     site-id = "HSC"
         and clmhdr-hosp =   "G"     
                          or "K"     
                          or "M"     
                          or "S"     
                          or "T"     
                          or "W"     
	)
    then     
        move "Y"                        to flag     
    else     
        move "N"                        to flag.     
*   endif


zs0-99-exit.
    exit.



zt0-verify-i-o-pat-ind.

*       (in/out indicator must be 'i'n , 'o'ut, or 'b'oth)
    if   ws-i-o-pat-ind =    "I"
                          or "O"
                          or "B"
    then
        move "Y"                        to flag
    else
        move "N"                        to flag
        move 12                         to err-ind
        perform za0-common-error        thru za0-99-exit.

zt0-99-exit.
    exit.
zz0-end-of-batch.

*       (display batch 'hash' totals and allow operator to update)

    display scr-title-batch-control-data.
    display scr-acpt-batch-nbr.
    display scr-dis-week-day.
    perform zm0-disp-batctrl-data          thru zm0-99-exit.
    move "Y"                               to change-reply.
    perform zm1-allow-change-of-estimates  thru zm1-99-exit
                until    change-reply = "N".


*       (if no claims were input then delete batctr rec --
*               -- otherwise re-write updated batctrl rec)
    if batctrl-last-claim-nbr < 1
    then
        perform zz1-delete-batctrl-rec  thru zz1-99-exit
        if  ok
        then
            go to zz0-10
        else
            move 46                     to err-ind
            perform za0-common-error    thru za0-99-exit
            go to zz0-10.
*       endif
*    (else)
*    endif


*       (set batch status according to 'estimate' vs 'actual' hash totals)
    if   batctrl-amt-est = batctrl-amt-act
      or batctrl-svc-est = batctrl-svc-act
    then
*       (balanced)
        move '1'                        to batctrl-batch-status
    else
*       (unbalanced)
        move '0'                        to batctrl-batch-status.

    perform zz2-rewrite-batctrl-rec     thru zz2-99-exit.
    if not-ok
    then
        move 43                         to err-ind
        perform za0-common-error        thru za0-99-exit.
*   (else)
*   endif

zz0-10.
    display blank-screen.

    accept  sys-time                    from time.
    display scr-closing-screen-1.
    display scr-closing-screen-2.
    display scr-closing-screen-3.
    display scr-closing-screen-4.
    display confirm.


zz0-99-exit.
    exit.



zz1-delete-batctrl-rec.

    move "Y"                            to flag.

*mf delete    batch-ctrl-file   record physical key is key-batctrl-file
    delete    batch-ctrl-file
        invalid key
            move "N"                    to flag.

zz1-99-exit.
    exit.



zz2-rewrite-batctrl-rec.

*mf rewrite    batctrl-rec      key is key-batctrl-file
    rewrite    batctrl-rec
        invalid key
            move "N"                    to flag
            go to zz2-99-exit.

    move "Y"                            to flag.
    add  1                              to ctr-rewrit-batctrl-file.

zz2-99-exit.
    exit.

copy "tech_prof_suff_split_part2.rtn".

copy "y2k_default_century_year.rtn".

copy "y2k_default_sysdate_century.rtn".

copy "pricing_test_min_max_limits.rtn".

copy "desc_text_translation.rtn".

** 2004/02/19 - MC - add the subroutine
copy "process_pat_eligibility_change.rtn".
** 2004/02/19 - end

** 2010/06/21 - MC9 - add the subroutine
copy "process_rejected_claims_change.rtn".
** 2010/06/21 - end

** 2008/04/30 - MC - add the subroutine
copy "d001_newu701_oma_code_edit.rtn".
** 2008/04/30 - end