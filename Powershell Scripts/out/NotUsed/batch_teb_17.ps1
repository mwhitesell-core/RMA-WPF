

#-------------------------------------------------------------------------------
# File 'batch_teb_17.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 17 
#

Set-Location $env:application_production


Remove-Item teb_17*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 17 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_17.log

echo "--- teb_yearend1 ---"  >> teb_17.log
$rcmd = $env:cmd + "\teb1 201617 201601  >> teb_17.log  2>&1"
invoke-expression $rcmd

echo "--- teb_yearend2 ---"  >> teb_17.log
$rcmd = $env:cmd + "\teb2 201617 201601  >> teb_17.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_17.log

$rcmd = $env:QTP + "u090f >> teb_17.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 17 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_17.log

echo "Payroll Run 17b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_17b.log

echo "--- teb3 ---"  >> teb_17b.log

$rcmd = $env:cmd + "\teb3 201617 201601  >> teb_17b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 17b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_17b.log

#BATCH_EXIT
