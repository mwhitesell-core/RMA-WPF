#-------------------------------------------------------------------------------
# File 'batch_teb2_r124.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_teb2_r124'
#-------------------------------------------------------------------------------

#
Set-Location $env:application_production
# TEB EP-NBR-CURRENT EP-NBR-START-FISCAL-YR
echo "batch_teb2_r124 - starting - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > teb2_r124.log

echo "--- teb2_r124  ---" >> teb2_r124.log
&$env:cmd\teb2_r124_rerun 201608 201601 >> teb2_r124.log 2> teb2_r124.log

echo "batch_teb2_r124 - ending - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> teb2_r124.log
