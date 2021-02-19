﻿

#-------------------------------------------------------------------------------
# File 'batch_teb_20.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 20 
#

Set-Location $env:application_production


Remove-Item teb_20*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 20 - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  > teb_20.log

echo "--- teb_yearend1 ---"  >> teb_20.log
$rcmd = $env:cmd + "\teb1 201620 201601  >> teb_20.log  2>&1"
invoke-expression $rcmd

echo "--- teb_yearend2 ---"  >> teb_20.log
$rcmd = $env:cmd + "\teb2 201620 201601  >> teb_20.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_20.log

$rcmd = $env:QTP + "u090f >> teb_20.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 20 - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_20.log

echo "Payroll Run 20b - starting -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_20b.log

echo "--- teb3 ---"  >> teb_20b.log

$rcmd = $env:cmd + "\teb3 201620 201601  >> teb_20b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 20b - ending -"(Get-Date).ToString('yyyy-MM-dd HH:MM')  >> teb_20b.log

#BATCH_EXIT