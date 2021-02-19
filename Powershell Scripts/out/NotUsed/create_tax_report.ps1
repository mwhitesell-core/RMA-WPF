#-------------------------------------------------------------------------------
# File 'create_tax_report.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'create_tax_report'
#-------------------------------------------------------------------------------

echo "CREATE_TAX_REPORT"
echo ""
echo ""
echo ""
echo "HIT `"NEWLINE`" TO CONTINUE ..."
$garbage = Read-Host

Remove-Item taxmp*

echo ""
echo "PROGRAM `"taxmp`" NOW LOADING ..."

$rcmd = $env:QUIZ + "taxmp"
invoke-expression $rcmd

echo ""
echo "Inform Yas to upload taxmp.txt to Mary's Tax dir for excel"
echo ""
echo "HIT `"NEWLINE`" "
$garbage = Read-Host


echo ""
echo ""
echo ""
echo "FINISHED ....."
