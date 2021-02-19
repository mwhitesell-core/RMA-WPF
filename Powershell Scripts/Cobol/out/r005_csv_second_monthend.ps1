#-------------------------------------------------------------------------------
# File 'r005_csv_second_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r005_csv_second_monthend'
#-------------------------------------------------------------------------------

#  2015/Jun/22  M.C.    $cmd/r005_csv_second_monthend      

echo "Doctor Cash Analysis (r005_csv) in second monthend.."
echo ""
echo ""
echo ""

Set-Location $application_root\production

$cmd\r005_csv.com  2  > r005_csv_second_monthend.log

echo ""
echo ""
