#  2014/Jul/14	M.C.	$cmd/change_ped_third_monthend
#  2015/Jan/05  MC1     pass ped as the second parameter, user must change ped each month

echo "Change cycle nbr and monthend date for clinics in third monthend.."
echo
echo
echo

cd $application_root/production

# MC1
#$cmd/change_ped_monthend.com  3  > change_ped_third_monthend.log
$cmd/change_ped_monthend.com  3  ${1} > change_ped_third_monthend.log

echo
echo
