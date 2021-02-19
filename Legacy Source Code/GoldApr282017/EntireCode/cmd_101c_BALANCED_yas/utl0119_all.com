#!/bin/ksh
# utl0119_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#	clinic 99 - "MP" / Manual Payments payroll
#	clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  

echo "--- executing utl0119.qtc ---"

echo
echo Return to MP   environment
. /macros/setup_rmabill.com mp   

$cmd/utl0119.com

echo
echo Return to SOLO environment
. /macros/setup_rmabill.com solo

$cmd/utl0119.com

echo
echo Return to 101c environment
. /macros/setup_rmabill.com 101c

$cmd/utl0119.com

# consolidate all 3 environments into 1 file
cd $application_root/production

cat /alpha/rmabill/rmabill101c/production/utl0f119_A.ps    \
    /alpha/rmabill/rmabillsolo/production/utl0f119_A.ps    \
    /alpha/rmabill/rmabillmp/production/utl0f119_A.ps     > utl0f119_all.ps

cp utl0f119_A.psd utl0f119_all.psd

cat /alpha/rmabill/rmabill101c/production/utl0f020_B.ps    \
    /alpha/rmabill/rmabillsolo/production/utl0f020_B.ps    \
    /alpha/rmabill/rmabillmp/production/utl0f020_B.ps     > utl0f020_all.ps

cp utl0f020_B.psd utl0f020_all.psd

##################################
# below can be deleted after testing

cat /alpha/rmabill/rmabill101c/production/utl0f020_A.ps    \
    /alpha/rmabill/rmabillsolo/production/utl0f020_A.ps    \
    /alpha/rmabill/rmabillmp/production/utl0f020_A.ps     > utl0f020_all_A.ps

cp utl0f020_A.psd utl0f020_all_A.psd

##################################

qtp auto=$obj/utl0030.qtc

echo  Done!
