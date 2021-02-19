#-------------------------------------------------------------------------------
# File 'r084.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r084'
#-------------------------------------------------------------------------------

# /bin/ksh
# r084
echo ""
echo ""
echo "running r084 - Claims Inventory audit report ..."

&$env:QUIZ r084

Get-ChildItem r084.txt

echo "Hit Enter to print report ..."
$garbage = Read-Host

#lp r084.txt

echo ""
echo "Done"
