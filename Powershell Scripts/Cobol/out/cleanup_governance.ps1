#-------------------------------------------------------------------------------
# File 'cleanup_governance.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'cleanup_governance'
#-------------------------------------------------------------------------------

Get-Date
Set-Location $root\alpha\rmabill\rmabill101c\upload

Remove-Item *140*.sf*
Remove-Item *140*.txt
Remove-Item *140*.log

Get-Date
