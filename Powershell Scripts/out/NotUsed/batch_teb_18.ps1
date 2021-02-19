

#-------------------------------------------------------------------------------
# File 'batch_teb_18.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 18 
#

Set-Location $env:application_production


Remove-Item teb_18*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 18 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_18.log

echo "--- teb_yearend1 ---"  >> teb_18.log
$rcmd = $env:cmd + "\teb1 201618 201601  >> teb_18.log  2>&1"
invoke-expression $rcmd

echo "--- teb_yearend2 ---"  >> teb_18.log
$rcmd = $env:cmd + "\teb2 201618 201601  >> teb_18.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_18.log

$rcmd = $env:QTP + "u090f >> teb_18.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 18 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_18.log

echo "Payroll Run 18b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_18b.log

echo "--- teb3 ---"  >> teb_18b.log

$rcmd = $env:cmd + "\teb3 201618 201601  >> teb_18b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 18b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_18b.log

#BATCH_EXIT
