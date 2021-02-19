
# macro: agep_part2
# 2006/nov/21 M.C. create age premium payment batches/claims for all clinic
# 2007/jun/13 M.C. add qutil to tmp-counters-alpha before program execution
#		   add run of r030n.qzc and append ru030n.txt to the end of
#		   ru030k.txt and ru030m.txt
# 2009/Apr/20 M.C. split $cmd/agep into $cmd/agep_part1/2
# 2011/Jul/28 M.C. add run of r030q.qzc                     
# 2013/Sep/11 M.C. add run of r030r.qzu and append ru030r.txt to the end of                    
#		   ru030k.txt and ru030m.txt where r030r.qzu consists of 3 passes r030r1/2/3.qzc
# 2016/Jul/28 MC1  exclude the run of ru030n.qzc as it transfers to run in $cmd/agep_part1
# 2016/Aug/25 MC2  add run of r030k_csv.qzc for Helena      

date

cd $application_production

echo Current Directory:
pwd


echo 
echo  execute powerhouse program u030b_part3_b.qtc  for age premium payment creation
echo 

echo "Running u030b_part3_b.qtc ..."
qtp auto=$obj/u030b_part3_b.qtc

echo 
echo  execute powerhouse program r030k and r030l  for age premium payment reports 
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

#lp ru030k.txt
lp ru030m.txt
lp ru030l.txt
# lp ru030q.txt  ## Mary does not want it

echo 
echo  end of the run for age premium payment PART 2
echo 
date
