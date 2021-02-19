#!/bin/ksh
#file:  u140_stage3.com
# 04/jun/01 b.e. - original

clear
echo Running \'processing of AFP Conversion Payment file - Stage 3\'
echo
echo Entering \'upload\' directory
cd $application_upl;pwd

filename=$1
echo 
echo renaming $filename to afp_fixed_payments.dat ... 
mv $filename afp_fixed_payments.dat

echo running u140.cbl ...
cobrun $obj/u140

echo recreating file tmp_alpha_doctor ...
qutil << QUTIL_EXIT
create file tmp-doctor-alpha
QUTIL_EXIT

echo running u140_b / 140_c / u140_d ...
qtp  auto=$obj/u140_b.qtc	' determine percentage RA payments '
qtp  auto=$obj/u140_c.qtc	' update f075 with a1f payment amt	'
#clear subfile before running so that values can accumulate between 101c and mp
if  [ $RMABILL_VERSION = 101c ]
then
 echo removing u140_d1 subfile
  rm u140_d1.sf*
else
 echo bypassing the removeal of u140_d1 subfile

fi
qtp  auto=$obj/u140_d.qtc	' divy up AFP payment based upon RA percentage'

echo running r140 reports ...
echo Running .. report group total amount 
echo Running .. group conversion detail report 
echo Running .. solo conversion detail report 
echo Running .. total Conversion payment report 
echo Running .. governance Total payment report
quiz << QUIZ_EXIT
exec $obj/r140_a1f.qzc
exec $obj/r140_a2g.qzc
exec $obj/r140_a2s.qzc
exec $obj/r140_a3c.qzc
exec $obj/r140_a4t.qzc

QUIZ_EXIT

ls -l r140_a1f.txt r140_a2g.txt r140_a2s.txt r140_a3c.txt r140_a4t.txt r140_a.txt
# these reports run after MP payroll so that all transaction can be included
#echo running r140_reports
#$cmd/r140_reports

echo
echo
echo Confirm the above reports are correct and then complete this process
echo by running "u140_stage4"
echo

echo renaming processed file as: $filename.done
mv afp_fixed_payments.dat $filename.done

echo
echo Setup of MP environment
. /macros/setup_rmabill.com mp

echo
echo Entering \'upload\' directory
cd $application_upl;pwd

echo Running MP stage3.com
$cmd/u140_stage3_mp.com

echo
echo
echo Return to 101c environment
. /macros/setup_rmabill.com 101c

echo
echo Entering \'upload\' directory
cd $application_upl;pwd

echo removing duplicates from u140_d1 subfile
qtp auto=$obj/u140_d1_remove_dups.qtc
mv u140_d1.sf  u140_d1_with_dups.sf
mv u140_d1.sfd u140_d1_with_dups.sfd
 
mv u140_d2.sf  u140_d1.sf
mv u140_d2.sfd u140_d1.sfd

echo ensure that all docs in u140_d1 are also in f075
echo running u140_f.qtc
qtp auto=$obj/u140_f.qtc

echo run reports
# run reports
$cmd/r140_reports

echo Entering \'upload\' directory
cd $application_upl;pwd

echo Done!
