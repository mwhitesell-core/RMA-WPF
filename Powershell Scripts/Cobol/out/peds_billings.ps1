#-------------------------------------------------------------------------------
# File 'peds_billings.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'peds_billings'
#-------------------------------------------------------------------------------

##  $cmd/peds_Billings

Set-Location $root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time of $cmd\peds_billings is$(udate)"

$pipedInput = @"
exec $obj/detail_peds_billings_ped.qtc
201702
exit
"@

$pipedInput | qtp++

quiz++ $obj\f087_peds_rejects_by_errcode

qtp++ $obj\f088_peds_rejects

##qtp auto=$obj/f088_clinic78_rejects.qtc

##qtp auto=$obj/peds_diag_codes.qtc              ### run at yearend only service date 20150401 to 20160331
##qtp auto=$obj/pediatric_total_billing.qtc      ### run at yearend only service date 20140401 to 20150331 cancelled
##qtp auto=$obj/detail_peds_billings_svcdate.qtc ### run at yearend only service date 20130401 to 20140331 cancelled

echo "End Time of $cmd\peds_billings is$(udate)"
