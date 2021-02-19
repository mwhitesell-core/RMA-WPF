# 2012/Jan/30 - M.C. 	- original
#			- clone from $cmd/u030_clinic_88_part2       
#			- this can be run for any clinic to create auto adjustment at detail level from u030_no_adj.sf

echo 
echo 
echo   save the original part_adj_batch and recreate an empty one 
echo 
echo 

mv part_adj_batch.dat part_adj_batch_orig.dat
mv part_adj_batch.idx part_adj_batch_orig.idx

qutil 1>/dev/null 2>&1 << QUTIL_EXIT
create file part-adj-batch
QUTIL_EXIT

echo 
echo  execute program u030b_autoadj_clinic_dtl
echo 

qtp auto=$obj/u030b_autoadj_clinic_dtl.qtc

mv u030_dtl_key.sf     u030_dtl_key_orig.sf
cp u030_88_dtl_key.sf  u030_dtl_key.sf 


echo 
echo  write inverted claim detail key to the adjusting claim detail record
echo 
cobrun $obj/u030c
echo 

quiz auto=$obj/r030i_2.qzc
quiz auto=$obj/r030i_3.qzc

lp ru030f2.txt ru030f3.txt

echo 
echo  end of the run for u030b auto adj for clinic detail
echo 
date
