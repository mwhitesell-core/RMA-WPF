

#-------------------------------------------------------------------------------
# File 'batch_teb_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 1 
#

Set-Location $env:application_production


Remove-Item teb_1*.log  -EA SilentlyContinue
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 1 - starting -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')  > teb_1.log

echo "--- teb1 ---"  >> teb_1.log
$rcmd = $env:cmd + "\teb1 201601 201601  >> teb_1.log  2>&1"
invoke-expression $rcmd

echo "--- teb2 ---"  >> teb_1.log
$rcmd = $env:cmd + "\teb2 201601 201601  >> teb_1.log  2>&1"
invoke-expression $rcmd

echo "--- u090f (QTP RUN) ---"  >> teb_1.log

$rcmd = $env:QTP + "u090f >> teb_1.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 1 - ending -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')  >> teb_1.log

echo "Payroll Run 1b - starting -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')  > teb_1b.log

echo "--- teb3 ---"  >> teb_1b.log

$rcmd = $env:cmd + "\teb3 201601 201601  >> teb_1b.log  2>&1"
invoke-expression $rcmd

echo "Payroll Run 1b - ending -"(Get-Date).ToString('yyyy-MM-dd 0:h:mm:ss')  >> teb_1b.log

#BATCH_EXIT
