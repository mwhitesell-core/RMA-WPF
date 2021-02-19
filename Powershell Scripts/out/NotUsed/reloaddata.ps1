#-------------------------------------------------------------------------------
# File 'reloaddata.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reloaddata'
#-------------------------------------------------------------------------------

echo "reload_data"
echo ""
$garbage = Read-Host

echo ""
echo "reload  NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $pb_data
Get-Location
echo ""
Get-Date

# line belows give listing of what's on tape
#cpio -itvcB < /dev/rmt/1    > data/backupdata.ls

# line belows actually reloads the files to disk
# CONVERSION ERROR (expected, #19): tape device is involved.
# cpio -icvB "data/*" < /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #25): tape device is involved.
# mt -f /dev/rmt/1 rewind
