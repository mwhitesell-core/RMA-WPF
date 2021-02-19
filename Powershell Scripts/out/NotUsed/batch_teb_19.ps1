

#-------------------------------------------------------------------------------
# File 'batch_teb_19.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 19 
#

Set-Location $env:application_production


Remove-Item teb_19*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 19 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_19.log

echo "--- teb_yearend1 ---"  >> teb_19.log
$rcmd = $env:cmd + "\teb1 201619 201601  >> teb_19.log  2>&1"
invoke-expression $rcmd

echo "--- teb_yearend2 ---"  >> teb_19.log
$rcmd = $env:cmd + "\teb2 201619 201601  >> teb_19.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_19.log

$rcmd = $env:QTP + "u090f >> teb_19.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 19 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_19.log

echo "Payroll Run 19b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_19b.log

echo "--- teb3 ---"  >> teb_19b.log

$rcmd = $env:cmd + "\teb3 201619 201601  >> teb_19b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 19b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_19b.log

#BATCH_EXIT
