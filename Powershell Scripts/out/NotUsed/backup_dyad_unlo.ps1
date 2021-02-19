#-------------------------------------------------------------------------------
# File 'backup_dyad_unlo.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_dyad_unlo'
#-------------------------------------------------------------------------------

echo "backup_dyad_unlo"
echo ""
echo "Hit NEW-LINE to commence backup "
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $Env:root\dyad
echo "Preparing list of file to be backed up ..."
Get-Location
Get-ChildItem unlo* > backup_dyad_unlo.ls

echo ""
echo "Now begining backup to tape ..."
Get-Date
# CONVERSION ERROR (expected, #21): tape device is involved.
# cat      backup_dyad_unlo.ls | cpio -ocuvB > /dev/rmt/1
echo ""

Get-Date
echo "Now verifying tape ..."
# CONVERSION ERROR (expected, #26): tape device is involved.
# cpio -itcvB < /dev/rmt/1 > backup_dyad_unlo.verify
echo "DONE!"

# CONVERSION ERROR (expected, #29): tape device is involved.
# mt -f /dev/rmt/1 rewind
