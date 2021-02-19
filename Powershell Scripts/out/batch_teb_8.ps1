

#-------------------------------------------------------------------------------
# File 'batch_teb_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 8 
#

Set-Location $env:application_production


Remove-Item teb_8*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 8 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_8.log

echo "--- teb1 ---"  >> teb_8.log
$rcmd = $env:cmd + "\teb1 201608 201601  >> teb_8.log  2>&1"
invoke-expression $rcmd

echo "--- teb2 ---"  >> teb_8.log
$rcmd = $env:cmd + "\teb2 201608 201601  >> teb_8.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_8.log

$rcmd = $env:QTP + "u090f >> teb_8.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 8 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_8.log

echo "Payroll Run 8b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_8b.log

echo "--- teb3 ---"  >> teb_8b.log

$rcmd = $env:cmd + "\teb3 201608 201601  >> teb_8b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 8b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_8b.log

#BATCH_EXIT
