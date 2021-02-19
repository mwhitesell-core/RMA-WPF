

#-------------------------------------------------------------------------------
# File 'batch_teb_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 9
#

Set-Location $env:application_production


Remove-Item teb_9*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 9 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_9.log

echo "--- teb1 ---"  >> teb_9.log
$rcmd = $env:cmd + "\teb1 201609 201601  >> teb_9.log  2>&1"
invoke-expression $rcmd

echo "--- teb2 ---"  >> teb_9.log
$rcmd = $env:cmd + "\teb2 201609 201601  >> teb_9.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_9.log

$rcmd = $env:QTP + "u090f >> teb_9.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 9 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_9.log

echo "Payroll Run 9b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_9b.log

echo "--- teb3 ---"  >> teb_9b.log

$rcmd = $env:cmd + "\teb3 201609 201601  >> teb_9b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 9b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_9b.log

#BATCH_EXIT
