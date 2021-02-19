

#-------------------------------------------------------------------------------
# File 'batch_teb_16.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 16 
#

Set-Location $env:application_production


Remove-Item teb_16*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 16 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_16.log

echo "--- teb_yearend1 ---"  >> teb_16.log
$rcmd = $env:cmd + "\teb1 201616 201601  >> teb_16.log  2>&1"
invoke-expression $rcmd

echo "--- teb_yearend2 ---"  >> teb_16.log
$rcmd = $env:cmd + "\teb2 201616 201601  >> teb_16.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_16.log

$rcmd = $env:QTP + "u090f >> teb_16.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 16 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_16.log

echo "Payroll Run 16b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_16b.log

echo "--- teb3 ---"  >> teb_16b.log

$rcmd = $env:cmd + "\teb3 201616 201601  >> teb_16b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 16b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_16b.log

#BATCH_EXIT
