echo  "backup 61 - 66 and 82 and 83 reports"

echo  
echo "Hit NEW-LINE to commence backup of monthend reports."
read garbage

echo 
echo  BACKUP NOW COMMENCING ...

date 
echo  

cd  $application_root
echo "Preparing list of file to be backed up ..."
pwd
/bin/ls                 	      \
production/60/r004*                   \
production/60/r005*                   \
production/60/r011*                   \
production/60/r012*                   \
production/60/r013*                   \
production/60/r051*                   \
production/60/r070*                   \
production/60/r210*                   \
production/60/r211*                   \
production/61/r004*                   \
production/61/r051*                   \
production/62/r004*                   \
production/62/r051*                   \
production/63/r004*                   \
production/63/r051*                   \
production/64/r004*                   \
production/64/r051*                   \
production/65/r004*                   \
production/65/r051*                   \
production/66/r004*                   \
production/66/r051*                   \
production/70/r004*                   \
production/70/r005*                   \
production/70/r011*                   \
production/70/r012*                   \
production/70/r013*                   \
production/70/r051*                   \
production/70/r070*                   \
production/70/r210*                   \
production/70/r211*                   \
production/71/r004*                   \
production/71/r051*                   \
production/72/r004*                   \
production/72/r051*                   \
production/73/r004*                   \
production/73/r051*                   \
production/74/r004*                   \
production/74/r051*                   \
production/75/r004*                   \
production/75/r051*                   \
production/82/r004*                   \
production/82/r005*                   \
production/82/r011*                   \
production/82/r012*                   \
production/82/r013*                   \
production/82/r051*                   \
production/82/r070*                   \
production/82/r210*                   \
production/82/r211*                   \
production/83/r004*                   \
production/83/r005*                   \
production/83/r011*                   \
production/83/r012*                   \
production/83/r013*                   \
production/83/r051*                   \
production/83/r070*                   \
production/83/r210*                   \
production/83/r211*                   \
production/86/r*                      \
> production/backup_82_83_60.ls  

echo
echo "Now begining backup to tape ..."
date
cat production/backup_82_83_60.ls |cpio -ocuvB > /dev/rmt/0
echo
date
echo Rewinding tape ...
mt -f /dev/rmt/0 rewind

echo 
echo VERIFICATION NOW COMMENCING ... Be patient - this may take some time!
echo
echo Output is being sent to a file that will be paged out at end of verify ...
echo 
echo  
cpio -itcvB < /dev/rmt/0 > production/backup_82_83_60.log
echo
echo
echo Comparing lines in .ls vs .log
ls -l production/backup_82_83_60.ls production/backup_82_83_60.log
echo
cat production/backup_82_83_60.ls  | wc -l
cat production/backup_82_83_60.log | wc -l

echo
#echo Press Enter to page out verification log
#read garbage
#pg production/backup_82_83_60.log

echo
date
echo "DONE!"
 
mt -f /dev/rmt/0 rewind

