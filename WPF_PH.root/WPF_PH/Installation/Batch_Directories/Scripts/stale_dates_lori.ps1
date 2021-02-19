#-------------------------------------------------------------------------------
# File 'stale_dates_lori.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'stale_dates_lori'
#-------------------------------------------------------------------------------

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Remove-Item r022g*.sf*

$rcmd = $env:QUIZ + "r022g_1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r022g_2"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r022g_2.txt > r022g.txt

Get-Content r022g.txt | Out-Printer

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
