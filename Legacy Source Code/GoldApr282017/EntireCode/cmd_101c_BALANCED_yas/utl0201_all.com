#!/bin/ksh
# utl0201_all.com

# NOTE: clinic 22 - "normal" clinic 22 payroll
#	clinic 99 - "MP" / Manual Payments payroll
#	clinic 10 - "solo/solotest" payroll
#
# 15/Mar/18 M.C. - original  
# 15/Mar/24 MC1  - include f191
# 15/Oct/13 MC2  - transfer final output files in /foxtrot/bi instead of the current directory production;
#	           rename the files to start with bi_xxxxx.ps

echo Running \'utl0201.com - extraction of doctor / audit files / f119 payments  \'

echo `date`
echo $SHELL

echo
echo Setting up Profile ...
. /macros/profile  >>  /alpha/rmabill/rmabill101c/production/utl0201_all.log

echo
echo Setting up to MP Environment ...
rmabill  mp        >> /alpha/rmabill/rmabill101c/production/utl0201_all.log
#. /macros/setup_rmabill.com mp   
echo

$cmd/utl0201.com

echo
echo Setting up to SOLO Environment ...
rmabill  solo        >> /alpha/rmabill/rmabill101c/production/utl0201_all.log
#. /macros/setup_rmabill.com  solo    
echo

$cmd/utl0201.com

echo
echo Setting up to 101C Environment ...
rmabill  101c      >> /alpha/rmabill/rmabill101c/production/utl0201_all.log
#. /macros/setup_rmabill.com  101c
echo

$cmd/utl0201.com

# consolidate all 3 environments into 1 file
cd $application_root/production

# utlf020_audit
cat /alpha/rmabill/rmabill101c/production/utlf020_audit.ps	\
    /alpha/rmabill/rmabillsolo/production/utlf020_audit.ps      \
    /alpha/rmabill/rmabillmp/production/utlf020_audit.ps    > /foxtrot/bi/bi_utlf020_audit_all.ps

# MC2
#cp utlf020_audit.psd utlf020_audit_all.psd
cp utlf020_audit.psd  /foxtrot/bi/bi_utlf020_audit_all.psd

# utlf028_audit

cat /alpha/rmabill/rmabill101c/production/utlf028_audit.ps	\
    /alpha/rmabill/rmabillsolo/production/utlf028_audit.ps      \
    /alpha/rmabill/rmabillmp/production/utlf028_audit.ps    > /foxtrot/bi/bi_utlf028_audit_all.ps

# MC2
#cp utlf028_audit.psd utlf028_audit_all.psd
cp utlf028_audit.psd /foxtrot/bi/bi_utlf028_audit_all.psd

# utlf110_audit

cat /alpha/rmabill/rmabill101c/production/utlf110_audit.ps	\
    /alpha/rmabill/rmabillsolo/production/utlf110_audit.ps      \
    /alpha/rmabill/rmabillmp/production/utlf110_audit.ps    > /foxtrot/bi/bi_utlf110_audit_all.ps

# MC2
#cp utlf110_audit.psd utlf110_audit_all.psd
cp utlf110_audit.psd /foxtrot/bi/bi_utlf110_audit_all.psd

# utlf112_audit

cat /alpha/rmabill/rmabill101c/production/utlf112_audit.ps	\
    /alpha/rmabill/rmabillsolo/production/utlf112_audit.ps      \
    /alpha/rmabill/rmabillmp/production/utlf112_audit.ps    > /foxtrot/bi/bi_utlf112_audit_all.ps

# MC2
#cp utlf112_audit.psd utlf112_audit_all.psd
cp utlf112_audit.psd /foxtrot/bi/bi_utlf112_audit_all.psd

# utl0f020

cat /alpha/rmabill/rmabill101c/production/utl0f020.ps	\
    /alpha/rmabill/rmabillsolo/production/utl0f020.ps      \
    /alpha/rmabill/rmabillmp/production/utl0f020.ps    > /foxtrot/bi/bi_utl0f020_all.ps

# MC2
#cp utl0f020.psd utl0f020_all.psd
cp utl0f020.psd /foxtrot/bi/bi_utl0f020_all.psd

# utl0201_f119

cat /alpha/rmabill/rmabill101c/production/utl0201_f119.ps	\
    /alpha/rmabill/rmabillsolo/production/utl0201_f119.ps      \
    /alpha/rmabill/rmabillmp/production/utl0201_f119.ps     > /foxtrot/bi/bi_utl0201_f119_all.ps

# MC2
#cp utl0201_f119.psd utl0201_f119_all.psd
cp utl0201_f119.psd /foxtrot/bi/bi_utl0201_f119_all.psd

# utl0201_f119_audit

cat /alpha/rmabill/rmabill101c/production/utl0201_f119_audit.ps	\
    /alpha/rmabill/rmabillsolo/production/utl0201_f119_audit.ps      \
    /alpha/rmabill/rmabillmp/production/utl0201_f119_audit.ps     > /foxtrot/bi/bi_utl0201_f119_audit_all.ps

# MC2
#cp utl0201_f119_audit.psd utl0201_f119_audit_all.psd
cp utl0201_f119_audit.psd /foxtrot/bi/bi_utl0201_f119_audit_all.psd

# utl0201_f119_history

cat /alpha/rmabill/rmabill101c/production/utl0201_f119_history.ps	\
    /alpha/rmabill/rmabillsolo/production/utl0201_f119_history.ps      \
    /alpha/rmabill/rmabillmp/production/utl0201_f119_history.ps     > /foxtrot/bi/bi_utl0201_f119_history_all.ps

# MC2
#cp utl0201_f119_history.psd utl0201_f119_history_all.psd
cp utl0201_f119_history.psd /foxtrot/bi/bi_utl0201_f119_history_all.psd

# MC1
# utl0f191  

cat /alpha/rmabill/rmabill101c/production/utl0f191.ps          \
    /alpha/rmabill/rmabillsolo/production/utl0f191.ps     \
    /alpha/rmabill/rmabillmp/production/utl0f191.ps     > /foxtrot/bi/bi_utl0f191_all.ps

# MC2
#cp utl0f191.psd utl0f191_all.psd
cp utl0f191.psd /foxtrot/bi/bi_utl0f191_all.psd

##################################

qtp auto=$obj/utl0030.qtc

# MC2
cp  utl0f090_rec6.ps    /foxtrot/bi/bi_utl0f090_rec6.ps
cp  utl0f090_rec6.psd   /foxtrot/bi/bi_utl0f090_rec6.psd
cp  utl0f030.ps         /foxtrot/bi/bi_utl0f030.ps 
cp  utl0f030.psd        /foxtrot/bi/bi_utl0f030.psd
cp  utl0f070.ps         /foxtrot/bi/bi_utl0f070.ps
cp  utl0f070.psd        /foxtrot/bi/bi_utl0f070.psd 
cp  utl0f190.ps         /foxtrot/bi/bi_utl0f190.ps
cp  utl0f190.psd        /foxtrot/bi/bi_utl0f190.psd 
cp  utl0f090_clinic.ps  /foxtrot/bi/bi_utl0f090_clinic.ps
cp  utl0f090_clinic.psd /foxtrot/bi/bi_utl0f090_clinic.psd 
cp  utl0f123.ps         /foxtrot/bi/bi_utl0f123.ps
cp  utl0f123.psd        /foxtrot/bi/bi_utl0f123.psd

echo  Done!
echo `date`
