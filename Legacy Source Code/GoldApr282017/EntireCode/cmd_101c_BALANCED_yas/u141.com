#!/bin/ksh
#file:  u141.com
# 2015/Nov/17	b.e. - original

clear
echo Running \'processing of d004 Excel Transactions Upload \'
echo
echo Entering \'upload\' directory
cd $application_upl;pwd

filename=$1
echo Running r141.awk
#file: u141_awk.com
awk -f $cmd/u141.awk < $1 > $pb_data/misc_payment_file.dat

cd $production

echo
#echo Done!
