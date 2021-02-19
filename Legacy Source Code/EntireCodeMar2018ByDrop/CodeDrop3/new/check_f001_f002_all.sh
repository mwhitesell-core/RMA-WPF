#!/bin/ksh
# $cmd/check_f001_f002_all    - this macro will access f001 & f002 hdr/dtl to determine if
#				differences found between the files

# program "check_f001_f002_all.qzs" is in $src directory
#It only picks up records with batch status < 2 (not yet update to f050 file).
#It will display records in extf002hdr_diff.txt if there is difference between f001 & f002 hdr (amount or nbr of claims),
#and in extf002dtl_diff.txt if there is difference between f001 & f002 dtl (amount or nbr of svc)

# 2012/Nov/28 - add the timestamp for reports & log

echo
echo Setting up Profile ...
. /macros/profile  >>  /alpha/rmabill/rmabill101c/production/check_f001_f002_all.log

echo
echo Setting up Environment ...
rmabill 101c >>  /alpha/rmabill/rmabill101c/production/check_f001_f002_all.log

echo Entering \'producton\' directory
cd $application_production;pwd
echo

rm extf002dtl_diff.txt
rm extf002hdr_diff.txt

timeStamp=20`date +%y_%m_%d.%H:%M` ;export timeStamp

quiz auto=$obj/check_f001_f002_all.qzu > check_f001_f002_all_$timeStamp.log

ls -l *diff.txt

mv extf002dtl_diff.txt extf002dtl_diff_$timeStamp.txt
mv extf002hdr_diff.txt extf002hdr_diff_$timeStamp.txt
mv extf002hdrdtl_diff.txt extf002hdrdtl_diff_$timeStamp.txt
        

