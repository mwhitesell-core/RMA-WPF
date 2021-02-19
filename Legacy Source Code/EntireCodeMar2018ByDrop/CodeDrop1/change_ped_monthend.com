#  2014/Jul/14	M.C.	
$cmd/change_ped_monthend.com called from $cmd/change_ped_first_monthend, 

#			
$cmd/change_ped_second_monthend or $cmd/change_ped_third_monthend

#  2015/Jan/05	MC1	pass ped as the second paramter

echo
echo


qtp << QTP_EXIT 

exec $obj/u016.qtc

${1}
${2}

QTP_EXIT


echo

echo

