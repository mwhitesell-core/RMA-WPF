#-------------------------------------------------------------------------------
# File 'backup_r124.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_r124'
#-------------------------------------------------------------------------------

echo "backup_r124"
echo ""
Set-Location $pb_data2
Get-Location
echo ""
echo "HIT  `"NEWLINE`"  TO COMMENCE BACKUPS ..."
$garbage = Read-Host

echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."
Get-Date
echo ""

Get-ChildItem ma\r124*  > ma\backup_r124.ls
Get-ChildItem ma\ma\r124*  >> ma\backup_r124.ls
echo ""
Get-Date
# CONVERSION WARNING; tape is involved.
# cat ma/backup_r124.ls |cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date
echo "Backup done - rewinding tape"

# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
# CONVERSION WARNING; tape is involved.
# cpio -itcvB < /dev/rmt/0 >   ma/backup_r124.log
echo ""
Get-ChildItem ma\backup_r124.ls, ma\backup_r124.log
echo ""
echo "Comparing lines in .log vs .ls"
Get-Content ${param.outputValue} | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content ${param.outputValue} | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
echo "Press Enter to page out verification log"
$garbage = Read-Host

#pg                       ma/backup_r124.log

echo ""
Get-Date
echo "DONE!"

# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind
