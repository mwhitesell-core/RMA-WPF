#-------------------------------------------------------------------------------
# File 'reload_subfile_to_foxtrot.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_subfile_to_foxtrot'
#-------------------------------------------------------------------------------

echo "reload_subfile_to_foxtrot"
echo ""
echo "Hit NEWLINE to continue ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $Env:root\foxtrot\subfile
Get-Location

## -------------------------------------

echo ""
echo ""
# CONVERSION ERROR (expected, #18): tape device is involved.
# cpio -idcuvB < /dev/rmt/0  
echo ""
echo ""

echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #26): tape device is involved.
# mt -f /dev/rmt/0 rewind
