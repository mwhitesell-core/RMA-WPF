#-------------------------------------------------------------------------------
# File 'r134_r135_regular.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r134_r135_regular'
#-------------------------------------------------------------------------------

# 2015/Apr/22   MC      include the parameter 'REGULAR' to run r134 & r135 

Set-Location $application_root\production

$pipedInput = @"
exec $obj/r134b
REGULAR
exec $obj/r135b
REGULAR
exit
R134_R135_REGULAR_EXIT 
"@

$pipedInput | quiz++
