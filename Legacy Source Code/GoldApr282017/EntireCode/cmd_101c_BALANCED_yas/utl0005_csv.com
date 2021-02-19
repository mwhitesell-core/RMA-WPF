echo  Start "UTL0005_CSV.COM"  `date`
echo  

cd $application_root/production

echo  Starting  `date`	>  utl0005_csv.log
echo  
echo  'CREATE  DOCTOR AUDIT MONTHLY CLAIMS '  >> utl0005_csv.log
echo 

echo 
echo  'PROGRAM "utl0005_csv.qtc" NOW LOADING ...'  >> utl0005_csv.log
echo 

qtp auto=$obj/utl0005_csv.qtc  << E_O_F   >> utl0005_csv.log
${1} 
E_O_F

quiz auto=$obj/utl0005_csv.qzc >> utl0005_csv.log

echo Ending `date`  >> utl0005_csv.log

echo Finish `date`

