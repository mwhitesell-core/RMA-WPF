#-------------------------------------------------------------------------------
# File 'u084.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u084'
#-------------------------------------------------------------------------------

# /bin/ksh
# u084
echo ""
echo ""
echo "running u084a - download of Claims Inventory into data warehouse ..."

&$env:QTP u084a


echo "Hit Enter to print report ..."
$garbage = Read-Host

Get-Content r084.txt | Out-Printer

echo ""
echo "Done"
