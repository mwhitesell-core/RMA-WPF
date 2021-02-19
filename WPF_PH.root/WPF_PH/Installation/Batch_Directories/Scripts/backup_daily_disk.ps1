#-------------------------------------------------------------------------------
# File 'backup_daily_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_daily_disk'
#-------------------------------------------------------------------------------

# 2014/Sep/30   MC      $cmd/backup_daily_disk
#                       user will run this on the day of ohip cycle run
#                       suggested to run at 4 pm in lieu of regular tape backup

echo "Start - backup files on disk.......  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"


# CONVERSION ERROR (unexpected, #8): Unknown command.
# /alpha/rmabill/rmabill101c/cmd/backup_all_data_to_disk  > /backups/backup_all_data_to_disk.log
&$env:cmd/backup_all_data_to_disk > \\$env:root/alpha/backups/backup_all_data_to_disk.log

echo "Finish  - backup files on disk.......  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
