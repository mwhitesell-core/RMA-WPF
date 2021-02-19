#-------------------------------------------------------------------------------
# File 'r005_csv_all_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r005_csv_all_monthend'
#-------------------------------------------------------------------------------

#  2015/Jun/22  M.C.    $cmd/r005_csv_all_monthend      

echo "Doctor Cash Analysis (r005_csv) in all monthend.."
echo ""
echo ""
echo ""

Set-Location $env:application_root\production

Get-Content r005_dtl_me1.sf, r005_dtl_me2.sf, r005_dtl_me3.sf | Set-Content r005_dtl.sf
Get-Content r005_summ_me1.sf, r005_summ_me2.sf, r005_summ_me3.sf | Set-Content r005_summ.sf

$rcmd = $env:QUIZ + "r005a_csv DISC_r005a_csv.rf"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r005a_csv.txt > r005dtl_csv.txt

$rcmd = $env:QUIZ + "r005b_csv DISC_r005b_csv.rf"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r005b_csv.txt > r005sum_csv.txt

$rcmd = $env:QUIZ + "r005c_csv"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r005c_csv.txt > r005_all.txt

echo ""
echo ""
