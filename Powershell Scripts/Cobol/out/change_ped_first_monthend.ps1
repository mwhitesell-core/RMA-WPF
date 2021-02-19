#-------------------------------------------------------------------------------
# File 'change_ped_first_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'change_ped_first_monthend'
#-------------------------------------------------------------------------------

#  2014/Jul/14  M.C.    $cmd/change_ped_first_monthend
#  2015/Jan/05  MC1     pass ped as the second parameter, user must change ped each month

echo "Change cycle nbr and monthend date for clinics in first monthend.."
echo ""
echo ""
echo ""

Set-Location $application_root\production

# MC1
#$cmd/change_ped_monthend.com  1  > change_ped_first_monthend.log
$cmd\change_ped_monthend.com  1 ${1}  > change_ped_first_monthend.log

echo ""
echo ""
