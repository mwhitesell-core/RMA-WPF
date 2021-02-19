#!/bin/ksh
echo  "backup_charly_data.com"
# 2005/jul/18 b.e. added backup of obj and cmd in rmabill mp
# 2007/nov/01 M.C. modify accordingly
# 2007/nov/05 M.C. Yasemin requested to backup everything under production

echo 
echo  BACKUP NOW COMMENCING ...
echo 

echo
date 
echo  

application_root=/alpha/rmabill/rmabill101c
cd  $application_root
pb_data=/alpha/rmabill/rmabill101c/data


echo "Finding directories: charly/101c/data except current f010 ...."
find /charly/rmabill/rmabill101c/data                          	\
                \( ! -name 'f010_pat_mstr'       		\
                   ! -name 'f010_pat_mstr.idx'   		\
               \)                                          -print >  $pb_data/backup_charly_data.ls    

echo
date


echo "Starting copy of files to TAPE ..."
pwd

cat    $pb_data/backup_charly_data.ls    \
    | cpio -ocuvB > /dev/rmt/1

echo " "
date
echo "DONE!"

echo  
date 
echo  
