#-------------------------------------------------------------------------------
# File 'run_monthend_stage40.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_monthend_stage40'
#-------------------------------------------------------------------------------

## $cmd/run_monthend_stage40

echo "Start Time of $cmd\run_monthend_stage40 is$(udate)"

Remove-Item stage40.ls
$cmd\run_stage_40  > stage40.ls  2>&1

echo "End   Time of $cmd\run_monthend_stage40 is$(udate)"
