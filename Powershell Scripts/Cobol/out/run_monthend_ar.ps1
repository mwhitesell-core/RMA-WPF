#-------------------------------------------------------------------------------
# File 'run_monthend_ar.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_monthend_ar'
#-------------------------------------------------------------------------------

## $cmd/run_monthend_ar

echo "Start Time of $cmd\run_monthend_ar is$(udate)"

Remove-Item ar.ls  > $null
$cmd\accounts_receivable  22  > ar.ls  2>&1

echo "End   Time of $cmd\run_monthend_ar is$(udate)"
