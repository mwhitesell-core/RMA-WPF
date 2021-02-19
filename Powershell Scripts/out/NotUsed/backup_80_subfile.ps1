#-------------------------------------------------------------------------------
# File 'backup_80_subfile.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_80_subfile'
#-------------------------------------------------------------------------------

echo "backup_80_subfile"
echo ""
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $env:application_root
Get-Location
Get-ChildItem yasemin\claims_subfile_80*.sf* > yasemin\backup_80_subfile.ls
echo ""
Get-Date
# CONVERSION ERROR (expected, #17): piping to cpio.
# cat yasemin/backup_80_subfile.ls |cpio -ocuvB > /devrmt/1
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #22): tape device is involved.
# mt -f /dev/rmt/1 rewind