#-------------------------------------------------------------------------------
# File 'r997_clinic22_84J.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r997_clinic22_84J'
#-------------------------------------------------------------------------------

Set-Location $application_production

Remove-Item r997_clinic22_84J.txt

$pipedInput = @"
exec $obj/r997_clinic22_84J_a
exec $obj/r997_clinic22_84J_b
"@

$pipedInput | quiz++

Copy-Item r997_clinic22_84J.txt r997g_84J_22
