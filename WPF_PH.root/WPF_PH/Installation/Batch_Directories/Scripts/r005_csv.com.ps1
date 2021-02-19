#-------------------------------------------------------------------------------
# File 'r005_csv.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r005_csv.com'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

echo "R005_CSV.COM"
echo ""

echo ""
echo "CREATE  r005_dtl.sf & r005_summ.sf for monthend "
echo ""

echo ""
echo "PROGRAM `"r005_csv.qtc`" NOW LOADING ..."
echo ""

$rcmd = $env:QTP + "r005_csv ${1}"
Invoke-Expression $rcmd

echo ""
echo "COPY r005_dtl.sf & r005_summ.sf into ME "
echo ""

Copy-Item r005_dtl.sf r005_dtl_me${1}.sf
Copy-Item r005_dtl.sfd r005_dtl_me${1}.sfd
Copy-Item r005_summ.sf r005_summ_me${1}.sf
Copy-Item r005_summ.sfd r005_summ_me${1}.sfd
