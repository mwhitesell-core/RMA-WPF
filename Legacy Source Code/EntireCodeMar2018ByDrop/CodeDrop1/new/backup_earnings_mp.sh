# EARNINGS_BACKUP.CLI
# parameters: $1 contains 'nv' if no verify is to be performed

# 2000/11/13  yas backup disk files *Z daily and monthend onto tape 
# 2008/06/18  brad 'nv' option

echo  "backup_earnings_MP"
echo
echo

if [ "$1" != "" ] && [ "$1" != "nv" ]
then
        echo
        echo  **ERROR**
        echo  You must run the backup with either no parameter or the "No Verify " parameter
        echo
        echo
        echo  Valid format:   backup_earning_mp [nv]
        exit
fi   

cd $pb_data
date
echo
echo "This macro will perform a TAPE backup ..."
echo
pwd
echo Press Enter to begin backup:
read garbage

echo Backup started ...
/bin/ls *.Z > backup_earnings_mp.ls
echo
date
echo
echo Performing TAPE backup ...
echo doing cpio .....................
cat backup_earnings_mp.ls  |cpio -ocuvB > /dev/rmt/0
echo
date

echo
echo mt -f /dev/rmt/0 rewind
echo
date

if [ "$1" != "nv" ]
then
echo
echo VERIFICATION NOW COMMENCING ... Be patient - this may take some time!
echo
echo Output is being sent to a file that will be paged out at end of verify ...
echo
cpio -itcvB < /dev/rmt/0 >   backup_earnings_mp.log
echo

ls -l backup_earnings_mp.ls  backup_earnings_mp.log
echo
echo Comparing lines in .ls vs .log
cat backup_earnings_mp.ls  | wc -l
cat backup_earnings_mp.log | wc -l

echo
mt -f /dev/rmt/0 rewind
echo

echo Press Enter to page out verification log
read garbage

pg                            backup_earnings_mp.log

echo
date

else
	echo NO VERIFICATION of tape was performed!
fi
echo
echo "DONE!"
 
