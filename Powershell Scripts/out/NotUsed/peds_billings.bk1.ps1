#-------------------------------------------------------------------------------
# File 'peds_billings.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'peds_billings.bk1'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP detail_peds_billings_ped 201508

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QUIZ f087_peds_rejects_by_errcode

&$env:QTP f088_peds_rejects

##qtp auto=$obj/f088_clinic78_rejects.qtc

##qtp auto=$obj/peds_diag_codes.qtc                ### run at yearend only service date 20140401 to 20150331
##qtp auto=$obj/pediatric_total_billing.qtc      ### run at yearend only service date 20140401 to 20150331 cancelled
##qtp auto=$obj/detail_peds_billings_svcdate.qtc ### run at yearend only service date 20130401 to 20140331 cancelled

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
