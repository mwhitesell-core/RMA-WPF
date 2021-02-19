#-------------------------------------------------------------------------------
# File 'dept54.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dept54'
#-------------------------------------------------------------------------------

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\src\yas

echo "Start Time of $env:cmd\dept54 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QTP + "dept54_billings 201706"
Invoke-Expression $rcmd

echo "End Time of $env:cmd\dept54 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
