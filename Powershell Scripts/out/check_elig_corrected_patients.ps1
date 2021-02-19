#-------------------------------------------------------------------------------
# File 'check_elig_corrected_patients.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_elig_corrected_patients'
#-------------------------------------------------------------------------------

# check_elig_corrected_patients

# Purpose: check patients with corrected eligibility info 
#          with patient message code and select the records with 
#          edt process date of f087 header less than last eligbility maintained
#          create a record in f086-pat-id if the criteria is met


echo "Runningcheck_elig_corrected_patients - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') "

Set-Location "\\$env:srvname\RMA\alpha\rmabill\$env:username"

Remove-Item extf010mess.sf* *> $null

Get-ChildItem f086_pat_id.dat

$rcmd = $env:QTP + "createf086"
Invoke-Expression $rcmd

Get-ChildItem f086_pat_id.dat



echo "Donecheck_elig_corrected_patients - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') "
