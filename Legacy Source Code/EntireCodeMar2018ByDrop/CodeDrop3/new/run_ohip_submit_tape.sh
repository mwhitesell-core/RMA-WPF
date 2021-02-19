# run_ohip_submit_tape

# 98/Jun/29 B.E. - added 2>/dev/null to #lp statements
# 99/feb/08 B.E. - added logic to create 2nd ohip tape file in y2k V03  format
# 99/feb/12 B.E. - change call to quiz for r085/6/7 pgms 
# 99/feb/22 B.E. - fixed problem with file naming of y2k file
# 99/may/18 B.E. - changed so that y2k version of code is 'normal' file
#

echo Running "run_ohip_submit_tape" ...

# backup_ohip_tape

  
$cmd/run_ohip_submit_tape_no_directs  ${1}

echo U035 IN PROGRESS `date` 

qtp auto=$obj/u035a.qtc
#quiz auto=$obj/r035b.qzc
quiz auto=$obj/r035b.qzu
qtp auto=$obj/u035c.qtc


echo U035 ENDING `date` 

echo
date
echo
echo Done "run_ohip_submit_tape"
