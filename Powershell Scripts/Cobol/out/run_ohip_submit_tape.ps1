#-------------------------------------------------------------------------------
# File 'run_ohip_submit_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_ohip_submit_tape'
#-------------------------------------------------------------------------------

# run_ohip_submit_tape

# 98/Jun/29 B.E. - added 2>/dev/null to #lp statements
# 99/feb/08 B.E. - added logic to create 2nd ohip tape file in y2k V03  format
# 99/feb/12 B.E. - change call to quiz for r085/6/7 pgms 
# 99/feb/22 B.E. - fixed problem with file naming of y2k file
# 99/may/18 B.E. - changed so that y2k version of code is 'normal' file
#

echo "Runningrun_ohip_submit_tape ..."

# backup_ohip_tape


$cmd\run_ohip_submit_tape_no_directs  ${1}

echo "U035 IN PROGRESS$(udate)"

qtp++ $obj\u035a
#quiz auto=$obj/r035b.qzc
quiz++ $obj\r035b
qtp++ $obj\u035c


echo "U035 ENDING$(udate)"

echo ""
Get-Date
echo ""
echo "Donerun_ohip_submit_tape"
