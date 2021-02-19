#-------------------------------------------------------------------------------
# File 'run_monthend_stage40.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_stage40.bk1'
#-------------------------------------------------------------------------------

Remove-Item stage40.ls
&$env:cmd\run_stage_40 *> stage40.ls
