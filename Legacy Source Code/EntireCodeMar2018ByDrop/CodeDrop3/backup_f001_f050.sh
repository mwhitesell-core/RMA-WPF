# 09/oct/27 MC   - specific full pathname for f050/f050tp*history files because it has moved to /charly
# 15/Apr/20 MC1	 - correct to backup files once

echo "backup_f001_f050"


echo BACKUP OF:
echo '----------!  F001   - BATCH CONTROL FILE'
echo '----------!  F050   - DOC REVENUE MSTR'
echo '----------!  F051   - DOC CASH    MSTR'
echo '----------!  F050TP - DOC REVENUE MSTR'
echo '----------!  F051TP - DOC CASH    MSTR'
echo

echo
echo BACKUP NOW COMMENCING ...
echo
echo 
date
echo

cd $pb_data
pwd

/bin/ls f001_batch_control_file* \
        f050*_doc_revenue_mstr.*   \
        /charly/rmabill/rmabill101c/data/f050_doc_revenue_mstr_history*  \
        f051_doc_cash_mstr*      \
        f050*_doc_revenue_mstr   \
        /charly/rmabill/rmabill101c/data/f050tp_doc_revenue_mstr_history*  \
        f051tp_doc_cash_mstr*   > backup_f001_f050.ls

#cat $pb_data/bk_f001_f050.ls		\
#		| cpio -ocuvB 		\
#                | dd of=/dev/rmt/0
#cat $pb_data/bk_f001_f050.ls		\

cat $pb_data/backup_f001_f050.ls	\
		| cpio -ocuvB 		\
		> /dev/rmt/0 
echo
date
echo
echo Rewinding the tape ...
mt -f /dev/rmt/0 rewind

date
echo
echo VERIFICATION NOW COMMENCING ... Be patient - this may take some time!
echo
echo Output is being sent to a file that will be paged out at end of verify ...
echo
echo

cpio -itcvB < /dev/rmt/0 > backup_f001_f050.log 
mt -f /dev/rmt/0 rewind

date
echo
echo
echo Comparing lines in .ls vs .log
ls -l backup_f001_f050.ls backup_f001_f050.log
echo
cat backup_f001_f050.ls  | wc -l
cat backup_f001_f050.log | wc -l

#echo
#echo Press Enter to page out verification log
#read garbage
#pg $pb_data/backup_f001_f050.log

echo
date
echo "DONE!"
