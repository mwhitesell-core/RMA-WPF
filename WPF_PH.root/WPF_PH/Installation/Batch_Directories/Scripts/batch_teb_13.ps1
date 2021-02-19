

#-------------------------------------------------------------------------------
# File 'batch_teb_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 13 
#

Set-Location $env:application_production


Remove-Item teb_13*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 13 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_13.log

echo "--- teb_yearend1 ---"  >> teb_13.log
$rcmd = $env:cmd + "\teb1 201613 201601  >> teb_13.log  2>&1"
invoke-expression $rcmd

echo "--- teb_yearend2 ---"  >> teb_13.log
$rcmd = $env:cmd + "\teb2 201613 201601  >> teb_13.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_13.log

$rcmd = $env:QTP + "u090f >> teb_13.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 13 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_13.log

echo "Payroll Run 13b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_13b.log

echo "--- teb3 ---"  >> teb_13b.log

$rcmd = $env:cmd + "\teb3 201613 201601  >> teb_13b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 13b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_13b.log

#BATCH_EXIT
