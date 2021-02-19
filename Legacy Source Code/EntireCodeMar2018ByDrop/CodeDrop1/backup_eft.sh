# CREATED oct/98 
cd $application_production
pwd

echo
echo "performing EFT backup to TAPE ..."
echo
pwd
echo
echo Press Enter to begin backup:
read garbage

echo Backup started ...

/bin/ls  eft*        >  backup_eft.ls

cat $application_production/backup_eft.ls |cpio -ocuvB > /dev/rmt/0 

echo Backup Done - rewinding tape ...
mt -f /dev/rmt/0 rewind

echo
echo VERIFICATION NOW COMMENCING ... Be patient - this may take some time!
echo
echo Output is being sent to a file that will be paged out at end of verify ...
echo
cpio -itcvB < /dev/rmt/0 >   backup_eft.log
echo
ls -l backup_eft.ls  backup_eft.log
echo
echo Comparing lines in .log vs .ls
cat backup_eft.log | wc -l
cat backup_eft.ls  | wc -l

echo
echo Press Enter to page out verification log
read garbage

pg                    backup_eft.log

echo
date
echo "DONE!"

mt -f /dev/rmt/0 rewind

