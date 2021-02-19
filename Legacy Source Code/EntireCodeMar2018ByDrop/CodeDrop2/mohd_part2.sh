
# macro: mohd_part2
# 2013/May/15 M.C. clone from agep_part2 for MOHD  
# 2013/Sep/11 M.C. add run of r030r.qzu and append ru030r.txt to the end of
#                  ru030k.txt and ru030m.txt where r030r.qzu consists of 3 passes r030r1/2/3.qzc
# 2016/Jul/28 MC1  exclude the run of ru030n.qzc as it transfers to run in $cmd/mohd_part1
# 2016/Aug/25 MC2  add run of r030k_csv.qzc

date

cd $application_production/22

echo Current Directory:
pwd


echo 
echo  execute powerhouse program u030b_part3_b.qtc  for MOHD payment creation
echo 

echo "Running u030b_part3_b.qtc ..."
qtp auto=$obj/u030b_part3_b.qtc

echo 
echo  execute powerhouse program r030k and r030l  for MOHD  payment reports 
echo 
quiz auto=$obj/r030k.qzc
# MC2
quiz auto=$obj/r030k_csv.qzc
quiz auto=$obj/r030l.qzc
quiz auto=$obj/r030m.qzc
# MC1
# quiz auto=$obj/r030n.qzc
quiz auto=$obj/r030q.qzc
quiz auto=$obj/r030r.qzu

cat ru030n.txt >> ru030k.txt
cat ru030n.txt >> ru030m.txt

cat ru030r.txt >> ru030k.txt
cat ru030r.txt >> ru030m.txt

mv ru030k.txt ru030k_mohd.txt
mv ru030l.txt ru030l_mohd.txt
mv ru030m.txt ru030m_mohd.txt
mv ru030n.txt ru030n_mohd.txt
mv ru030q.txt ru030q_mohd.txt
mv ru030r.txt ru030r_mohd.txt

# MC2
mv ru030k_csv.txt ru030k_mohd_csv.txt

#lp ru030k_mohd.txt
lp ru030m_mohd.txt
lp ru030l_mohd.txt

echo 
echo  end of the run for MOHD payment PART 2
echo 
date

