#  PURGE f084_claims_inventory file
#
# 2016/Jul/11 	MC1	- correct to move f084 from charly to foxtrot

cd /charly/purge

rm purgef084.log 1>/dev/null  2>/dev/null

echo "Purge f084 -  STARTING - `date`" > purgef084.log    

qtp auto=$obj/purge_unlof084.qtc << QTP_EXIT 1>> purgef084.log 2>&1
20000101
20141231
QTP_EXIT

cd $pb_data

echo "Move F084 to /foxtrot/purge - `date`" >> purgef084.log

mv f084_claims_inventory.dat  /foxtrot/purge/f084_claims_inventory.dat
mv f084_claims_inventory.idx  /foxtrot/purge/f084_claims_inventory.idx 

echo "--- create file file F084 ---" >> purgef084.log
qutil << QUTIL_EXIT
create file f084-claims-inventory  
QUTIL_EXIT

cd /charly/purge

echo "Reload F084 from subfile    - `date`" >> purgef084.log

qtp auto=$obj/purge_relof084.qtc  1>>  purgef084.log  2>&1

echo "Purge f084 - ENDING - `date`" >> purgef084.log
