# 2014/Jul/17   Terminated Doctors List

cd $application_root/production

rm utl0016.log  1>/dev/null 2>&1

echo "utl0016.com  -  STARTING - `date`" > utl0016.log    

quiz auto=$src/utl0016.qzs  >> utl0016.log

echo "utl0016.com - ENDING - `date`" >> utl0016.log
