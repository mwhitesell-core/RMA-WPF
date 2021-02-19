
# macro: agep_part1
# 2006/nov/21 M.C. create age premium payment batches/claims for all clinic
# 2007/jun/13 M.C. add qutil to tmp-counters-alpha before program execution
#		   add run of r030n.qzc and append ru030n.txt to the end of
#		   ru030k.txt and ru030m.txt
# 2009/Apr/20 M.C. split $cmd/agep into $cmd/agep_part1/2   
# 2013/Mar/27 M.C. add qutil to tmp-doctor-alpha
# 2016/Jul/28 MC1  transfer the run of r030n.qzc from $cmd/agep_part2 to here
# 2016/Aug/25 MC2  change from ru030k.txt to ru030k*.txt from rm 
date

cd $application_production

echo Current Directory:
pwd

ls r031a.dat
rm 1>/dev/null 2>/dev/null r031*.sf* ru030k*.txt ru030l.txt ru030m.txt ru030n.txt ru030q.txt ru030r.txt

echo recreate the empty temporary scratch file tmp-counters-alpha

qutil << eof_qutil
create file tmp-counters-alpha
create file tmp-doctor-alpha
eof_qutil

echo 
echo  execute powerhouse program u030b_part3_a.qtc  for age premium payment creation
echo 

echo "Running u030b_part3_a.qtc ..."
qtp auto=$obj/u030b_part3_a.qtc

quiz  auto=$obj/r031c.qzu           

lp r031c.txt 

# MC1
quiz  auto=$obj/r030n.qzc          
lp ru030n.txt 

echo 
echo  end of the run for age premium payment PART 1
echo 
date

