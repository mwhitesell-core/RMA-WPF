#-------------------------------------------------------------------------------
# File 'status91.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'status91'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\91
echo "BEGIN NOW... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:QTP + "u210 91000000 91ZZZZZZ"
Invoke-Expression $rcmd
echo "ENDING.... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo "BEGIN NOW... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:QUIZ + "r211 91000000 91ZZZZZZ"
Invoke-Expression $rcmd
echo "ENDING.... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Get-Content r211 | Out-Printer
#lp status.ls
