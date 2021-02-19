#-------------------------------------------------------------------------------
# File 'clinic26.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'clinic26'
#-------------------------------------------------------------------------------

## $cmd/clinic26

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\src\yas

echo "Start Time of $env:cmd\clinic26 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QTP + "clinic26 201704"
Invoke-Expression $rcmd


echo "End Time of $env:cmd\clinic26 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
