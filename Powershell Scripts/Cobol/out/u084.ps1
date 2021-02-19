#-------------------------------------------------------------------------------
# File 'u084.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u084'
#-------------------------------------------------------------------------------

# /bin/ksh
# u084
echo ""
echo ""
echo "running u084a - download of Claims Inventory into data warehouse ..."

qtp++ $obj\u084a


echo "Hit Enter to print report ..."
$garbage = Read-Host

Get-Contents r084.txt| Out-Printer

echo ""
echo "Done"
