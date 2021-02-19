#-------------------------------------------------------------------------------
# File 'check_suspend_amounts.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_suspend_amounts'
#-------------------------------------------------------------------------------

Remove-Item r717.txt *> $null
$rcmd = $env:QUIZ + "r717"
Invoke-Expression $rcmd

Get-Content r717.txt | Out-Printer
