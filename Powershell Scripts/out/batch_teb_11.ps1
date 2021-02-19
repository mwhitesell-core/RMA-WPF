﻿

#-------------------------------------------------------------------------------
# File 'batch_teb_11.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 11 
#

Set-Location $env:application_production


Remove-Item teb_11*.log  -EA SilentlyContinue
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 11 - starting -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')  > teb_11.log

echo "--- teb1 ---"  >> teb_11.log
$rcmd = $env:cmd + "\teb1 201611 201601  >> teb_11.log  2>&1"
invoke-expression $rcmd

echo "--- teb2 ---"  >> teb_11.log
$rcmd = $env:cmd + "\teb2 201611 201601  >> teb_11.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_11.log

$rcmd = $env:QTP + "u090f >> teb_11.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 11 - ending -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')  >> teb_11.log

echo "Payroll Run 11b - starting -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')  >> teb_11b.log

echo "--- teb3 ---"  >> teb_11b.log

$rcmd = $env:cmd + "\teb3 201611 201601  >> teb_11b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 11b - ending -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')  >> teb_11b.log

#BATCH_EXIT
