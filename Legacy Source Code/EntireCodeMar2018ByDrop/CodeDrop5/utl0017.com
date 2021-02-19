# 2014/Jul/22   Change new fee for comp code 'RMACHR' & 'GSTTAX' in f113 file (98 screen)

cd $application_root/production

rm utl0017.log  1>/dev/null 2>&1

echo "utl0017.com  -  STARTING - `date`" > utl0017.log    

qtp  auto=$obj/utl0017.qtc  >> utl0017.log

echo "utl0017.com - ENDING - `date`" >> utl0017.log
