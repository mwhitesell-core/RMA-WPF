# macro: u030
# 00/jul/13 B.E. added calls to u030bb.qtc and u030bb_1.qtc
# 00/aug/10 B.E. consolidated all u030bb_xxx into this one macro and force
#		 passing of 2 digit clinic nbr as parameter to this macro
#		 which is then passed to u030bb and u030bb_1
# 00/sep/14 B.E. allow clinic 90 as parameter
#		 if running clinic 90 pass clinic as 22 to u030
# 03/jun/11 yas  add clnics 91,92,93,94,96         
# 04/jul/13 M.C. change from u030b to run u030b_part1 and u030b_part2
#		 it was mysterious and do not know why the sort on the
#		 second request does not sort properly
# 07/may/16 M.C. add clnics 71 to 75  
# 2007/NOv  yas. add clnic 87           
# 2008/Oct  yas. add clnic 88
# 2009/Apr  yas. add clnic 89
# 2009/Jun  yas. add clnic 79
# 2009/Jun  yas. add clnic 78
# 2010/feb  yas  add clinic 66
# 2011/Jan  yas  add clinic 23
# 2012/Jan  yas  add clinic 24
# 2012/Jun  yas  add clinic 25
# 2013/Nov/07 MC include the run of $cmd/u030_clinic_dtl_part2 at the end
# 2014/Apr/04 yas add clinic 69                                            
# 2014/May/04 yas add clinic 68
# 2014/Oct/17 yas add clinic 30
# 2015/Mar/10 yas add clinic 26
# 2015/Jul/08 MC1 add the run of unlof002_rat_payment.qtc at the end of the macro for BI purpose
# 2015/Aug/06 MC2 transfer 'fi' on line 172 to the end of the macro, also remove the last MYSTERY line
#		  which might have caused the error from last night run


#  (clinic must be passed as single parameter)
if ( [ $1 != 22 ] && [ $1 != 23 ] && [ $1 != 24 ] && [ $1 != 25 ] && [ $1 != 26 ] && [ $1 != 30 ] &&
     [ $1 != 31 ] && [ $1 != 32 ] && [ $1 != 33 ] && [ $1 != 34 ] && [ $1 != 35 ] && [ $1 != 36 ] &&
     [ $1 != 37 ] && [ $1 != 41 ] && [ $1 != 42 ] && [ $1 != 43 ] && [ $1 != 44 ] &&
     [ $1 != 45 ] && [ $1 != 46 ] && [ $1 != 60 ] && [ $1 != 61 ] && [ $1 != 62 ] &&
     [ $1 != 63 ] && [ $1 != 64 ] && [ $1 != 65 ] && [ $1 != 66 ] && 
     [ $1 != 68 ] && [ $1 != 69 ] && [ $1 != 71 ] && [ $1 != 72 ] && [ $1 != 73 ] &&
     [ $1 != 74 ] && [ $1 != 75 ] && [ $1 != 78 ] && [ $1 != 79 ] &&
     [ $1 != 80 ] && [ $1 != 82 ] && [ $1 != 84 ] && [ $1 != 86 ] &&
     [ $1 != 87 ] && [ $1 != 88 ] && [ $1 != 89 ] && [ $1 != 90 ] &&
     [ $1 != 91 ] && [ $1 != 92 ] && [ $1 != 93 ] && [ $1 != 94 ] &&
     [ $1 != 95 ] && [ $1 != 96 ])
 then
  echo "*ERROR*  -  Usage: u030 <2 digit clinic nbr>"
else

if ( [ $1 = 22 ] )
then
   cd $application_production
else
   cd $application_production/$1
fi

echo Current Directory:
pwd

echo 
echo   append rmb file to the end of 145 file before running u030b.qtc
echo 

#cd $application_production
#rm u030_tape_145_file_bkp.dat 1>/dev/null 2>&1
#cp     u030_tape_145_file.dat u030_tape_145_file_bkp.dat 
#cat 	u030_tape_145_file.dat 	\
#	u030_tape_rmb_file.dat 	> /usr/tmp/u030_tape_145_file.dat.tmp  
#mv /usr/tmp/u030_tape_145_file.dat.tmp  u030_tape_145_file.dat

#######cd $application_production
rm  1>/dev/null 2>&1     u030_tape_145_file_bkp.dat
cp                            u030_tape_145_file.dat u030_tape_145_file_bkp.dat
cat u030_tape_rmb_file.dat >> u030_tape_145_file.dat

echo 
echo 
echo   delete / recreate part_paid_hdr  part_paid_dtl and part_adj_batch files
echo 
echo 
rm part_paid_hdr.*
rm part_paid_dtl.*
rm part_adj_batch.*

qutil 1>/dev/null 2>&1 << QUTIL_EXIT
create file part-paid-hdr
create file part-paid-dtl
create file part-adj-batch
QUTIL_EXIT

echo 
echo  execute powerhouse program u030b.qtc  for claim reconciliation
echo 

echo "Running u030b.qtc ..."
#qtp auto=$obj/u030b.qtc
qtp auto=$obj/u030b_part1.qtc
qtp auto=$obj/u030b_part2.qtc
#qtp auto=$obj/u030b_special1.qtc
#qtp auto=$obj/u030b_special2.qtc

if ( [ $1 = 60 -o  $1 = 61 -o  $1 = 62 -o  $1 = 63 -o  $1 = 64 -o  $1 = 65 -o  $1 = 66 ] )
then
  echo "Running u030b_60.qtc ..."
  qtp auto=$obj/u030b_60.qtc
fi

if ( [ $1 = 71 -o  $1 = 72 -o  $1 = 73 -o  $1 = 74 -o  $1 = 75 ] )
then
  echo "Running u030b_60.qtc ..."
  qtp auto=$obj/u030b_60.qtc
fi

# clinic 90 must be run with 22 as parm
if ( [ $1 != 90 ] )
then
echo Running u030bb.qtc for clinic $1...
qtp auto=$obj/u030bb.qtc << QTP_EXIT
$1

QTP_EXIT
echo Running u030bb_1.qtc for clinic $1 ...
qtp auto=$obj/u030bb_1.qtc << QTP_EXIT2
$1

$1

QTP_EXIT2
else
echo Running u030bb.qtc for clinic $1...
qtp auto=$obj/u030bb.qtc << QTP_EXIT
22

QTP_EXIT
echo Running u030bb_1.qtc for clinic $1 ...
qtp auto=$obj/u030bb_1.qtc << QTP_EXIT2
22

22

QTP_EXIT2
fi


echo 
echo  write inverted claim detail key to the adjusting claim detail record
echo 
cobrun $obj/u030c
echo 

echo  Generate Unmatched Report ru030a.txt  Unadjusted/Partial Payment
echo  report ru030b.txt and Automatic Adjusted Partial Payment report
echo  ru030c.txt
echo 

echo "Running r030.qzu ..."
rm ru030[a-z0-9].txt 1>/dev/null 2>&1
quiz auto=$obj/r030.qzu

rm                            u030_tape_145_file.dat 1>/dev/null 2>&1
cp u030_tape_145_file_bkp.dat u030_tape_145_file.dat 

echo 
echo  run ra report r997.txt
echo 

rm r997.ls 1>/dev/null 2>&1
echo "Running run_ra_report ..."
$cmd/run_ra_report 1>r997.ls 2>&1

echo 
echo  end of the run for u030
echo 
date

#MC2  fi  - transfer to the end as Brad suggested

# 2013/Nov/07 - add the run of $cmd/u030_clinic_dtl_part2 HERE
echo 
echo  Start  the run for u030_clinic_dtl_part.qts
echo 

$cmd/u030_clinic_dtl_part2

echo 
echo  Finish the run for u030_clinic_dtl_part.qts
echo 
date

# MC1

qtp auto=$obj/unlof002_rat_payment.qtc

echo
echo End of unlof002_rat_payment run
echo
date

fi
