#-------------------------------------------------------------------------------
# File 'check_f020_ohip_sin.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'check_f020_ohip_sin'
#-------------------------------------------------------------------------------

#  2015/Mar/03  MC      check_f020_ohip_sin 
#

$cmd\utl0119_all.com

echo "Setup of 101c environment"
. $root\macros\setup_rmabill.com 101c

echo ""
echo "Entering `'production`' directory"
Set-Location $application_production; Get-Location


Remove-Item check_ohip_sin.txt, utl0f020_count.sf*, utl0f020_ohip_sin.sf*  > $null

$pipedInput = @"
create file tmp-counters-alpha
"@

$pipedInput | qutil++


qtp++ $obj\utl0f020_ohip_sin  > check_f020_ohip_sin.log
quiz++ $obj\utl0f020_ohip_sin  >> check_f020_ohip_sin.log

Get-Contents utl0f020_ohip_sin.txt| Out-Printer
