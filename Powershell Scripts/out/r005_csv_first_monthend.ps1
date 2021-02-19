#-------------------------------------------------------------------------------
# File 'r005_csv_first_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r005_csv_first_monthend'
#-------------------------------------------------------------------------------

#  2015/Jun/22  M.C.    $cmd/r005_csv_first_monthend      

echo "Doctor Cash Analysis (r005_csv) in first monthend.."
echo ""
echo ""
echo ""

Set-Location $env:application_root\production

&$env:cmd\r005_csv.com  1 > r005_csv_first_monthend.log

echo ""
echo ""
