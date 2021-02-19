#-------------------------------------------------------------------------------
# File 'r134_r135_portal.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r134_r135_portal'
#-------------------------------------------------------------------------------

# 2015/Apr/22   MC      include the parameter 'PORTAL' to run r134 & r135 

Set-Location $application_root\production

$pipedInput = @"
exec $obj/r134a
20160701
20170630
exec $obj/r134b
PORTAL 
exec $obj/r135a
20160701
20170630
exec $obj/r135b
PORTAL
exit
R134_R135_PORTAL_EXIT 
"@

$pipedInput | quiz++
