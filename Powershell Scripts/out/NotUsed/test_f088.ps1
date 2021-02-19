#-------------------------------------------------------------------------------
# File 'test_f088.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'test_f088'
#-------------------------------------------------------------------------------

Set-Location $Env:root\charly\purge

&$env:QTP purge_relof088 >> $pb_prod\purgef088.log 2> $pb_prod\purgef088.log


echo "Purge f088 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> payrollpurge.log
