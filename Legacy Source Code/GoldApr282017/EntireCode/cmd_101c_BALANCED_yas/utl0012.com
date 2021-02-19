##  2016/Nov/28	MC	- change to run 2 passes

cd /charly/purge

rm utl0012.log

echo "utl0012.com  -  STARTING - `date`" > utl0012.log    

quiz auto=$obj/utl0012_a.qzc  >> utl0012.log
quiz auto=$obj/utl0012_b.qzc  >> utl0012.log

echo "utl0012 - ENDING - `date`" >> utl0012.log
