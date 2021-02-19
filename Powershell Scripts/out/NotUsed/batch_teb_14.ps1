

#-------------------------------------------------------------------------------
# File 'batch_teb_14.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 14 
#

Set-Location $env:application_production


Remove-Item teb_14*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 14 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_14.log

echo "--- teb_yearend1 ---"  >> teb_14.log
$rcmd = $env:cmd + "\teb1 201614 201601  >> teb_14.log  2>&1"
invoke-expression $rcmd

echo "--- teb_yearend2 ---"  >> teb_14.log
$rcmd = $env:cmd + "\teb2 201614 201601  >> teb_14.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_14.log

$rcmd = $env:QTP + "u090f >> teb_14.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 14 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_14.log

echo "Payroll Run 14b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_14b.log

echo "--- teb3 ---"  >> teb_14b.log

$rcmd = $env:cmd + "\teb3 201614 201601  >> teb_14b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 14b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_14b.log

#BATCH_EXIT
