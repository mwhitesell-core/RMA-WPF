#!/bin/ksh
#file:  process_afp_converion_payment_4.com
# 04/jun/01 b.e. - original
# 08/jun/15 b.e. - added delete of f119 and f119_tithe subfiles in both environmemts
# 08/aug/05 M.C. - change or pass parameter C for solo, B is for MP only
#		 - removed delete of f119 and f119_tithe subfiles as these are no longer used (trans put into f114 instead)
# 08/oct/14 M.C. - comment the execution of delete_f114_afpcon.qts

echo Setup of 101c environment
. /macros/setup_rmabill.com 101c

echo Entering \'upload\' directory
cd $application_upl;pwd

# removed delete of f119 and f119_tithe subfiles as these are no longer used (trans put into f114 instead)
##echo "Resetting subfiles file"
##rm f119.sf*
##rm f119_tithe.sf*
rm u140_e_audit.sf*

# one-time running - to be removed later
#qtp auto=$obj/delete_f114_afpcon.qtc

echo running u140_e.qts ...
qtp  << QTP_EXIT
exec $obj/u140_e.qtc
A
A
QTP_EXIT

echo Setup of Solotest environment
. /macros/setup_rmabill.com solo

echo Entering \'upload\' directory
cd $application_upl;pwd

#rm f119.sf*
#rm f119_tithe.sf*

# one-time running - to be removed later
#qtp auto=$obj/delete_f114_afpcon.qtc

echo running u140_e.qts ...
qtp  << QTP_EXIT
exec $obj/u140_e.qtc
C
C
QTP_EXIT

echo
echo Return to 101c
. /macros/setup_rmabill.com 101c

echo Entering \'upload\' directory
cd $application_upl;pwd

quiz << QUIZ_EXIT
exec $obj/r140_e.qzc
QUIZ_EXIT
#lp r140_e.txt

echo

echo Running verification programs ..
$cmd/r140_verify

echo Done!
