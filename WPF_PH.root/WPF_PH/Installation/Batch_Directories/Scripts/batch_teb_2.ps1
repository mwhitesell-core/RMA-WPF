

#-------------------------------------------------------------------------------
# File 'batch_teb_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 2 
#

Set-Location $env:application_production


Remove-Item teb_2*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 2 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_2.log

echo "--- teb1 ---"  >> teb_2.log
$rcmd = $env:cmd + "\teb1 201602 201601  >> teb_2.log  2>&1"
invoke-expression $rcmd

echo "--- teb2 ---"  >> teb_2.log
$rcmd = $env:cmd + "\teb2 201602 201601  >> teb_2.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_2.log

$rcmd = $env:QTP + "u090f >> teb_2.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 2 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_2.log

echo "Payroll Run 2b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_2b.log

echo "--- teb3 ---"  >> teb_2b.log

$rcmd = $env:cmd + "\teb3 201602 201601  >> teb_2b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 2b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_2b.log

#BATCH_EXIT
