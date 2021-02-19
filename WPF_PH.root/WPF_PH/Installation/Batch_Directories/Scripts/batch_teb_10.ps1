

#-------------------------------------------------------------------------------
# File 'batch_teb_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 10 
#

Set-Location $env:application_production


Remove-Item teb_10*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 10 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_10.log

echo "--- teb1 ---"  >> teb_10.log
$rcmd = $env:cmd + "\teb1 201610 201601  >> teb_10.log  2>&1"
invoke-expression $rcmd

echo "--- teb2 ---"  >> teb_10.log
$rcmd = $env:cmd + "\teb2 201610 201601  >> teb_10.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_10.log

$rcmd = $env:QTP + "u090f >> teb_10.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 10 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_10.log

echo "Payroll Run 10b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_10b.log

echo "--- teb3 ---"  >> teb_10b.log

$rcmd = $env:cmd + "\teb3 201610 201601  >> teb_10b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 10b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_10b.log

#BATCH_EXIT
