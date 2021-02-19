#-------------------------------------------------------------------------------
# File 'reports_first_monthend.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reports_first_monthend.bk1'
#-------------------------------------------------------------------------------

#  2015/Jul/15  M.C.    $cmd/reports_first_monthend      
#                       include all macros that should be run in the first monthend
#                       macros have automatically passed the monthend 1 in the executing programs

echo ""
echo "start - reports in first monthend..$(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""

Set-Location $env:application_root\production

&$env:cmd\r005_csv_first_monthend
&$env:cmd\claims_subfile_first_monthend

echo ""
echo "finish - reports in first monthend..$(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
echo ""
