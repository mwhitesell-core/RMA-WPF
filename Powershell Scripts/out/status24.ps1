#-------------------------------------------------------------------------------
# File 'status24.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'status24'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\24
echo "BEGIN NOW... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:QTP + "u210 24000000 24ZZZZZZ"
Invoke-Expression $rcmd
echo "ENDING.... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo "BEGIN NOW... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
$rcmd = $env:QUIZ + "r211 24000000 24ZZZZZZ"
Invoke-Expression $rcmd
echo "ENDING.... $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Get-Content r211 | Out-Printer
#lp status.ls
