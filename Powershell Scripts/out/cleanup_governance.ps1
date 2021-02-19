#-------------------------------------------------------------------------------
# File 'cleanup_governance.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_governance'
#-------------------------------------------------------------------------------
Push-Location
Get-Date
Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\upload

Remove-Item *140*.sf*
Remove-Item *140*.txt
Remove-Item *140*.log

Get-Date
Pop-Location