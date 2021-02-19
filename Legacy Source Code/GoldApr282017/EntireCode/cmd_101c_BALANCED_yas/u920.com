cd /charly/purge

rm u920.log

echo "U920.com  -  STARTING - `date`" > u920.log    

qtp auto=$obj/u920.qtc >> u920.log 2>&1

echo "u920 - ENDING - `date`" >> u920.log
