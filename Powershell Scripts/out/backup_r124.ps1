#-------------------------------------------------------------------------------
# File 'backup_r124.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_r124'
#-------------------------------------------------------------------------------

# Save the current working directory
Push-Location -Path .

echo "backup_r124"
echo ""
Set-Location $env:pb_data2
Get-Location
echo ""
echo "HIT  `"NEWLINE`"  TO COMMENCE BACKUPS ..."
$garbage = Read-Host

echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."
Get-Date
echo ""

Get-ChildItem ma\r124* | Select-Object FullName > ma\backup_r124.ls
Get-ChildItem ma\ma\r124* | Select-Object FullName  >> ma\backup_r124.ls
(Get-Content ma\backup_r124.ls | Select-Object -Skip 3) | Set-Content ma\backup_r124.ls
echo ""
Get-Date
# CONVERSION WARNING; tape is involved.
# cat ma/backup_r124.ls |cpio -ocuvB > /dev/rmt/0
&"C:\Program Files\7-Zip\7z.exe" a backup_r124.tar @ma/backup_r124.ls
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
&"C:\Program Files\7-Zip\7z.exe" l backup_r124.tar > ma/backup_r124.log
(Get-Content ma/backup_r124.log | Select-Object -Skip 17) | Set-Content ma/backup_r124.log
$test = Get-Content ma/backup_r124.log
$test = $test[0..($test.count-3)]
$test | ForEach { $_.Remove(0,53) } | Set-Content ma/backup_r124.log
echo ""
echo ""
Get-ChildItem ma\backup_r124.ls, ma\backup_r124.log
echo ""
echo "Comparing lines in .log vs .ls"
Get-Content ma\backup_r124.log | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content ma\backup_r124.ls| Measure-Object -Line | Select -ExpandProperty Lines

echo ""
echo "Press Enter to page out verification log"
$garbage = Read-Host

#pg                       ma/backup_r124.log

echo ""
Get-Date
echo "DONE!"

# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind

# Go back to the original directory before script was launched.
Pop-Location
