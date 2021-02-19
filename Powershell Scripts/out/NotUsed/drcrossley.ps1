#-------------------------------------------------------------------------------
# File 'drcrossley.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'drcrossley'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time of $env:cmd\portal_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP emergency_patient_count_dtl
&$env:QTP dept4142_doc_loc_ctas
&$env:QTP emerg_codes_4142

echo "End Time of $env:cmd\portal_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
