#!/bin/ksh
#file:  u140_stage2.com
# 04/jun/01 b.e. - original

clear
echo
echo Running \'processing of AFP Conversion Payment file - Stage 2\'
echo
echo Consolidating subfile u030_paid_amt into \'upload\' directory
echo
$cmd/consolidate_u030_paid_amt_subfile

echo Entering \'upload\' directory
cd $application_upl;pwd

echo
echo running u030b_1.qtc

qtp auto=$obj/u030b_1.qtc

echo
echo Done!
