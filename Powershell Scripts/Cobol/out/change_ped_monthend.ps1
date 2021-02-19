#-------------------------------------------------------------------------------
# File 'change_ped_monthend.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'change_ped_monthend.com'
#-------------------------------------------------------------------------------

#  2014/Jul/14  M.C.    $cmd/change_ped_monthend.com called from $cmd/change_ped_first_monthend, 
#                       $cmd/change_ped_second_monthend or $cmd/change_ped_third_monthend
#  2015/Jan/05  MC1     pass ped as the second paramter

echo ""
echo ""

$pipedInput = @"
exec $obj/u016.qtc
${1}
${2}
"@

$pipedInput | qtp++

echo ""
echo ""
