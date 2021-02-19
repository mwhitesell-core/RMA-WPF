#-------------------------------------------------------------------------------
# File 'reports_third_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'reports_third_monthend'
#-------------------------------------------------------------------------------

#  2015/Jul/15  M.C.    $cmd/reports_third_monthend      
#                       include all macros that should be run in the third monthend
#                       macros have automatically passed the monthend 3 in the executing programs
#  2015/Dec/01  MC1     include $cmd/r070_csv_third_monthend

echo ""
echo "start - reports in third monthend..$(udate)"
echo ""

Set-Location $application_root\production

# MC1
$cmd\r070_csv_third_monthend
$cmd\r070_csv_all_monthend

$cmd\r005_csv_third_monthend
$cmd\r005_csv_all_monthend
$cmd\claims_subfile_third_monthend

echo ""
echo "finish - reports in third monthend..$(udate)"
echo ""
