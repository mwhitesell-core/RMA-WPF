#-------------------------------------------------------------------------------
# File 'stale_date_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'stale_date_reports'
#-------------------------------------------------------------------------------

Remove-Item r022f*.sf*
Remove-Item r022g*.sf*

&$env:QUIZ r022f
&$env:QUIZ r022g

Get-Content r022f.txt | Out-Printer
Get-Content r022g.txt | Out-Printer
