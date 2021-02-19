

#-------------------------------------------------------------------------------
# File 'batch_teb_15.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 15 
#

Set-Location $env:application_production


Remove-Item teb_15*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 15 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_15.log

echo "--- teb_yearend1 ---"  >> teb_15.log
$rcmd = $env:cmd + "\teb1 201615 201601  >> teb_15.log  2>&1"
invoke-expression $rcmd

echo "--- teb_yearend2 ---"  >> teb_15.log
$rcmd = $env:cmd + "\teb2 201615 201601  >> teb_15.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_15.log

$rcmd = $env:QTP + "u090f >> teb_15.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 15 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_15.log

echo "Payroll Run 15b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_15b.log

echo "--- teb3 ---"  >> teb_15b.log

$rcmd = $env:cmd + "\teb3 201615 201601  >> teb_15b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 15b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_15b.log

#BATCH_EXIT
