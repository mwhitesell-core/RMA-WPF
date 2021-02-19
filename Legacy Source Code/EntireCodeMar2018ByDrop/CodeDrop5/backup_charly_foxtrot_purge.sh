echo "backup_charly_foxtrot_purge"
echo  
echo "Hit NEWLINE to contine ..."
read garbage

echo 
echo  BACKUP NOW COMMENCING ...

date 
echo  
cd /charly/purge
pwd

find    /charly/purge/* \
       -prune !  -type d      -print >  /charly/purge/backup_charly_foxtrot_purge.ls
find    /charly/purge/backup/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find    /charly/purge/mp/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find    /charly/purge/solo/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find    /charly/purge/101c/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find   /charly/purge/costing/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find   /charly/purge/costing/noweb/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find    /foxtrot/purge/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find    /foxtrot/purge/mp/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find    /foxtrot/purge/solo/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
find    /foxtrot/purge/101c/* \
       -prune !  -type d      -print >> /charly/purge/backup_charly_foxtrot_purge.ls
echo
date
cat     /charly/purge/backup_charly_foxtrot_purge.ls | cpio -ocuvB > /dev/rmt/0
echo
date
echo Rewinding tape ...
mt -f /dev/rmt/0 rewind

echo
echo Performing Tape Verify ...
echo
cpio -itcvB < /dev/rmt/0 >  /charly/purge/backup_charly_foxtrot_purge.log
echo
date
echo
echo Comparing lines in .ls vs .log
ls -l /charly/purge/backup_charly_foxtrot_purge.ls /charly/purge/backup_charly_foxtrot_purge.log
echo
cat /charly/purge/backup_charly_foxtrot_purge.ls  | wc -l
cat /charly/purge/backup_charly_foxtrot_purge.log | wc -l

echo
echo ENSURE above record counts MATCH!
echo
date
echo
echo "DONE!"

cd /alpha/rmabill/rmabill101c/production
