# 2015/Nov/10	MC 		Automate miscellaneous payment batches/claims
#				This is the first part - data verification
#				This macro can be run as many times as needed to make sure data are correct
#				before transaction creation

#cd $application_root/production
cd $application_upl 


rm r141*txt  u141*sf*

qtp  auto=$obj/u141a.qtc

quiz auto=$obj/r141b1.qzc

quiz auto=$obj/r141b2.qzc

#lp r141a_error.txt r141a_valid.txt

