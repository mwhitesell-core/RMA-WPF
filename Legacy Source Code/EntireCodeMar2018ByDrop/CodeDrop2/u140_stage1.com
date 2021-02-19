#!/bin/ksh
#file:  u140_stage1.com
# 04/jun/01 b.e. - original
# 08/sep/08 b.e. - running of u140 moved from u140_stage3.com to this macro
# 08/sep/18 M.C. - include qutil tmp-doctor-alpha before executing u140_a.qts

clear
echo Running \'processing of AFP Conversion Payment file - Stage 1\'
echo 
echo

filename=$1

echo Setup of 101c environment
. /macros/setup_rmabill.com 101c

echo
echo Entering \'upload\' directory
cd $application_upl;pwd

echo
echo recreating file f075 ...
qutil << QUTIL_EXIT
create file f075-afp-doc-mstr
create file tmp-doctor-alpha  
QUTIL_EXIT

echo
echo renaming $filename to afp_fixed_payments.dat ...
mv $filename afp_fixed_payments.dat

echo running u140.cbl ...
cobrun $obj/u140

echo renaming processed file as: $filename.done
mv afp_fixed_payments.dat $filename.done


echo running u140_a.qtc ...

qtp << QTP_EXIT
exec $obj/u140_a.qtc
A
QTP_EXIT

echo Setup of solo environment
. /macros/setup_rmabill.com solo

echo
echo Entering \'upload\' directory
cd $application_upl;pwd

echo recreating file f075 ...
qutil << QUTIL_EXIT
create file f075-afp-doc-mstr
create file tmp-doctor-alpha  
QUTIL_EXIT

echo running u140_a.qtc ...

qtp << QTP_EXIT
exec $obj/u140_a.qtc
C
QTP_EXIT

echo Return to 101c
. /macros/setup_rmabill.com 101c
echo Continue by running "u140_stage2"
echo

echo Done!
