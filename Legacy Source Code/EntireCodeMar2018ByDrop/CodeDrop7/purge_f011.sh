#  PURGE f011 file
#  2013/Jan/07  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2013/Apr/08  MC2  - change the log file location from $pb_prod to current directory /charly/purge
#

#cd $pb_prod
cd /charly/purge


#rm $pb_prod/purgef011.log 1>/dev/null  2>/dev/null
rm purgef011.log 1>/dev/null  2>/dev/null

echo "Purge f011 -  STARTING - `date`"  >  purgef011.log    

qtp auto=$obj/purge_unlof011.qtc      1>>  purgef011.log 2>&1

cd $pb_data


mv  f011_pat_mstr_elig_history.idx  /foxtrot/purge/f011_pat_mstr_elig_history.idx
mv  f011_pat_mstr_elig_history      /foxtrot/purge/f011_pat_mstr_elig_history


echo "--- create files ---"
qutil << QUTIL_EXIT
create file f011-pat-mstr-elig-history
QUTIL_EXIT

cd /charly/purge

qtp auto=$obj/purge_relof011.qtc  1>>  purgef011.log  2>&1


echo "Purge f011 - ENDING - `date`" >> purgef011.log
