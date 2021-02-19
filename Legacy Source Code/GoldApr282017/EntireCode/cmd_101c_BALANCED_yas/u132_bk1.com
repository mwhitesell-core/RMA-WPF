#!/bin/ksh
#file:  u132.com
# 04/sep/20 b.e. - original

clear
echo Running \'processing of Payroll Transactions Upload \'
echo
echo Entering \'upload\' directory
cd $application_upl;pwd

seqnbr=$1
filename=$2
echo Running r132.qzc
quiz auto=$obj/r132.qzc > u132.log << QUIZ_EXIT 
$1 
$2
QUIZ_EXIT

chmod +x r132_awk.txt
echo Running r132.awk.txt
./r132_awk.txt

echo running u132
qtp  auto=$obj/u132.qtc

rm r133.txt 1>/dev/null  2>/dev/null
echo Running audit report - the report MUST BE ZERO LENGTH or Errors!
quiz auto=$obj/r133.qzc
echo The report MUST BE ZERO LENGTH or there are Errors!
echo hit New-line to display the report
read garbage
pg r133.txt 2>/dev/null


echo renaming processed file as: $filename.done
mv u132.dat $filename.done

cd $production

echo
#echo Done!
