echo  "backup_r124"
echo  
cd $pb_data2
pwd
echo
echo 'HIT  "NEWLINE"  TO COMMENCE BACKUPS ...'
read garbage

echo
echo 
echo  BACKUP NOW COMMENCING ...
date 
echo  

/bin/ls ma/r124*    >  ma/backup_r124.ls
/bin/ls ma/ma/r124* >> ma/backup_r124.ls
echo
date
cat ma/backup_r124.ls |cpio -ocuvB > /dev/rmt/0
echo
date
echo Backup done - rewinding tape
 
mt -f /dev/rmt/0 rewind

echo
echo VERIFICATION NOW COMMENCING ... Be patient - this may take some time!
echo
echo Output is being sent to a file that will be paged out at end of verify ...
echo
cpio -itcvB < /dev/rmt/0 >   ma/backup_r124.log
echo
ls -l ma/backup_r124.ls  ma/backup_r124.log
echo
echo Comparing lines in .log vs .ls
cat ma/backup_r124.log | wc -l
cat ma/backup_r124.ls  | wc -l

echo
echo Press Enter to page out verification log
read garbage

#pg                       ma/backup_r124.log

echo
date
echo "DONE!"

mt -f /dev/rmt/0 rewind
