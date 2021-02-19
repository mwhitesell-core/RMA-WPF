#-------------------------------------------------------------------------------
# File 'claims_subfile_monthend.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'claims_subfile_monthend.com'
#-------------------------------------------------------------------------------

#  2015/Jul/14  M.C.    $cmd/claims_subfile_monthend.com called from $cmd/claims_subfile_first_monthend,
#                       $cmd/claims_subfile_second_monthend or $cmd/claims_subfile_third_monthend
#                       pass monthend as the paramter

echo ""
echo "$(udate)"

$pipedInput = @"
exec $obj/unlof002_me_claim.qtc
${1}
"@

$pipedInput | qtp++

echo ""
echo "$(udate)"
