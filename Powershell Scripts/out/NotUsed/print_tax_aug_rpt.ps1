#-------------------------------------------------------------------------------
# File 'print_tax_aug_rpt.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'print_tax_aug_rpt'
#-------------------------------------------------------------------------------

echo "CREATE_AUGUST_TAX_RPT"
echo ""
echo "CREATE QUARTERLY TAX REPORT AND PRINT REPORT"
echo ""
echo ""
echo "HIT `"NEWLINE`" TO CONTINUE ..."
$garbage = Read-Host

Remove-Item r151*.sf*
Remove-Item r151*.txt

echo ""
echo "PROGRAM `"R151`"  NOW LOADING ..."

&$env:QUIZ r151a_yrend
&$env:QUIZ r151b_yrend
&$env:QUIZ r151c_yrend
&$env:QUIZ r151d
&$env:QUIZ r151e

echo ""
echo "Inform Yas to upload r151d.txt Mary's Tax dir for excel"
echo ""
echo "HIT `"NEWLINE`" "
$garbage = Read-Host

#lp r151.txt
#lp r151.txt

echo ""
echo ""
echo ""
echo "FINISHED ....."
