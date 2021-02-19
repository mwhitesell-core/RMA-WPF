# reload_earnings_daily 
# parameters: $1 contains the EP being run

# 1999/sep/16 B.E. - original
# 2000/nov/13 B.E. - changed reload to NOT use the -E option and instead
#		     reload EVERYTHING on the backup file

cd $pb_data

echo
echo "Uncompress backup files on disk ..."
uncompress backup_earnings_daily${1}.cpio
echo

date
echo "Reloading files ..."
cpio -iucvB  < backup_earnings_daily${1}.cpio
#cpio -iucvB -E  reload_earnings_daily.reload  < backup_earnings_daily${1}.cpio
echo
date
echo 

echo "Re-compress backup files ... "
compress backup_earnings_daily${1}.cpio
echo
date
echo

cd $pb_prod

echo "DONE !"
