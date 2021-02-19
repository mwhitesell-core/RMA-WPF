echo  "backup portal monthend reports"       
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
/bin/ls                            \
production/*portal*                \
production/23/*portal*             \
production/24/*portal*             \
production/25/*portal*             \
production/26/*portal*             \
production/30/*portal*             \
production/31/*portal*             \
production/32/*portal*             \
production/33/*portal*             \
production/34/*portal*             \
production/35/*portal*             \
production/36/*portal*             \
production/37/*portal*             \
production/41/*portal*             \
production/42/*portal*             \
production/43/*portal*             \
production/44/*portal*             \
production/45/*portal*             \
production/46/*portal*             \
production/47/*portal*             \
production/48/*portal*             \
production/60/*portal*             \
production/61/*portal*             \
production/62/*portal*             \
production/63/*portal*             \
production/64/*portal*             \
production/65/*portal*             \
production/66/*portal*             \
production/68/*portal*             \
production/69/*portal*             \
production/70/*portal*             \
production/71/*portal*             \
production/72/*portal*             \
production/73/*portal*             \
production/74/*portal*             \
production/75/*portal*             \
production/78/*portal*             \
production/79/*portal*             \
production/80/*portal*             \
production/82/*portal*             \
production/83/*portal*             \
production/84/*portal*             \
production/86/*portal*             \
production/87/*portal*             \
production/88/*portal*             \
production/89/*portal*             \
production/91/*portal*             \
production/92/*portal*             \
production/93/*portal*             \
production/94/*portal*             \
production/95/*portal*             \
production/96/*portal*             \
production/98/*portal*             \
> production/backup_portal.ls

echo
echo "Now begining backup to tape ..."
date
cat production/backup_portal.ls  |cpio -ocuvB > /dev/rmt/0
echo
date
echo "DONE!"
 
mt -f /dev/rmt/0 rewind
