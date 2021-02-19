#!/bin/ksh
# 08/jun/15 b.e. - original

echo Setup of 101c environment
. /macros/setup_rmabill.com 101c

echo Entering \'upload\' directory
cd $application_upl;pwd

echo running u122.qts ...
qtp  << QTP_EXIT
exec $obj/u122.qtc
QTP_EXIT

echo Setup of MP environment
. /macros/setup_rmabill.com mp

echo Entering \'upload\' directory
cd $application_upl;pwd

echo running u122.qts ...
qtp  << QTP_EXIT
exec $obj/u122.qtc
QTP_EXIT

echo
echo Return to 101c
. /macros/setup_rmabill.com 101c

echo Entering \'upload\' directory
cd $application_upl;pwd


echo Done!
