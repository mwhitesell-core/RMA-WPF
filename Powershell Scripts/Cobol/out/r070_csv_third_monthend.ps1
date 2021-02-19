#-------------------------------------------------------------------------------
# File 'r070_csv_third_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r070_csv_third_monthend'
#-------------------------------------------------------------------------------

#  2015/Nov/30  M.C.    $cmd/r070_csv_third_monthend      

echo "Accounts Receivable  (r070_csv) in third monthend.."
echo ""
echo ""
echo ""

Set-Location $application_root\production

$cmd\r070_csv.com  3  > r070_csv_third_monthend.log

echo ""
echo ""
