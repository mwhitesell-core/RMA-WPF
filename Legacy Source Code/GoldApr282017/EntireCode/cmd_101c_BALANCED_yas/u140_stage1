#!/bin/ksh
#file:  u140_stage1
# 04/jun/01 b.e. - original
# 08/sep/09 M.C. - transfer filename check from u140_stage3

clear
echo Running \'processing of AFP Conversion Payment file - Stage 1\'
echo 
echo 

filename=$1

if [ "$1" = "" ]
then
  echo
  echo
  echo  **ERROR**
  echo  You must supply the name of the file you want to process
  echo
  exit
else
if [ ! -f $filename ]
then
  echo
  echo
  echo **ERROR** No such file to process - $filename
  echo
  exit
else
  if ( [ -f afp_fixed_payments.dat ] )
  then
    echo
    echo **ERROR**
    echo Unprocessed file 'afp_fixed_payments.dat' already exists - process it first!
    echo
    exit
  else

echo
echo
echo Process now loading ... when done the log file will be paged to your screen

$cmd/u140_stage1.com $1 > u140_stage1.log
pg u140_stage1.log
fi
fi
fi


