#-------------------------------------------------------------------------------
# File 'update_batch_status_81.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'update_batch_status_81'
#-------------------------------------------------------------------------------

Remove-Item status.ls
#batch << BATCH_EXIT
&$env:cmd\status81 *> status.ls
#BATCH_EXIT
