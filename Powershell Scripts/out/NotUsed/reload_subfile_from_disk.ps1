#-------------------------------------------------------------------------------
# File 'reload_subfile_from_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_subfile_from_disk'
#-------------------------------------------------------------------------------

## reload_subfile_from_disk

echo "reload_subfile_from_disk"

Get-Date

$application_root = "$Env:root\alpha\rmabill\rmabill101c"
Set-Location $pb_data2

# CONVERSION ERROR (expected, #11): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_subfile_to_disk.cpio | cpio -icdvB
Get-Date


echo "restore is done"
Get-Date
