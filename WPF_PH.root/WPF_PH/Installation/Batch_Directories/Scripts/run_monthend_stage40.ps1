#-------------------------------------------------------------------------------
# File 'run_monthend_stage40.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_stage40'
#-------------------------------------------------------------------------------

## $cmd/run_monthend_stage40

echo "Start Time of $env:cmd\run_monthend_stage40 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Remove-Item stage40.ls
&$env:cmd\run_stage_40 *> stage40.ls

echo "End   Time of $env:cmd\run_monthend_stage40 is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
