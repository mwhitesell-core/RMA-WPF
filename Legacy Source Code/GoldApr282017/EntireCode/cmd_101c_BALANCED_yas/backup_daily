clear
echo  "BACKUP_DAILY"
echo  
echo

if [ "$1" != "" ] && [ "$1" != "nv" ]
then
        echo 
        echo  **ERROR**
        echo  You must run the backup with either no parameter or the "No Verify" parameter
        echo 
        echo 
        echo  Valid format:   backup_daily [nv]
        exit
fi

echo "An audit of this backup will be found in backupdaily.ls"
echo

echo 
echo  BACKUP NOW COMMENCING - audit log in backupdaily.ls ...
echo 

date
echo
$cmd/backup_daily.com > backupdaily.ls $1
echo
date
echo "An audit of this backup will be found in backupdaily.ls"
echo
ls  backupdaily.ls
echo
echo DONE!
