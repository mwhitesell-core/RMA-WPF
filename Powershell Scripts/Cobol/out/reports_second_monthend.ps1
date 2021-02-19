#-------------------------------------------------------------------------------
# File 'reports_second_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'reports_second_monthend'
#-------------------------------------------------------------------------------

#  2015/Jul/15  M.C.    $cmd/reports_second_monthend      
#                       include all macros that should be run in the second monthend
#                       macros have automatically passed the monthend 2 in the executing programs
#  2015/Dec/01  MC1     include $cmd/r070_csv_second_monthend
echo ""
echo "start - reports in second monthend..$(udate)"
echo ""

Set-Location $application_root\production

# MC2
$cmd\r070_csv_second_monthend

$cmd\r005_csv_second_monthend
$cmd\claims_subfile_second_monthend

echo ""
echo "finish - reports in second monthend..$(udate)"
echo ""
