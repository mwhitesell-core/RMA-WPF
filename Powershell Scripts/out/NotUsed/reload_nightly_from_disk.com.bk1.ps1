#-------------------------------------------------------------------------------
# File 'reload_nightly_from_disk.com.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_nightly_from_disk.com.bk1'
#-------------------------------------------------------------------------------


echo "reload_nightly_from_disk.com"

echo ""
Get-Date

$application_root = "$Env:root\alpha\rmabill\rmabill101c"
Set-Location $env:application_root

# CONVERSION ERROR (expected, #11): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_nightly_part1.cpio | cpio -icdvB
# CONVERSION ERROR (expected, #12): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_nightly_part2.cpio | cpio -icdvB
# CONVERSION ERROR (expected, #13): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_nightly_part3.cpio | cpio -icdvB

echo "restore is done"
Get-Date
