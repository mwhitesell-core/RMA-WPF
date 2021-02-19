#-------------------------------------------------------------------------------
# File 'reports_second_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reports_second_monthend'
#-------------------------------------------------------------------------------

#  2015/Jul/15  M.C.    $cmd/reports_second_monthend      
#                       include all macros that should be run in the second monthend
#                       macros have automatically passed the monthend 2 in the executing programs
#  2015/Dec/01  MC1     include $cmd/r070_csv_second_monthend
echo ""
echo "start - reports in second monthend..$(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""

Set-Location $env:application_root\production

# MC2
&$env:cmd\r070_csv_second_monthend

&$env:cmd\r005_csv_second_monthend
&$env:cmd\claims_subfile_second_monthend

echo ""
echo "finish - reports in second monthend..$(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""
