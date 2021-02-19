echo "reload_data" 
echo  
read garbage

echo 
echo  BACKUP NOW COMMENCING ...

date 
echo  
cd $pb_data
pwd
echo
date

# line belows give listing of what's on tape
#cpio -itvcB < /dev/rmt/1    > data/backupdata.ls

# line belows actually reloads the files to disk
cpio -icvB "data/backupdata.ls" < /dev/rmt/1

echo
date
echo "DONE!"
 
mt -f /dev/rmt/1 rewind
