#-------------------------------------------------------------------------------
# File 'backup_john.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_john'
#-------------------------------------------------------------------------------

echo "backup_john"
echo ""
echo "HIT  `"NEWLINE`"  TO COMMENCE BACKUPS ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $pb_data2
Get-Location

Get-ChildItem ma\john*.sf* > ma\backup_john.ls
echo ""
Get-Date
# CONVERSION ERROR (expected, #18): tape device is involved.
# cat ma/backup_john.ls |cpio -ocuvB > /dev/rmt/1
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #23): tape device is involved.
# mt -f /dev/rmt/1 rewind
