

#-------------------------------------------------------------------------------
# File 'batch_teb_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 6 
#

Set-Location $env:application_production


Remove-Item teb_6*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 6 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_6.log

echo "--- teb1 ---"  >> teb_6.log
$rcmd = $env:cmd + "\teb1 201606 201601  >> teb_6.log  2>&1"
invoke-expression $rcmd

echo "--- teb2 ---"  >> teb_6.log
$rcmd = $env:cmd + "\teb2 201606 201601  >> teb_6.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_6.log

$rcmd = $env:QTP + "u090f >> teb_6.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 6 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_6.log

echo "Payroll Run 6b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_6b.log

echo "--- teb3 ---"  >> teb_6b.log

$rcmd = $env:cmd + "\teb3 201606 201601  >> teb_6b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 6b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_6b.log

#BATCH_EXIT
