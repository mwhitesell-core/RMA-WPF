#-------------------------------------------------------------------------------
# File 'r070_csv_all_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r070_csv_all_monthend'
#-------------------------------------------------------------------------------

#  2015/Nov/30  M.C.    $cmd/r070_csv_all_monthend      

echo "Accounts Receivable  (r070_csv) in all monthend.."
echo ""
echo ""
echo ""

Set-Location $env:application_root\production

Get-Content r070a_csv_me1.sf, r070a_csv_me2.sf, r070a_csv_me3.sf | Set-Content r070a_csv.sf

#&$env:QUIZ r070b_csv
#&$env:QUIZ r070c_csv

$rcmd = $env:QUIZ + "r070b_csv"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r070c_csv DISC_r070_all.rf"
Invoke-Expression $rcmd


echo ""
echo ""
