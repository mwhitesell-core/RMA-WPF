#-------------------------------------------------------------------------------
# File 'yas_portal_reporting.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas_portal_reporting'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP emergency_payroll_clmhdrid

&$env:QTP afp_pedsurgery

&$env:QTP draminaz_elig_rejects

&$env:QTP draminaz_rat_rejects

&$env:QUIZ drchaudhary_rejects

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
