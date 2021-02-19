#-------------------------------------------------------------------------------
# File 'run_monthend_moh_81y2k.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_moh_81y2k'
#-------------------------------------------------------------------------------

Remove-Item moh_81y2k.ls
#batch << BATCH_EXIT
&$env:cmd\moh1_81y2k *> moh_81y2k.ls
#BATCH_EXIT
