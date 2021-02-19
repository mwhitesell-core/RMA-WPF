#-------------------------------------------------------------------------------
# File 'update_t4.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'update_t4'
#-------------------------------------------------------------------------------

Remove-Item update_t4.ls *> $null
#batch << BATCH_EXIT
&$env:cmd\t4_update *> update_t4.ls
#BATCH_EXIT
