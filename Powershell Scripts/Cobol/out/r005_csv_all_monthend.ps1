#-------------------------------------------------------------------------------
# File 'r005_csv_all_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r005_csv_all_monthend'
#-------------------------------------------------------------------------------

#  2015/Jun/22  M.C.    $cmd/r005_csv_all_monthend      

echo "Doctor Cash Analysis (r005_csv) in all monthend.."
echo ""
echo ""
echo ""

Set-Location $application_root\production

Get-Content r005_dtl_me1.sf, r005_dtl_me2.sf, r005_dtl_me3.sf  > r005_dtl.sf
Get-Content r005_summ_me1.sf, r005_summ_me2.sf, r005_summ_me3.sf  > r005_summ.sf

quiz++ $obj\r005_csv

echo ""
echo ""
