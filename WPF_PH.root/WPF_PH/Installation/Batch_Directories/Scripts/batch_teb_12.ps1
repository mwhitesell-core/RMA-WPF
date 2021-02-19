

#-------------------------------------------------------------------------------
# File 'batch_teb_12.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 12 
#

Set-Location $env:application_production


Remove-Item teb_12*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 12 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_12.log

echo "--- teb1 ---"  >> teb_12.log
$rcmd = $env:cmd + "\teb1 201612 201601  >> teb_12.log  2>&1"
invoke-expression $rcmd

echo "--- teb2 ---"  >> teb_12.log
$rcmd = $env:cmd + "\teb2 201612 201601  >> teb_12.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_12.log

$rcmd = $env:QTP + "u090f >> teb_12.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 12 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_12.log

echo "Payroll Run 12b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_12b.log

echo "--- teb3 ---"  >> teb_12b.log

$rcmd = $env:cmd + "\teb3 201612 201601  >> teb_12b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 12b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_12b.log

#BATCH_EXIT
