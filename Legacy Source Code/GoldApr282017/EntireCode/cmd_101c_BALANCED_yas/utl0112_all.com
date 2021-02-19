#!/bin/ksh
# utl0112_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#	clinic 99 - "MP" / Manual Payments payroll
#	clinic 10 - "solo/solotest" payroll
#
# 14/Nov/25 M.C. - original  

echo "--- executing utl0112.qtc ---"

echo
echo Return to MP   environment
. /macros/setup_rmabill.com mp   

$cmd/utl0112.com

echo
echo Return to SOLO environment
. /macros/setup_rmabill.com solo

$cmd/utl0112.com

echo
echo Return to 101c environment
. /macros/setup_rmabill.com 101c

$cmd/utl0112.com

# consolidate all 3 environments into 1 file
cd $application_root/production

cat /alpha/rmabill/rmabill101c/production/utl0f112.ps    \
    /alpha/rmabill/rmabillsolo/production/utl0f112.ps    \
    /alpha/rmabill/rmabillmp/production/utl0f112.ps     > utl0f112_all.ps

cp utl0f112.psd utl0f112_all.psd


echo  Done!
