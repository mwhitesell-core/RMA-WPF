#-------------------------------------------------------------------------------
# File 'verify_daily.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'verify_daily'
#-------------------------------------------------------------------------------

echo "verify_daily"
echo ""

Set-Location $env:application_root
Get-Location
echo "Starting VERIFY of the tape ..."
echo ""
Get-Date
echo ""
echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
echo ""
# CONVERSION ERROR (expected, #16): tape device is involved.
# cpio -itcvB < /dev/rmt/0 > data/backup_daily_complete.log 
# CONVERSION ERROR (expected, #17): tape device is involved.
# mt -f /dev/rmt/0 rewind
&"C:\Program Files\7-Zip\7z.exe" l $env:pb_data/backup_daily_complete.tar > $env:pb_data\backup_daily_complete.log
(Get-Content $env:pb_data\backup_daily_complete.log | Select-Object -Skip 17) | Set-Content $env:pb_data\backup_daily_complete.log
$test = Get-Content $env:pb_data\backup_daily_complete.log
$test = $test[0..($test.count-3)]
$test | ForEach { $_.Remove(0,53) } | Set-Content $env:pb_data\backup_daily_complete.log
echo ""
Get-Date
echo ""
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem data\backup_daily_complete.ls, data\backup_daily_complete.log
echo ""
Get-Content data\backup_daily_complete.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content data\backup_daily_complete.log | Measure-Object -Line | Select -ExpandProperty Lines

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
