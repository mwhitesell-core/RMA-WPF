# elig_letters_corrections_resubmits (original name)
# elig_corrections_letters_resubmits (new name)
# Purpose: create patient eligibility wrong info letters, process the claims
#	   for eligibility corrected patients, and process resubmit
#	   claims if necessary

# 2004/02/23 MC - change the filename from elig_letters_corrections_resubmits
#				       to  elig_corrections_letters_resubmit
#		- change the sequence as process the claims for eligibility
#		  corrected patients, create rejected letters/reports,
#		  process resubmit claims if necessary
# 2011/01/12 MC - transfer the call of $cmd/letter_eligibility_info_wrong
#		  to be executed after u020 in $cmd/run_ohip_submit_tape_no_directs

# Note: This macro is run by itself and 
#	called by run_ohip_submit_tape_no_directs

###echo Running "elig_letters_corrections_resubmits" ...
echo Running "elig_corrections_letters_resubmits" ...


# rename from $cmd/create_hist_rejects to --
$cmd/process_elig_corrected_patients

# 2011/01/12 - MC- comment out and transfer to other macro
#$cmd/letters_eligibility_info_wrong


if [ -f $pb_data/resubmit.required ]
then

$cmd/u022 0 0

fi

##echo Done "elig_letters_corrections_resubmits"
echo Done "elig_corrections_letters_resubmits"