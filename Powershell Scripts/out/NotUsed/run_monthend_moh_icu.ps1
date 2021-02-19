#-------------------------------------------------------------------------------
# File 'run_monthend_moh_icu.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_moh_icu'
#-------------------------------------------------------------------------------

Remove-Item moh_icu.ls
#batch << BATCH_EXIT
&$env:cmd\moh1_icu *> moh_icu.ls
#BATCH_EXIT
