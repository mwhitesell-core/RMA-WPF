addrlabels.qzs:          to doc-nbr of f020-doctor-extra       opt             &
addrlabels_once.qzs:          to doc-nbr of f020-doctor-extra       opt             &
billinglist.qzs:;Mar. 17/08  yas      link to f020-doctor-extra and report 
billinglist.qzs:    of f020-doctor-extra opt 	
d020.qks:; 95/nov/15 m.c.	- add f020-doctor-extra as secondary and pass
d020.qks:file  f020-doctor-extra secondary
d020.qks:                passing f020-doctor-mstr, f020-doctor-extra
d020a.qks:	receiving f020-doctor-mstr, f020-doctor-extra
d020a.qks:file f020-doctor-extra    master
d112a.qks:file f020-doctor-extra    designer
d112a.qks:      let doc-yrly-require-revenue  of f020-doctor-extra =       &
d112a.qks:      let doc-ceireq of f020-doctor-extra  			&
d112a.qks:	 = round(doc-yrly-require-revenue  of f020-doctor-extra / 12)
d112a.qks:      let doc-yrly-target-revenue of f020-doctor-extra		&
d112a.qks:      let doc-ceitar 	          of f020-doctor-extra		&
d112a.qks:	= round(doc-yrly-target-revenue  of f020-doctor-extra / 12)
d112a.qks:   then let doc-yrly-require-revenue  of f020-doctor-extra = 0
d112a.qks:   then let doc-yrly-target-revenue  of f020-doctor-extra = 0
d112a.qks:              let doc-ytdreq of f020-doctor-extra                      &
d112a.qks:              let doc-ytdtar of f020-doctor-extra                     &
d112a.qks:    let doc-yrly-require-revenue  of f020-doctor-extra  &
d112a.qks:    let doc-yrly-target-revenue  of f020-doctor-extra 	&
d112a.qks:   get f020-doctor-extra via doc-nbr using doc-nbr of f020-doctor-mstr opt
d112a.qks:   get f020-doctor-extra via doc-nbr using doc-nbr of f020-doctor-mstr opt
d112a.qks:   let doc-nbr of f020-doctor-extra = doc-nbr of f020-doctor-mstr
d112a.qks:   put f020-doctor-extra
d705.qks:;		  - add f020-doctor-extra to extract clinic status
d705.qks:file f020-doctor-extra reference
d705.qks:   get f020-doctor-extra opt
d705.qks:; 2012/10/02 - MC4 - get f020-doctor-extra to retrieve clinic status
f020_new_field1_fix_fax.qts:    to   doc-nbr of f020-doctor-extra opt		&
f020_new_field1_fix_fax1.qts:    to   doc-nbr of f020-doctor-extra opt		&
f020_new_field1_fix_fax2.qts:    to   doc-nbr of f020-doctor-extra opt		&
f020_new_fields1.qts:    to   doc-nbr of f020-doctor-extra opt		&
f020_new_fields1.qts:output f020-doctor-extra alias f020-extra-add add	&
f020_new_fields1.qts:	if not record f020-doctor-extra exists
f020_new_fields2.qts:    to   doc-nbr of f020-doctor-extra opt		
f020_new_fields2.qts:output f020-doctor-extra                         update	
f020_new_fields2_full.qts:    to   doc-nbr of f020-doctor-extra opt		&
f020_new_fields2_full.qts:output f020-doctor-extra alias f020-extra-update update		&
f020_new_fields2_full.qts:	if     record f020-doctor-extra exists
m020.qks:;		   - add f020-doctor-extra
m020.qks:file f020-doctor-extra secondary
m020.qks:	access viaindex doc-nbr using   doc-nbr of f020-doctor-extra
m020.qks:	access viaindex doc-nbr using replaced-by-doc-nbr of f020-doctor-extra
m020.qks:file f020-doctor-extra alias f020-extra-des designer open 1
m020.qks:	access viaindex doc-nbr using  replaced-by-doc-nbr of f020-doctor-extra
m020.qks:field prior-doc-nbr of f020-doctor-extra display label '(Prior Nbr:    )'
m020.qks:   field cpso-nbr of f020-doctor-extra label "CPSO "
m020.qks:field replaced-by-doc-nbr of f020-doctor-extra upshift    label 'REPLACED BY:' id same	
m020.qks:field doc-clinic-nbr-status of f020-doctor-extra
m020.qks:field doc-clinic-nbr-2-status of f020-doctor-extra &
m020.qks:field doc-clinic-nbr-3-status of f020-doctor-extra	&
m020.qks:field doc-clinic-nbr-4-status of f020-doctor-extra  id same
m020.qks:field doc-clinic-nbr-5-status of f020-doctor-extra id same 
m020.qks:field doc-clinic-nbr-6-status of f020-doctor-extra  id same 
m020.qks:field doc-spec-cd-eff-date of f020-doctor-extra id same &
m020.qks:field doc-spec-cd-2-eff-date of f020-doctor-extra id same  &
m020.qks:field doc-spec-cd-3-eff-date of f020-doctor-extra id same  &
m020.qks:	let replaced-by-doc-nbr of f020-doctor-extra = ' '
m020.qks:        display replaced-by-doc-nbr of f020-doctor-extra
m020.qks:	accept replaced-by-doc-nbr of f020-doctor-extra
m020.qks:        if replaced-by-doc-nbr of f020-doctor-extra = doc-nbr of f020-doctor-mstr
m020.qks:	if replaced-by-doc-nbr of f020-doctor-extra <> ' '
m020.qks:	   get f020-ref optional viaindex doc-nbr using replaced-by-doc-nbr of f020-doctor-extra
m020.qks:        let comline = "$cmd/transfer_f020_f027_f028 "  + doc-nbr + " " + replaced-by-doc-nbr of f020-doctor-extra
m020a.qks:file f020-doctor-extra            
mc.qts:        to 	 doc-nbr of f020-doctor-extra opt	&
mc.qts:   			final	doc-yrly-require-revenue of f020-doctor-extra
mc1.qts:          to doc-nbr of f020-doctor-extra opt		&	
mc1.qts:   			final	doc-yrly-require-revenue of f020-doctor-extra
peds_doc_ohip.qzs:access f020-doctor-extra   &
r124a.qzs:        link doc-nbr to doc-nbr of f020-doctor-extra  opt       &
r124a_icu.qzs:        link doc-nbr to doc-nbr of f020-doctor-extra  opt       &
r124a_mp.qzs:        link doc-nbr to doc-nbr of f020-doctor-extra  opt       &
relof020extra.qts:output f020-doctor-extra add on errors report
solotithe1.qts:    to doc-nbr of f020-doctor-extra
solotithe1.qts:	  and	doc-flag-primary   of f020-doctor-extra = "Y"
solotithe_brad.qts:    to doc-nbr of f020-doctor-extra
solotithe_brad.qts:select f020-doctor-extra if doc-flag-primary = "Y"
sue_cpso_numbers.qzs:access f020-doctor-extra   &
suspend_agent_detail.qts:   to  doc-nbr of f020-doctor-extra opt
suspend_agent_detail.qts:	 cpso-nbr	of f020-doctor-extra	, &
suspend_agent_detail.qts:	 cpso-nbr	of f020-doctor-extra	, &
suspend_agent_detail.qts:	 cpso-nbr	of f020-doctor-extra	, &
suspend_agent_detail.qts:   to  doc-nbr of f020-doctor-extra opt
suspend_dtl.qzs:;				include f020-doctor-extra in the access statement in order to show the clinic status
suspend_dtl.qzs:    to doc-nbr of f020-doctor-extra  opt           &
t4_addrlabels.qzs:          to doc-nbr of f020-doctor-extra       opt             &
u100.qts:;			  if f020-doctor-extra record does not exist will be included
u100.qts:;	  to  doc-nbr of f020-doctor-extra 
u100.qts:	  to  doc-nbr of f020-doctor-extra  optional
u100.qzs:; 2009/may/20 	MC1	- link f020-doctor-extra in access
u100.qzs:	link doc-nbr to doc-nbr of f020-doctor-extra opt
u114_replaced_by_u114ab.qts:	to   doc-nbr of f020-doctor-extra opt
u114_replaced_by_u114ab.qts:      =  doc-yrly-require-revenue of f020-doctor-extra
u114_replaced_by_u114ab.qts:      =  doc-ytdreq  of f020-doctor-extra  &
u114_replaced_by_u114ab.qts:         + doc-ytdreq of f020-doctor-extra
u114_replaced_by_u114ab.qts:          0   if doc-ytdreq of f020-doctor-extra >= w-doc-yrly-require-revenue &
u114_replaced_by_u114ab.qts:         - doc-ytdreq of f020-doctor-extra
u114_replaced_by_u114ab.qts:      =  doc-yrly-target-revenue of f020-doctor-extra
u114_replaced_by_u114ab.qts:      =  doc-ytdtar  of f020-doctor-extra  &
u114_replaced_by_u114ab.qts:         + doc-ytdtar of f020-doctor-extra
u114_replaced_by_u114ab.qts:          0   if doc-ytdtar of f020-doctor-extra >= w-doc-yrly-target-revenue &
u114_replaced_by_u114ab.qts:         - doc-ytdtar of f020-doctor-extra
u114_replaced_by_u114ab.qts:output f020-doctor-extra update if record f020-doctor-extra exists
u114_replaced_by_u114ab.qts:   item doc-ytdreq  final  doc-ytdreq of f020-doctor-extra + w-ep-reqrev-act
u114_replaced_by_u114ab.qts:   item doc-ytdtar  final  doc-ytdtar of f020-doctor-extra + w-ep-tarrev-act
u114a.qts:	to   doc-nbr of f020-doctor-extra opt
u114a.qts:      =  doc-yrly-require-revenue of f020-doctor-extra
u114a.qts:      =  doc-ytdreq  of f020-doctor-extra  	&
u114a.qts:         + doc-ytdreq of f020-doctor-extra
u114a.qts:          0   if doc-ytdreq of f020-doctor-extra >= w-doc-yrly-require-revenue &
u114a.qts:         - doc-ytdreq of f020-doctor-extra
u114a.qts:      =  doc-yrly-target-revenue of f020-doctor-extra
u114a.qts:      =  doc-ytdtar  of f020-doctor-extra  	&
u114a.qts:         + doc-ytdtar of f020-doctor-extra
u114a.qts:          0   if doc-ytdtar of f020-doctor-extra >= w-doc-yrly-target-revenue &
u114a.qts:         - doc-ytdtar of f020-doctor-extra
u114a.qts:doc-ytdreq  of f020-doctor-extra,&
u114a.qts:;output f020-doctor-extra update if record f020-doctor-extra exists
u114a.qts:;   item doc-ytdreq  final  doc-ytdreq of f020-doctor-extra + w-ep-reqrev-act
u114a.qts:;   item doc-ytdtar  final  doc-ytdtar of f020-doctor-extra + w-ep-tarrev-act
u114b.qts:        to   doc-nbr of f020-doctor-extra opt
u114b.qts:output f020-doctor-extra update if record f020-doctor-extra exists
u114b.qts:;  item doc-ytdreq  final  doc-ytdreq of f020-doctor-extra + w-ep-reqrev-act
u114b.qts:;  item doc-ytdtar  final  doc-ytdtar of f020-doctor-extra + w-ep-tarrev-act
u115c.qts:        to   doc-nbr of f020-doctor-extra                             &
u121.qts:access f020-doctor-extra
u121.qts:output f020-doctor-extra alias f020-update  update
u122b.qts:          to doc-nbr of f020-doctor-extra opt
u127.qts:        link doc-nbr to doc-nbr of f020-doctor-extra opt	&
u902.qts:	 to  doc-nbr of f020-doctor-extra  &
u902.qts:	 to doc-nbr of f020-doctor-extra alias f020-extra-transfer opt
u902.qts:;output f020-doctor-extra alias f020-extra-transfer add noitem on errors report
u902.qts:Item BILLING-VIA-PAPER-FLAG of f020-extra-transfer final BILLING-VIA-PAPER-FLAG of f020-doctor-extra
u902.qts:Item BILLING-VIA-DISKETTE-FLAG of f020-extra-transfer final BILLING-VIA-DISKETTE-FLAG of f020-doctor-extra
u902.qts:Item BILLING-VIA-WEB-TEST-FLAG of f020-extra-transfer final BILLING-VIA-WEB-TEST-FLAG of f020-doctor-extra
u902.qts:Item BILLING-VIA-WEB-LIVE-FLAG of f020-extra-transfer final BILLING-VIA-WEB-LIVE-FLAG of f020-doctor-extra
u902.qts:Item BILLING-VIA-RMA-DATA-ENTRY of f020-extra-transfer final BILLING-VIA-RMA-DATA-ENTRY of f020-doctor-extra
u902.qts:Item DATE-START-RMA-DATA-ENTRY of f020-extra-transfer final DATE-START-RMA-DATA-ENTRY of f020-doctor-extra
u902.qts:Item DATE-START-DISKETTE of f020-extra-transfer final DATE-START-DISKETTE of f020-doctor-extra
u902.qts:Item DATE-START-PAPER of f020-extra-transfer final DATE-START-PAPER of f020-doctor-extra
u902.qts:Item DATE-START-WEB-LIVE of f020-extra-transfer final DATE-START-WEB-LIVE of f020-doctor-extra
u902.qts:Item DATE-START-WEB-TEST of f020-extra-transfer final DATE-START-WEB-TEST of f020-doctor-extra
u902.qts:Item LEAVE-DESCRIPTION of f020-extra-transfer final LEAVE-DESCRIPTION of f020-doctor-extra
u902.qts:Item LEAVE-DATE-START of f020-extra-transfer final LEAVE-DATE-START of f020-doctor-extra
u902.qts:Item LEAVE-DATE-END of f020-extra-transfer final LEAVE-DATE-END of f020-doctor-extra
u902.qts:Item WEB-USER-REVENUE-ONLY-FLAG of f020-extra-transfer final WEB-USER-REVENUE-ONLY-FLAG of f020-doctor-extra
u902.qts:Item MANAGER-FLAG of f020-extra-transfer final MANAGER-FLAG of f020-doctor-extra
u902.qts:Item CHAIR-FLAG of f020-extra-transfer final CHAIR-FLAG of f020-doctor-extra
u902.qts:Item ABE-USER-FLAG of f020-extra-transfer final ABE-USER-FLAG of f020-doctor-extra
u902.qts:Item CPSO-NBR of f020-extra-transfer final CPSO-NBR of f020-doctor-extra
u902.qts:Item CMPA-NBR of f020-extra-transfer final CMPA-NBR of f020-doctor-extra
u902.qts:Item OMA-NBR of f020-extra-transfer final OMA-NBR of f020-doctor-extra
u902.qts:Item CFPC-NBR of f020-extra-transfer final CFPC-NBR of f020-doctor-extra
u902.qts:Item RCPSC-NBR of f020-extra-transfer final RCPSC-NBR of f020-doctor-extra
u902.qts:Item DOC-MED-PROF-CORP of f020-extra-transfer final DOC-MED-PROF-CORP of f020-doctor-extra
u902.qts:Item MCMASTER-EMPLOYEE-ID of f020-extra-transfer final MCMASTER-EMPLOYEE-ID of f020-doctor-extra
u902.qts:Item DOC-SPEC-CD-EFF-DATE of f020-extra-transfer final DOC-SPEC-CD-EFF-DATE of f020-doctor-extra
u902.qts:Item DOC-SPEC-CD-2-EFF-DATE of f020-extra-transfer final DOC-SPEC-CD-2-EFF-DATE of f020-doctor-extra
u902.qts:Item DOC-SPEC-CD-3-EFF-DATE of f020-extra-transfer final DOC-SPEC-CD-3-EFF-DATE of f020-doctor-extra
u902.qts:Item DOC-CLINIC-NBR-STATUS of f020-extra-transfer final DOC-CLINIC-NBR-STATUS of f020-doctor-extra
u902.qts:Item DOC-CLINIC-NBR-2-STATUS of f020-extra-transfer final dOC-CLINIC-NBR-2-STATUS of f020-doctor-extra
u902.qts:Item DOC-CLINIC-NBR-3-STATUS of f020-extra-transfer final DOC-CLINIC-NBR-3-STATUS of f020-doctor-extra
u902.qts:Item DOC-CLINIC-NBR-4-STATUS of f020-extra-transfer final DOC-CLINIC-NBR-4-STATUS of f020-doctor-extra
u902.qts:Item DOC-CLINIC-NBR-5-STATUS of f020-extra-transfer final DOC-CLINIC-NBR-5-STATUS of f020-doctor-extra
u902.qts:Item DOC-CLINIC-NBR-6-STATUS of f020-extra-transfer final DOC-CLINIC-NBR-6-STATUS of f020-doctor-extra
u902.qts:Item YELLOW-PAGES-FLAG of f020-extra-transfer final YELLOW-PAGES-FLAG of f020-doctor-extra
u902.qts:Item prior-doc-nbr of f020-extra-transfer final doc-nbr of f020-doctor-extra
u921a.qts:access f020-doctor-mstr link to f020-doctor-extra 	&
unlof020extra.qzs:access f020-doctor-extra
upf020extra.qts:          to doc-nbr of f020-doctor-extra opt
upf020extra.qts:output f020-doctor-extra update	alias f020-update &
upf020extra.qts:	if record f020-doctor-extra exists
upf020extra.qts:output f020-doctor-extra add alias f020-add	&
upf020extra.qts:	if not record f020-doctor-extra exists
utl0020a_1.qts:          to doc-nbr of f020-doctor-extra opt		&	
utl0020a_1.qts:   			final	doc-yrly-require-revenue of f020-doctor-extra
utl0020a_replaced_by_a_1_and_a_2.qts:        to 	 doc-nbr of f020-doctor-extra opt	&
utl0020a_replaced_by_a_1_and_a_2.qts:   			final	doc-yrly-require-revenue of f020-doctor-extra
utl0200.qts:	  to doc-nbr of f020-doctor-extra	opt		&
utl0200.qzs:	  to doc-nbr of f020-doctor-extra	opt		&
utl0200.qzs:f020-doctor-extra,				&
yearend_2.qts:;/M/ 2006/Jul/20 M. Chan        zero out require and target revenue fields in f020-doctor-extra
yearend_2.qts:access f020-doctor-extra
yearend_2.qts:output f020-doctor-extra update on errors report 
cdiserver.cbl:    copy "f020_doctor_extra_mstr.slr".
cdiserver.cbl:    copy "f020_doctor_extra_mstr.fd".
createfiles.cbl:*    copy "f020_doctor_extra_mstr.slr".
createfiles.cbl:*    copy "f020_doctor_extra_mstr.fd".
