#-------------------------------------------------------------------------------
# File 'reload_101c_data_from_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_101c_data_from_disk'
#-------------------------------------------------------------------------------


## reload_101c_data_from_disk

echo "reload_101c_data_from_disk"

Get-Date

Set-Location $env:application_root

## restore 101c data from disk except f002 & f010 files
# CONVERSION ERROR (expected, #12): compressing to cpio.
# uncompress -c  < /charly/backup_transfer_area/backup_101c_data.cpio | cpio -icdvB
## restore 101c f002 data 
# CONVERSION ERROR (expected, #14): compressing to cpio.
# uncompress -c  < /charly/backup_transfer_area/backup_101c_f002.cpio | cpio -icdvB
## restore 101c f010 data
# CONVERSION ERROR (expected, #16): compressing to cpio.
# uncompress -c  < /charly/backup_transfer_area/backup_101c_f010.cpio | cpio -icdvB

echo "restore is done"
Get-Date
