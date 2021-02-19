# 2014/Oct/14	MC1	no longer need to pass parameter for u100.qts but need in u100_b.qzs
# 2014/Oct/15   MC2     include the run of u100_c.qzs

echo Running verify_solo_payroll_ok_to_run ...
echo
date
echo


cd $application_root/production
rm u100.txt u100_b.txt u100_c.txt
rm u100*.sf*

# MC1 - reinstate below
qtp auto=$obj/u100.qtc

#qtp << QTP_EXIT
#exec $obj/u100.qtc
#C
#QTP_EXIT

##quiz auto=$obj/u100.qzc -comment by MC on 2009/oct/06
quiz auto=$obj/u100.qzu
echo
echo The following report U100.txt should be blank - otherwise DON''T run payoll!
echo
pg u100.txt

# 2014/Sep/24 - MC1
quiz << QUIZ_EXIT
use  $src/u100_b.qzs
C 
;20140630
use  $src/u100_c.qzs
exit
QUIZ_EXIT


echo
echo The following report U100_b.txt should be blank - otherwise DON''T run payoll!
echo
pg u100_b.txt


echo
echo The following report U100_c.txt should be blank - otherwise DON''T run payoll!
echo
##pg u100_c.txt

lp u100.txt u100_b.txt  
