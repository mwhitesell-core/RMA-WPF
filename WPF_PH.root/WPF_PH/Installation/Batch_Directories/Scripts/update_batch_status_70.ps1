#-------------------------------------------------------------------------------
# File 'update_batch_status_70.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'update_batch_status_70'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\70
Remove-Item status.ls
#batch << BATCH_EXIT
&$env:cmd\status70 *> status.ls
#BATCH_EXIT
