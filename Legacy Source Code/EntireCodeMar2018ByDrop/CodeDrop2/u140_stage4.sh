#!/bin/ksh
#file:  u140_stage4
# 04/jun/01 b.e. - original

clear
echo Running \'processing of AFP Conversion Payment file - Stage 4\'
echo 
#if [ "$1" = "" ]
#then
#  echo
#  echo 
#  echo  **ERROR**
#  echo  You must supply the Payroll ID of the payroll you are generating [A or B]
#  echo
#  exit
#else
#  if [ $1 != "A" ] && [ $1 != "B" ]
#  then
#    echo
#    echo 
#    echo  **ERROR**
#    echo  \[$1\] is not a valid Payroll ID [must be A or B]
#    echo
#    exit
#  else

echo 
#echo  'HIT  "NEWLINE"  TO CONTINUE'
#read garbage
echo 
echo Process now loading ... when done the log file will be paged to your screen

#$cmd/u140_stage4.com $1 > u140_stage4.log

$cmd/u140_stage4.com > u140_stage4.log
pg u140_stage4.log

#fi
#fi
