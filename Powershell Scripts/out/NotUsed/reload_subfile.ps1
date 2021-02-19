#-------------------------------------------------------------------------------
# File 'reload_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_subfile'
#-------------------------------------------------------------------------------

echo "reload_subfile"
echo ""
$garbage = Read-Host

echo ""
echo "RELOAD NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $pb_data2
Get-Location
echo ""
Get-Date

# line belows give listing of what's on tape
#cpio -itvcB < /dev/rmt/1    > ma/reload_subfile.ls
# line belows actually reloads the files to disk
#cpio -icvB "ma/claims_subfile*.sf*" < /dev/rmt/1 changed on jan1898
#cpio -icuvB "ma/claims_subfile*.*" < /dev/rmt/1

# changed july 16/2008 yas
# CONVERSION ERROR (expected, #22): tape device is involved.
# cpio -icuvB "/beta/rmabill/rmabill101c/data2/ma/claims_subfile*200807*" < /dev/rmt/1

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #28): tape device is involved.
# mt -f /dev/rmt/1 rewind
