# check_elig_corrected_patients

# Purpose: check patients with corrected eligibility info 
#          with patient message code and select the records with 
#          edt process date of f087 header less than last eligbility maintained
#          create a record in f086-pat-id if the criteria is met


echo Running "check_elig_corrected_patients - `date` " 

cd $HOME

rm  >/dev/null  2>/dev/null  extf010mess.sf*

ls -l f086_pat_id.dat

qtp auto=$obj/createf086.qtc

ls -l f086_pat_id.dat



echo Done "check_elig_corrected_patients - `date` "
