#-------------------------------------------------------------------------------
# File 'reports_first_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'reports_first_monthend'
#-------------------------------------------------------------------------------

#  2015/Jul/15  M.C.    $cmd/reports_first_monthend      
#                       include all macros that should be run in the first monthend
#                       macros have automatically passed the monthend 1 in the executing programs
#  2015/Dec/01  MC1     include $cmd/r070_csv_first_monthend     

echo ""
echo "start - reports in first monthend..$(udate)"
echo ""

Set-Location $application_root\production

# MC1
$cmd\r070_csv_first_monthend

$cmd\r005_csv_first_monthend
$cmd\claims_subfile_first_monthend

echo ""
echo "finish - reports in first monthend..$(udate)"
echo ""
