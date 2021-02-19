cd $application_production

rm r997_clinic22_84J.txt

quiz << quiz_exit
exec $obj/r997_clinic22_84J_a
exec $obj/r997_clinic22_84J_b
quiz_exit

cp r997_clinic22_84J.txt r997g_84J_22
