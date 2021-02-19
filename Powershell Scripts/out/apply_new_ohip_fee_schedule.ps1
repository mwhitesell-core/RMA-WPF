#-------------------------------------------------------------------------------
# File 'apply_new_ohip_fee_schedule.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
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

&$env:COBOL u041

Get-ChildItem ru041a, ru041b

echo "HIT `"NEWLINE`" TO PRINT REPORT ..."
 $garbage = Read-Host

echo ""

Get-Content ru041a | Out-Printer
Get-Content ru041b | Out-Printer

echo ""
echo "FINISHED ..."
