#-------------------------------------------------------------------------------
# File 'batch_teb_12_onetime.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'batch_teb_12_onetime'
#-------------------------------------------------------------------------------

#  Payroll Run 12  - onetime
#
Set-Location $env:application_production
Remove-Item teb_12_onetime.log *> $null
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
#batch << BATCH_EXIT
echo "Payroll Run 12 onetime - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > teb_12_onetime.log

echo "--- teb2 onetime  ---" >> teb_12_onetime.log
&$env:cmd\teb2_onetime 200912 200901 >> teb_12_onetime.log 2> teb_12_onetime.log

echo "--- u090f (QTP RUN) ---" >> teb_12_onetime.log
&$env:QTP u090f >> teb_12_onetime.log 2> teb_12_onetime.log

echo "--- teb3 ---" >> teb_12_onetime.log
&$env:cmd\teb3 200912 200901 >> teb_12_onetime.log 2> teb_12_onetime.log

echo "Payroll Run 12 - ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> teb_12_onetime.log
#BATCH_EXIT
