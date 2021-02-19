#!/bin/ksh
#file:  utl0004.com
# 12/Nov/13 M.C. - original

echo Running \'utl0004.com - extraction of doctor / dept name/nbr for portal link\'

echo `date`
echo $SHELL

echo
echo Setting up Profile ...
. /macros/profile  >>  /alpha/rmabill/rmabill101c/production/utl0004.log

echo
echo Setting up Environment ...
rmabill 101c       >> /alpha/rmabill/rmabill101c/production/utl0004.log
#. /macros/setup_rmabill.com 101c
echo

echo Entering \'producton\' directory
cd $application_production;pwd


echo
rm utl0004.txt
echo recreating report utl0004.txt ..
quiz auto=$obj/utl0004.qzc
echo
echo Done!

echo `date`
