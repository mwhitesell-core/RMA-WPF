#-------------------------------------------------------------------------------
# File 'reload_mp_solo_data_from_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_mp_solo_data_from_disk'
#-------------------------------------------------------------------------------

## reload_all_data_from_disk

echo "reload_all_data_from_disk"

Get-Date

$application_root = "$Env:root\alpha\rmabill\rmabill101c"
Set-Location $env:application_root


## restore mp   data from disk
# CONVERSION ERROR (expected, #13): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_mp_data.cpio | cpio -icdvB
Get-Date

## restore solo data from disk
# CONVERSION ERROR (expected, #17): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_solo_data.cpio | cpio -icdvB
Get-Date


echo "restore is done"
Get-Date
