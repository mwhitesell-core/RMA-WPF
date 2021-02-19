#!/bin/ksh
# purpose: create macro to process all files thru the u021 processing
# 2006/aug/17 M.C. - include new report r021a.txt
# 2013/jan/08 MC1  - include report r021bb.txt r021bc.txt r021c.txt to the u021_logs subfolder
# 2014/Mar/06 BE1  - change the line for calling u021.awk to pass the fixed timestamp            


echo recreate the empty temporary scratch file tmp-serv-err-claim

qutil << eof_qutil
create file tmp-serv-err-claim
eof_qutil


rm 1>/dev/null 2>/dev/null u021_ph.log u021_cb.log
echo "#!/bin/ksh"						>  u021.tmp.com
echo "# this batch file auto-created by u021.com/u021.awk"	>> u021.tmp.com
echo " "                                                        >> u021.tmp.com

timeStamp=20`date +%y_%m_%d.%H:%M` ;export timeStamp

rm 1>/dev/null 2>/dev/null  u021a_edt_1ht_file.dat
rm 1>/dev/null 2>/dev/null  u021a_edt_rmb_file.dat
rm 1>/dev/null 2>/dev/null  r021*.txt

for fname in $*
do
  /macros/dy_time "Building macro for Error file .. $fname"
# BE1
#  awk -v timeStamp=20`date +%y_%m_%d.%H:%M` -f $cmd/u021.awk $fname < $fname 
#  awk -v $timeStamp -f $cmd/u021.awk $fname < $fname 
   awk -v timeStamp=$timeStamp -f $cmd/u021.awk $fname < $fname 
done

cat u021.tmp.com $cmd/u021_last > u021.tmp.com2
mv u021.tmp.com2 u021.tmp.com
chmod +x         u021.tmp.com

echo
echo "Now running u021.tmp.com - VERIFY results in:  u021.log."$timeStamp".done"
echo
#echo "hit enter to continue"
#read garbage

mkdir u021_logs/$timeStamp
./u021.tmp.com >  u021_cb.log

echo "backup of reports generated"
cp   r021a.txt    u021_logs/$timeStamp
cp   r021b.txt    u021_logs/$timeStamp
cp   r021ba.txt   u021_logs/$timeStamp
# MC1
cp   r021bb.txt   u021_logs/$timeStamp
cp   r021bc.txt   u021_logs/$timeStamp
cp   r021c.txt    u021_logs/$timeStamp
echo "print reports generated"
#lpc r021*.txt

# save run commands as backup
#mv u021.tmp.com u021_logs/u021.$timeStamp.done
#mv u021.log     u021_logs/u021.log.$timeStamp.done
mv u021.tmp.com u021_logs/$timeStamp/u021.done
cat u021_cb.log u021_ph.log > u021.log
mv u021.log     u021_logs/$timeStamp/u021.log.done
echo
echo Done!
