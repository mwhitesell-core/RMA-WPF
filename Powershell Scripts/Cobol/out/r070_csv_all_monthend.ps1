#-------------------------------------------------------------------------------
# File 'r070_csv_all_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r070_csv_all_monthend'
#-------------------------------------------------------------------------------

#  2015/Nov/30  M.C.    $cmd/r070_csv_all_monthend      

echo "Accounts Receivable  (r070_csv) in all monthend.."
echo ""
echo ""
echo ""

Set-Location $application_root\production

Get-Content r070a_csv_me1.sf, r070a_csv_me2.sf, r070a_csv_me3.sf  > r070a_csv.sf

quiz++ $obj\r070b_csv
quiz++ $obj\r070c_csv


echo ""
echo ""
