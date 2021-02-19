#-------------------------------------------------------------------------------
# File 'reload_john.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_john'
#-------------------------------------------------------------------------------

echo "reload_subfile"
echo ""
$garbage = Read-Host

echo ""
echo "reload NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $pb_data2
Get-Location
echo ""
Get-Date

# line belows give listing of what's on tape
#cpio -itvcB < /dev/rmt/1    > ma/reload_john.ls
# line belows actually reloads the files to disk
# CONVERSION ERROR (expected, #18): tape device is involved.
# cpio -icvB "ma/john*" < /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #24): tape device is involved.
# mt -f /dev/rmt/1 rewind
