#-------------------------------------------------------------------------------
# File 'monthly_stage40_and_ar_tp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'monthly_stage40_and_ar_tp'
#-------------------------------------------------------------------------------

echo "RUN_MONTHLY_STAGE40_TP"
clear
echo ""
echo "RUN MONTHLY REPORTS AND ACCOUNTS RECEIVABLE"
echo ""
Set-Location $env:application_production\60
&$env:cmd\stage40tp > 40tp.ls 2>&1
