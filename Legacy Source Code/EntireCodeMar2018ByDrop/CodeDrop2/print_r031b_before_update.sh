# macro: print_r031b_before_update
# 2009/Apr/06 M.C. consolidate r031a_AGE3/AGEP/MOHR into r031a.dat, it will create r031b.txt
#                  compare this report with r031b_agep.txt.  Their amounts should match.
# 2013/May/16 MC1  change to exec r031_before_update.qzu for 2 passes
# 2013/Sep/11 MC2  change to exec r031_before_update.qzu for 3 passes

date

cd $application_production

echo Current Directory:
pwd

cat r031a_AGE3.dat r031a_AGEP.dat r031a_MOHR.dat > r031a.dat

echo 
echo  execute powerhouse program r031_before_update_1/2/3.qzc  
echo 
quiz auto=$obj/r031_before_update.qzu

lp r031b.txt   

echo 
echo 
date

