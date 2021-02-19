#!/bin/ksh
#file:  utl0200.com
# 05/jul/20 b.e. - original
# 15/Oct/20 MC1  - move utl0200.ps and rename as bi_utl0200.ps to /foxtrot/bi as Brad agreed

echo Running \'utl0200.com - extraction of doctor info for download to excel\'

echo `date`
echo $SHELL

echo
echo Setting up Profile ...
. /macros/profile  >>  /alpha/rmabill/rmabill101c/production/utl0200.log

echo
echo Setting up Environment ...
rmabill 101c       >> /alpha/rmabill/rmabill101c/production/utl0200.log
echo

echo Entering \'production\' directory
cd $application_production;pwd


echo
rm utl0200.ps
rm utl0200.psd
echo recreating file utl0200.ps ...
qtp auto=$obj/utl0200.qtc

# MC1 
mv  utl0200.ps     /foxtrot/bi/bi_utl0200.ps
mv  utl0200.psd    /foxtrot/bi/bi_utl0200.psd


echo
echo Done!
