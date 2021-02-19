#-------------------------------------------------------------------------------
# File 'batch_teb_1.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_teb_1'
#-------------------------------------------------------------------------------

#  Payroll Run 1 
#
Set-Location $application_production
Remove-Item teb_1*.log  > $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 1 - starting -$(udate)"  > teb_1.log

echo "--- teb1 ---"  >> teb_1.log
$cmd\teb1 201601 201601  >> teb_1.log  2>&1

echo "--- teb2 ---"  >> teb_1.log
$cmd\teb2 201601 201601  >> teb_1.log  2>&1

echo "--- u090f (QTP RUN) ---"  >> teb_1.log
qtp++ $obj\u090f  >> teb_1.log  2>&1

echo "Payroll Run 1 - ending -$(udate)"  >> teb_1.log

echo "Payroll Run 1b - starting -$(udate)"  > teb_1b.log

echo "--- teb3 ---"  >> teb_1b.log

$cmd\teb3 201601 201601  >> teb_1b.log  2>&1

echo "Payroll Run 1b - ending -$(udate)"  >> teb_1b.log

#BATCH_EXIT
