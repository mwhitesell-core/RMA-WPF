#-------------------------------------------------------------------------------
# File 'peds_billings.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'peds_billings'
#-------------------------------------------------------------------------------

##  $cmd/peds_Billings

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\src\yas

echo "Start Time of $env:cmd\peds_billings is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QTP + "detail_peds_billings_ped 201704"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "f087_peds_rejects_by_errcode DISC_f087_peds_rejects_by_errcode.rf"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content f087_peds_rejects_by_errcode.txt > peds_rejects.txt

$rcmd = $env:QTP + "f088_peds_rejects"
Invoke-Expression $rcmd

##qtp auto=$obj/f088_clinic78_rejects.qtc

##qtp auto=$obj/peds_diag_codes.qtc              ### run at yearend only service date 20150401 to 20160331
$rcmd = $env:QTP + "peds_diag_codes"
Invoke-Expression $rcmd
##qtp auto=$obj/pediatric_total_billing.qtc      ### run at yearend only service date 20140401 to 20150331 cancelled
##qtp auto=$obj/detail_peds_billings_svcdate.qtc ### run at yearend only service date 20130401 to 20140331 cancelled

echo "End Time of $env:cmd\peds_billings is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
