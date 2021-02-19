#-------------------------------------------------------------------------------
# File 'run_monthend_ar.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_monthend_ar'
#-------------------------------------------------------------------------------

## $cmd/run_monthend_ar

echo "Start Time of $env:cmd\run_monthend_ar is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Remove-Item ar.ls *> $null
&$env:cmd\accounts_receivable 22 *> ar.ls

echo "End   Time of $env:cmd\run_monthend_ar is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
