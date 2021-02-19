#-------------------------------------------------------------------------------
# File 'update_batch_status_22.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'update_batch_status_22'
#-------------------------------------------------------------------------------

Remove-Item status.ls
#batch << BATCH_EXIT
$cmd\status22  > status.ls  2>&1
#BATCH_EXIT
