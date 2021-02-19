#!/bin/ksh
# utl0201_f020_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#	clinic 99 - "MP" / Manual Payments payroll
#	clinic 10 - "solo/solotest" payroll
#
# 15/Mar/18 M.C. - original  
# 15/Mar/24 MC1  - include f191
# 15/Oct/13 MC2  - transfer final output files in /foxtrot/bi instead of the current directory production;
#	           rename the files to start with bi_xxxxx.ps

echo Running \'utl0201_f020_all.com - extraction of doctor \'

echo `date`
echo $SHELL

echo
echo Setting up Profile ...
. /macros/profile  >>  /alpha/rmabill/rmabill101c/production/utl0201_f020_all.log

echo
echo Setting up to MP Environment ...
rmabill  mp        >> /alpha/rmabill/rmabill101c/production/utl0201_f020_all.log
echo

$cmd/utl0201_f020.com

echo
echo Setting up to SOLO Environment ...
rmabill  solo        >> /alpha/rmabill/rmabill101c/production/utl0201_f020_all.log
echo

$cmd/utl0201_f020.com

echo
echo Setting up to 101C Environment ...
rmabill  101c      >> /alpha/rmabill/rmabill101c/production/utl0201_f020_all.log
echo

$cmd/utl0201_f020.com

# consolidate all 3 environments into 1 file
cd $application_root/production

# utl0f020

cat /alpha/rmabill/rmabill101c/production/utl0f020.ps   \
    /alpha/rmabill/rmabillsolo/production/utl0f020.ps      \
    /alpha/rmabill/rmabillmp/production/utl0f020.ps    > /foxtrot/bi/bi_utl0f020_all.ps

cp utl0f020.psd /foxtrot/bi/bi_utl0f020_all.psd


echo  Done!
echo `date`
