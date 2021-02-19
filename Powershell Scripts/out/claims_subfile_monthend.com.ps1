#-------------------------------------------------------------------------------
# File 'claims_subfile_monthend.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_subfile_monthend.com'
#-------------------------------------------------------------------------------

#  2015/Jul/14  M.C.    $cmd/claims_subfile_monthend.com called from $cmd/claims_subfile_first_monthend,
#                       $cmd/claims_subfile_second_monthend or $cmd/claims_subfile_third_monthend
#                       pass monthend as the paramter

echo ""
echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

$rcmd = $env:QTP + "unlof002_me_claim ${1}"
Invoke-Expression $rcmd

echo ""
echo " $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
