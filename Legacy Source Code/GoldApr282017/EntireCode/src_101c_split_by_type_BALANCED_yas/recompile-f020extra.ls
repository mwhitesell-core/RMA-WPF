2013/Dec/18 - the following field size has increased by 1 as Yasemin requested/suggested

cpso-nbr, cmpa-nbr, cfpc-nbr, oma-nbr, rcpsc-nbr

2013/Sep/30      - change cpso-nbr from character 5 to 6
		 - Brad requested to add a new field doc-fiscal-yr-start-month 99
                   and add 20 bytes filler in f020-doctor-extra file
                 - add new fields has-valid-current-payroll-record and pay-this-doctor-ohip-premium in f020-doctor-extra file
                 - change cmpa-nbr from x(8) to x(9), cfpc-nbr from x(6) to x(7),
                   oma-nbr from x(9) to x(10), rcpsc-nbr from x(6) to x(7)


----------------------------------------------
the following programs have been recompiled due to the size changes in f020-doctor-extra

addrlabels.qzs:          to doc-nbr of f020-doctor-extra       opt             &

billinglist.qzs:    of f020-doctor-extra opt 	

d020.qks:file  f020-doctor-extra secondary

d020a.qks:file f020-doctor-extra    master

d112a.qks:file f020-doctor-extra    designer

d705.qks:file f020-doctor-extra reference

f020_new_field1_fix_fax1.qts:    to   doc-nbr of f020-doctor-extra opt		&

f020_new_field1_fix_fax2.qts:    to   doc-nbr of f020-doctor-extra opt		&

f020_new_fields1.qts:    to   doc-nbr of f020-doctor-extra opt		&

m020.qks:file f020-doctor-extra secondary

m020a.qks:file f020-doctor-extra            

peds_doc_ohip.qzs:access f020-doctor-extra   &

r124a.qzs:        link doc-nbr to doc-nbr of f020-doctor-extra  opt       &

r124a_mp.qzs:        link doc-nbr to doc-nbr of f020-doctor-extra  opt       &

relof020extra.qts:output f020-doctor-extra add on errors report

solotithe1.qts:    to doc-nbr of f020-doctor-extra

sue_cpso_numbers.qzs:access f020-doctor-extra   &

suspend_agent_detail.qts:   to  doc-nbr of f020-doctor-extra opt

suspend_dtl.qzs:    to doc-nbr of f020-doctor-extra  opt           &

t4_addrlabels.qzs:          to doc-nbr of f020-doctor-extra       opt             &

u100.qts:	  to  doc-nbr of f020-doctor-extra  optional

u100.qzs:; 2009/may/20 	MC1	- link f020-doctor-extra in access

u114a.qts:	to   doc-nbr of f020-doctor-extra opt

u114b.qts:        to   doc-nbr of f020-doctor-extra opt

u115c.qts:        to   doc-nbr of f020-doctor-extra                             &

u121.qts:access f020-doctor-extra

u122b.qts:          to doc-nbr of f020-doctor-extra opt

u127.qts:        link doc-nbr to doc-nbr of f020-doctor-extra opt	&

u902.qts:	 to  doc-nbr of f020-doctor-extra  &

u921a.qts:access f020-doctor-mstr link to f020-doctor-extra 	&

utl0020a_1.qts:          to doc-nbr of f020-doctor-extra opt		&	

utl0200.qts:	  to doc-nbr of f020-doctor-extra	opt		&

yearend_2.qts:access f020-doctor-extra
