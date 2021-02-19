# file:  $cmd/run_rats     
# 2013/Sep/09  MC - original - call run_rats.com and capture all line details in log file
# 2013/Nov/07  MC - Yasemin requested to add Newline 3 times
# 2015/Oct/01  MC1 - Yasemen requested to run in batch for $cmd/run_rats.com

echo   'HIT   "NEWLINE"  1st time  TO CONTINUE ...'
 read garbage

echo   'HIT   "NEWLINE"  2nd time  TO CONTINUE ...'
 read garbage

echo   'HIT   "NEWLINE"  3rd time  TO CONTINUE ...'
 read garbage

cd $application_production
rm run_rats.log 1>/dev/null 2>&1

echo
echo
echo Process now run rats for all clinics - the log file run_rats.log  

# MC1

batch   << BATCH_EXIT

echo "Run Rats for all clinics - starting - `date`" > run_rats.log

$cmd/run_rats.com  1>>run_rats.log     2>&1

echo "Run Rats for all clinics - ending   - `date`" >> run_rats.log

BATCH_EXIT
