#!/bin/ksh
#file:  u132.com
# 04/sep/20 b.e. - original
# 07/jan/09 b.e. - add additional parameter to this macro to indicate type of payment

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

echo Backing up f114 file before update ...
cd ../data
pwd
ls -l f114*
mv f114_special_payments_bk4.idx f114_special_payments_bk5.idx
mv f114_special_payments_bk3.idx f114_special_payments_bk4.idx
mv f114_special_payments_bk2.idx f114_special_payments_bk3.idx
mv f114_special_payments_bk1.idx f114_special_payments_bk2.idx
cp f114_special_payments.idx     f114_special_payments_bk1.idx

mv f114_special_payments_bk4.dat f114_special_payments_bk5.dat
mv f114_special_payments_bk3.dat f114_special_payments_bk4.dat
mv f114_special_payments_bk2.dat f114_special_payments_bk3.dat
mv f114_special_payments_bk1.dat f114_special_payments_bk2.dat
cp f114_special_payments.dat     f114_special_payments_bk1.dat

cd ../upload
pwd

echo Found Transaction Type of \[$3\]...
echo
if  [ "$3" = "DC" ]
then
  echo running u132_dc
  qtp  auto=$obj/u132_dc.qtc
else
if  [ "$3" = "SP" ]
then
  echo running u132_sp
  qtp  auto=$obj/u132_sp.qtc
else
  echo FATAL ERROR - this path should never be executed!!!
fi
fi


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
