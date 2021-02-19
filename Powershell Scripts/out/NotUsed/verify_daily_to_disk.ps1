#-------------------------------------------------------------------------------
# File 'verify_daily_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'verify_daily_to_disk'
#-------------------------------------------------------------------------------

echo "verify_daily_to_disk"
echo ""

Set-Location $env:application_root
Get-Location
echo "Starting VERIFY of the DISK backup ..."
echo ""
Get-Date
echo ""
echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
echo ""
Get-Date
echo "staring verify of DISK cpio file 1"
# CONVERSION ERROR (expected, #18): cpio.
# cpio -itcvB < /charly/backup_transfer_area/backup_daily_1.cpio > data/backup_daily_complete_1.log 
Get-Date
#echo staring verify of DISK cpio file 2
#cpio -itcvB < /charly/backup_transfer_area/backup_daily_2.cpio > data/backup_daily_complete_2.log 
echo ""
Get-Date
echo ""
echo ""
echo "Comparing lines in the 2 .ls vs .log"
echo ""
echo "comparing DISK CPIO file - 1"
Get-ChildItem data\backup_daily_complete_1.ls, data\backup_daily_complete_1.log
echo ""
Get-Content data\backup_daily_complete_1.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content data\backup_daily_complete_1.log | Measure-Object -Line | Select -ExpandProperty Lines

echo "comparing DISK CPIO file - 2"
Get-ChildItem data\backup_daily_complete_2.ls, data\backup_daily_complete_2.log
echo ""
Get-Content data\backup_daily_complete_2.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content data\backup_daily_complete_2.log | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
#echo Press Enter to page out verification log
#read garbage
#pg data/backup_daily_complete.log

echo ""
Get-Date
echo "DONE!"

#  ***** IF NEW BACKUP ADDED UPDATE backup_daily_to_disk  ALSO
#  *****                            reload_daily
#  *****                            reload_daily_from_disk
