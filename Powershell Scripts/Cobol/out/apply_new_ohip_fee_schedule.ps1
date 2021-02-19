#-------------------------------------------------------------------------------
# File 'apply_new_ohip_fee_schedule.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'apply_new_ohip_fee_schedule'
#-------------------------------------------------------------------------------

echo "APPLY_NEW_OHIP_FEE_SCHEDULE"
echo ""
echo ""
echo "NOTE: THE OMA FEE MASTER SHOULD HAVE BEEN ROLLED OVER"
echo "BY PROGRAM U040 BEFORE RUNNING THIS UPDATE"
echo ""
echo ""

echo "HIT `"NEWLINE`" TO COMMENCE UPDATE ..."
 $garbage = Read-Host

echo ""
echo ""

cobrun++ $obj\u041

Get-ChildItem ru041a, ru041b

echo "HIT `"NEWLINE`" TO PRINT REPORT ..."
 $garbage = Read-Host

echo ""

Get-Contents ru041a| Out-Printer
Get-Contents ru041b| Out-Printer

echo ""
echo "FINISHED ..."
