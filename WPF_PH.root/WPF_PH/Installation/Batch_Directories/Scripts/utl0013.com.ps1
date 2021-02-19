#-------------------------------------------------------------------------------
# File 'utl0013.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'utl0013.com'
#-------------------------------------------------------------------------------

##  2016/Dec/01 MC      - utl0013 
##                      - check for doctors that have both dept 13 and 14
##                        and set 'Y' to pay-this-doctor-ohip-premium for dept 14

Set-Location $env:application_root\production

Remove-Item utl0013.log

echo "utl0013.com  -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > utl0013.log

$rcmd = $env:QTP+"utl0013"
Invoke-Expression $rcmd >> utl0013.log
$rcmd = $env:QUIZ+"utl0013"
Invoke-Expression $rcmd >> utl0013.log

echo "utl0013 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> utl0013.log
