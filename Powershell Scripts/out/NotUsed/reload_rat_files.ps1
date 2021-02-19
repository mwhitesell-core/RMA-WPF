#-------------------------------------------------------------------------------
# File 'reload_rat_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_rat_files'
#-------------------------------------------------------------------------------

echo "reload_rat_files"
echo ""
echo "Hit NEW-LINE to commence reload of RAT files ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $env:application_root
Get-Location
echo "Reloading files contained in file 'reload_rat_files'"
echo "hit newline to continue ..."
$garbage = Read-Host

#####
##### update reload_rat_files in $application_root to select what to reload
#####

echo "Now begining reload to tape ..."
Get-Date
# CONVERSION ERROR (expected, #24): tape device is involved.
# cpio -icuvB -E reload_rat_files < /dev/rmt/0
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #29): tape device is involved.
# mt -f /dev/rmt/1 rewind
