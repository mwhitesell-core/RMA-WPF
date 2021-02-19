# 2014/Sep/30	MC	$cmd/backup_daily_disk
#			user will run this on the day of ohip cycle run
#			suggested to run at 4 pm in lieu of regular tape backup

echo "Start - backup files on disk.......  `date"


/alpha/rmabill/rmabill101c/cmd/backup_all_data_to_disk  > /backups/backup_all_data_to_disk.log

echo "Finish  - backup files on disk.......  `date"
