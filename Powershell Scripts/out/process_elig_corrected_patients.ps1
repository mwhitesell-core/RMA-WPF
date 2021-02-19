#-------------------------------------------------------------------------------
# File 'process_elig_corrected_patients.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'process_elig_corrected_patients'
#-------------------------------------------------------------------------------

# process_elig_corrected_patients
# previously called  CREATE_HIST_REJECTS

# Purpose: process claims for patients with corrected eligility info 
#          indicated in file f086_pat_id 
#      AND claims that have been transferred from one patient to
#          a different patient - indicated in file f086a_orig_new_pat_ids.dat

# 2000/jun/29 B.E. renamed macro
# 2002/05/08  yas  include f086a
# 2004/02/23  M.C. transfer the calls of $cmd/f086patid and $cmd/f086a_origpatid
#                  from $cmd/letters_eligibility_info_wrong
# 2005/07/04  M.C. include to run r089_portal.qzc 
# 2010/02/11  yas  include R088a.qzc (added by MC on 2010/mar/10)

echo "Runningprocess_elig_corrected_patients ..."


##  transfer from $cmd/letters_eligibility_info_wrong


&$env:cmd\f086patid
&$env:cmd\f086a_origpatid


Set-Location $env:application_production
Remove-Item r088.txt, r088a.txt *> $null
Remove-Item r089.txt, r089_portal.txt *> $null

$rcmd = $env:QUIZ + "r088"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r088a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r089"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r089_portal"
Invoke-Expression $rcmd

# eligibility changed claims
echo "Processing eligibility changed claims ..."

$rcmd = $env:QTP + "u086"
Invoke-Expression $rcmd

Get-Content r088.txt | Out-Printer *> $null
#lp r089.txt >/dev/null  2>/dev/null

#<#$pipedInput = @"
#create file f086-pat-id
#"@

#$pipedInput | qutil++#>
#$rcmd = $env:TRUNCATE+"f086_pat_id"
#Invoke-Expression $rcmd

# patient changed claims
echo "Processing claims transferred to a new patient"
$rcmd = $env:QTP + "u086a"
Invoke-Expression $rcmd

#<#$pipedInput = @"
#create file f086a-orig-new-pat-ids
#"@

#$pipedInput | qutil++#>
#$rcmd = $env:TRUNCATE+"f086a_orig_new_pat_ids"
#Invoke-Expression $rcmd

echo "Doneprocess_elig_corrected_patients"
