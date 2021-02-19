#-------------------------------------------------------------------------------
# File 'reload_rat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_rat'
#-------------------------------------------------------------------------------

echo "reload_rat_"
echo ""
echo "BACKUP NOW COMMENCING ..."
Get-Date
echo ""

Get-Location
Set-Location $pb_data

echo "Reloading files contained in file 'reload_rat'"
echo "hit newline to continue ..."
$garbage = Read-Host

echo "Now begining reload to tape ..."
Get-Date
# CONVERSION ERROR (expected, #16): tape device is involved.
# cpio -icuvB -E reload_rat < /dev/rmt/1
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #21): tape device is involved.
# mt -f /dev/rmt/1 rewind
