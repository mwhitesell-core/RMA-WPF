#-------------------------------------------------------------------------------
# File 'stale_dates_melissa.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'stale_dates_melissa'
#-------------------------------------------------------------------------------

Remove-Item r022f*.sf*

quiz++ $obj\r022f

Get-Contents r022f.txt| Out-Printer
