#-------------------------------------------------------------------------------
# File 'r005_csv.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r005_csv.com'
#-------------------------------------------------------------------------------

echo "R005_CSV.COM"
echo ""

echo ""
echo "CREATE  r005_dtl.sf & r005_summ.sf for monthend "
echo ""

echo ""
echo "PROGRAM `"r005_csv.qtc`" NOW LOADING ..."
echo ""

$pipedInput = @"
${1} 
"@

$pipedInput | qtp++ $obj\r005_csv

echo ""
echo "COPY r005_dtl.sf & r005_summ.sf into ME "
echo ""

Copy-Item r005_dtl.sf r005_dtl_me${1}.sf
Copy-Item r005_summ.sf r005_summ_me${1}.sf
