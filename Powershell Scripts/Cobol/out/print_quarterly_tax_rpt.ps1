#-------------------------------------------------------------------------------
# File 'print_quarterly_tax_rpt.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'print_quarterly_tax_rpt'
#-------------------------------------------------------------------------------

echo "CREATE_QUARTERLY_TAX_RPT"
echo ""
echo "CREATE QUARTERLY TAX REPORT AND PRINT REPORT"
echo ""
echo ""
echo "HIT `"NEWLINE`"  TO CONTINUE ..."
$garbage = Read-Host

Remove-Item r151*.txt  > $null
Remove-Item r151*.sf  > $null

echo ""
echo "PROGRAM `"R151`"  NOW LOADING ..."

quiz++ $obj\r151
quiz++ $obj\r151d
quiz++ $obj\r151e
quiz++ $obj\r151f

echo ""
echo "Inform Yas to upload r151d.txt and r151e.txt Mary's Tax dir for excel"
echo ""
echo "HIT `"NEWLINE`""
$garbage = Read-Host

#lp r151.txt
#lp r151.txt

echo ""
echo ""
echo ""
echo "FINISHED ....."
