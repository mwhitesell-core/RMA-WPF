#-------------------------------------------------------------------------------
# File 'reports_third_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reports_third_monthend'
#-------------------------------------------------------------------------------

#  2015/Jul/15  M.C.    $cmd/reports_third_monthend      
#                       include all macros that should be run in the third monthend
#                       macros have automatically passed the monthend 3 in the executing programs
#  2015/Dec/01  MC1     include $cmd/r070_csv_third_monthend

echo ""
echo "start - reports in third monthend..$(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""

Set-Location $env:application_root\production

# MC1
&$env:cmd\r070_csv_third_monthend
&$env:cmd\r070_csv_all_monthend

&$env:cmd\r005_csv_third_monthend
&$env:cmd\r005_csv_all_monthend
&$env:cmd\claims_subfile_third_monthend

echo ""
echo "finish - reports in third monthend..$(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""
