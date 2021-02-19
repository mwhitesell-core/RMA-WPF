#-------------------------------------------------------------------------------
# File 'change_ped_monthend.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'change_ped_monthend.com'
#-------------------------------------------------------------------------------

#  2014/Jul/14  M.C.    $cmd/change_ped_monthend.com called from $cmd/change_ped_first_monthend, 
#                       $cmd/change_ped_second_monthend or $cmd/change_ped_third_monthend
#  2015/Jan/05  MC1     pass ped as the second paramter
Param(
    [string]$1,
    [string]$2
    )
echo ""
echo ""

$rcmd = $env:QTP +"u016 ${1} ${2}"
invoke-expression $rcmd

echo ""
echo ""
