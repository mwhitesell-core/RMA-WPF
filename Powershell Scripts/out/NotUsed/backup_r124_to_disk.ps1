#-------------------------------------------------------------------------------
# File 'backup_r124_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_r124_to_disk'
#-------------------------------------------------------------------------------

echo "backup_r124_to_disk"
echo ""
Set-Location $pb_data2
Get-Location
echo ""
echo "HIT  `"NEWLINE`"  TO COMMENCE BACKUPS to DISK ..."
$garbage = Read-Host

echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."
Get-Date
echo ""

Get-ChildItem ma\r124* > ma\backup_r124.ls
Get-ChildItem ma\ma\r124* >> ma\backup_r124.ls
echo ""
Get-Date
#cat ma/backup_r124.ls |cpio -ocuvB > ma/backup_r124.cpio
# CONVERSION ERROR (expected, #20): piping to cpio.
# cat ma/backup_r124.ls |cpio -ocuvB > /charly/backup_transfer_area/backup_r124.cpio
echo ""
Get-Date

echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
#cpio -itcvB < ma/backup_r124.cpio                           >   ma/backup_r124.log
# CONVERSION ERROR (expected, #30): cpio.
# cpio -itcvB < /charly/backup_transfer_area/backup_r124.cpio >   ma/backup_r124.log
echo ""
Get-ChildItem ma\backup_r124.ls, ma\backup_r124.log
echo ""
echo "Comparing lines in .log vs .ls"
Get-Content ma\backup_r124.log | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content ma\backup_r124.ls | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
echo "Press Enter to page out verification log"
$garbage = Read-Host

Get-Content ma\backup_r124.log

echo ""
Get-Date
echo "DONE!"
