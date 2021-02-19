# process_elig_corrected_patients
# previously called  CREATE_HIST_REJECTS

# Purpose: process claims for patients with corrected eligility info 
#          indicated in file f086_pat_id 
#      AND claims that have been transferred from one patient to
#          a different patient - indicated in file f086a_orig_new_pat_ids.dat

# 2000/jun/29 B.E. renamed macro
# 2002/05/08  yas  include f086a
# 2004/02/23  M.C. transfer the calls of $cmd/f086patid and $cmd/f086a_origpatid
#		   from $cmd/letters_eligibility_info_wrong
# 2005/07/04  M.C. include to run r089_portal.qzc 
# 2010/02/11  yas  include R088a.qzc (added by MC on 2010/mar/10)

echo Running "process_elig_corrected_patients" ...


##  transfer from $cmd/letters_eligibility_info_wrong


$cmd/f086patid  
$cmd/f086a_origpatid 


cd $application_production
rm  >/dev/null  2>/dev/null  r088.txt  r088a.txt
rm  >/dev/null  2>/dev/null  r089.txt r089_portal.txt

quiz << QUIZ_EXIT
exec $obj/r088.qzc
exec $obj/r088a.qzc
exec $obj/r089.qzc
exec $obj/r089_portal.qzc
QUIZ_EXIT

# eligibility changed claims
echo Processing eligibility changed claims ...

qtp auto=$obj/u086.qtc

lp r088.txt >/dev/null  2>/dev/null
#lp r089.txt >/dev/null  2>/dev/null

qutil << QUTIL_EXIT
create file f086-pat-id
QUTIL_EXIT

# patient changed claims
echo Processing claims transferred to a new patient
qtp auto=$obj/u086a.qtc

qutil << QUTIL_EXIT
create file f086a-orig-new-pat-ids
QUTIL_EXIT

echo Done "process_elig_corrected_patients"
