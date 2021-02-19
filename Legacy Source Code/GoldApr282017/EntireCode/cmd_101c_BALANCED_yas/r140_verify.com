# r140_verify

echo Setup of 101c environment
. /macros/setup_rmabill.com  101c
echo
echo Entering \'upload\' directory
cd $application_upl;pwd

rm 1>/dev/null 2>&1  r140w.txt

qutil << EOP_QUTIL
create file tmp-governance-payments-file
EOP_QUTIL

#echo Runnin g r140v_1  in 101c
#qtp auto=$obj/r140v_1.qtc

#echo Running  r140v_2 in 101c
#qtp << EOJ_QTP
#exec $obj/r140v_2.qtc
#A
#EOJ_QTP

qtp auto=$obj/r140w1.qtc
qtp auto=$obj/r140w2.qtc


echo Setup of SOLO environment
. /macros/setup_rmabill.com  solo
echo
echo Entering \'upload\' directory
cd $application_upl;pwd

#echo Running  r140v_2  in SOLO
#qtp << EOJ_QTP
#exec $obj/r140v_2.qtc
#C
#EOJ_QTP

qtp auto=$obj/r140w2.qtc

echo Returning to 101c environment
. /macros/setup_rmabill.com  101c
echo
echo Entering \'upload\' directory
cd $application_upl;pwd

#echo Running  r140v_3  in 101c
#quiz auto=$obj/r140v_3.qzc

quiz auto=$obj/r140w3.qzc

#lp r140v.txt
