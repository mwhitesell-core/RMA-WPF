
# macro: mohd_part1
# 2013/May/15 M.C. clone from agep_part1   for MOHD payments  
# 2016/Jul/28 MC1  transfer the run of r030n.qzc from $cmd/mohd_part2 to here
# 2016/Aug/25 MC2  change from ru031?mohd.txt to ru030*mohd*txt

date

cd $application_production/22

echo Current Directory:
pwd

ls r031a.dat
rm 1>/dev/null 2>/dev/null r031*.sf* r031*txt ru030*mohd*txt

echo recreate the empty temporary scratch file tmp-counters-alpha

qutil << eof_qutil
create file tmp-counters-alpha
create file tmp-doctor-alpha
eof_qutil

echo 
echo  execute powerhouse program u030b_part3_a.qtc  for MOHD  payment creation
echo 

echo "Running u030b_part3_a.qtc ..."
qtp auto=$obj/u030b_part3_a.qtc

quiz  auto=$obj/r031c.qzu           

mv r031c.txt r031c_mohd.txt
lp r031c_mohd.txt 

# MC1
quiz  auto=$obj/r030n.qzc
cp ru030n.txt ru030n_mohd.txt
lp ru030n_mohd.txt

echo save tmp_counter_alpha created from u030b_part3_a to production/22

cd $pb_data
cp tmp_doctor_alpha.*   $application_production/22

echo copy tmp_doctor_alpha_mohd back before running r031_part3_before_update

cp tmp_doctor_alpha_mohd.dat   tmp_doctor_alpha.dat
cp tmp_doctor_alpha_mohd.idx   tmp_doctor_alpha.idx

cd $application_production/22

quiz auto=$obj/r031_part3_before_update.qzc
#lp r031b_part3.txt 

echo 
echo  end of the run for MOHD payment PART 1
echo 
date

