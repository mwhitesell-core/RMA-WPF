#-------------------------------------------------------------------------------
# File 'monthly_stage40_and_ar_tp.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'monthly_stage40_and_ar_tp'
#-------------------------------------------------------------------------------

echo "RUN_MONTHLY_STAGE40_TP"
clear
echo ""
echo "RUN MONTHLY REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
Set-Location $application_production\60
$cmd\stage40tp >40tp.ls  2>&1
