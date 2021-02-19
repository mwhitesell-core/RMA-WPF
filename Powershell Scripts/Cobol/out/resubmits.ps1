#-------------------------------------------------------------------------------
# File 'resubmits.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'resubmits'
#-------------------------------------------------------------------------------

# file: check_for_resubmits  -- alias resubmits
# purpose: update status of suspended claim to "R"esubmit
#          if accounting number already on f071
#          print report of resubmitted claims

echo "Select resubmit claims"
echo ""
qtp++ $obj\u714

echo ""
echo "Report selected resubmit claims"
echo ""
Remove-Item r715.txt  > $null
quiz++ $obj\r715
Get-Contents r715.txt| Out-Printer
