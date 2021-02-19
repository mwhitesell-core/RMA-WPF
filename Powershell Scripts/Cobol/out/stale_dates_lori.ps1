#-------------------------------------------------------------------------------
# File 'stale_dates_lori.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'stale_dates_lori'
#-------------------------------------------------------------------------------

echo "Start Time is$(udate)"

Remove-Item r022g*.sf*

quiz++ $obj\r022g

Get-Contents r022g.txt| Out-Printer

echo "End Time is$(udate)"
