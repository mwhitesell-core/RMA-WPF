echo  "backup 80, 84 and 91 to 96 reports"
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
production/37/r004*                   \
production/37/r005*                   \
production/37/r011*                   \
production/37/r012*                   \
production/37/r013*                   \
production/37/r051*                   \
production/37/r070*                   \
production/68/r004*                   \
production/68/r005*                   \
production/68/r011*                   \
production/68/r012*                   \
production/68/r013*                   \
production/68/r051*                   \
production/68/r070*                   \
production/69/r004*                   \
production/69/r005*                   \
production/69/r011*                   \
production/69/r012*                   \
production/69/r013*                   \
production/69/r051*                   \
production/69/r070*                   \
production/78/r004*                   \
production/78/r005*                   \
production/78/r011*                   \
production/78/r012*                   \
production/78/r013*                   \
production/78/r051*                   \
production/78/r070*                   \
production/79/r004*                   \
production/79/r005*                   \
production/79/r011*                   \
production/79/r012*                   \
production/79/r013*                   \
production/79/r051*                   \
production/79/r070*                   \
production/80/r004*                   \
production/80/r005*                   \
production/80/r011*                   \
production/80/r012*                   \
production/80/r013*                   \
production/80/r051*                   \
production/80/r070*                   \
production/84/r004*                   \
production/84/r005*                   \
production/84/r011*                   \
production/84/r012*                   \
production/84/r013*                   \
production/84/r051*                   \
production/84/r070*                   \
production/87/r004*                   \
production/87/r005*                   \
production/87/r011*                   \
production/87/r012*                   \
production/87/r013*                   \
production/87/r051*                   \
production/87/r070*                   \
production/88/r004*                   \
production/88/r005*                   \
production/88/r011*                   \
production/88/r012*                   \
production/88/r013*                   \
production/88/r051*                   \
production/88/r070*                   \
production/89/r004*                   \
production/89/r005*                   \
production/89/r011*                   \
production/89/r012*                   \
production/89/r013*                   \
production/89/r051*                   \
production/89/r070*                   \
production/91/r004*                   \
production/91/r005*                   \
production/91/r011*                   \
production/91/r012*                   \
production/91/r013*                   \
production/91/r051*                   \
production/91/r070*                   \
production/92/r004*                   \
production/92/r005*                   \
production/92/r011*                   \
production/92/r012*                   \
production/92/r013*                   \
production/92/r051*                   \
production/92/r070*                   \
production/93/r004*                   \
production/93/r005*                   \
production/93/r011*                   \
production/93/r012*                   \
production/93/r013*                   \
production/93/r051*                   \
production/93/r070*                   \
production/94/r004*                   \
production/94/r005*                   \
production/94/r011*                   \
production/94/r012*                   \
production/94/r013*                   \
production/94/r051*                   \
production/94/r070*                   \
production/95/r004*                   \
production/95/r005*                   \
production/95/r011*                   \
production/95/r012*                   \
production/95/r013*                   \
production/95/r051*                   \
production/95/r070*                   \
production/96/r004*                   \
production/96/r005*                   \
production/96/r011*                   \
production/96/r012*                   \
production/96/r013*                   \
production/96/r051*                   \
production/96/r070*                   \
> production/backup_80_91to96.ls  

echo
echo "Now begining backup to tape ..."
date
cat production/backup_80_91to96.ls |cpio -ocuvB > /dev/rmt/0
echo
date
echo "DONE!"
 
mt -f /dev/rmt/0 rewind
