#-------------------------------------------------------------------------------
# File 'reload_sel_nightly_from_disk.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_sel_nightly_from_disk.com'
#-------------------------------------------------------------------------------


echo "reload_sel_nightly_from_disk.com"

echo ""
Get-Date

$application_root = "$Env:root\alpha\rmabill\rmabill101c"
Set-Location $env:application_root

#echo Restore ALL ACTUAL  files from part1
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part1.cpio | cpio -icdvB
#echo Restore files from part1 with content only
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part1.cpio | cpio -itcvB > backup_nightly_part1_content.log
echo "Restore files from part1 for selected files"
# CONVERSION ERROR (expected, #16): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_nightly_part1.cpio | cpio -icdvB -E reload_nightly_part1 > backup_nightly_part1_select.log
Get-Date


#echo Restore ALL ACTUAL  files from part2
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part2.cpio | cpio -icdvB
#echo Restore files from part2 with content only
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part2.cpio | cpio -itcvB > backup_nightly_part2_content.log
#echo Restore files from part2 for selected files 
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part2.cpio | cpio -icdvB -E reload_nightly_part2 > backup_nightly_part2_select.log
#date


#echo Restore ALL ACTUAL  files from part3
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part3.cpio | cpio -icdvB
#echo Restore files from part3 with content only
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part3.cpio | cpio -itcvB > backup_nightly_part3_content.log
#echo Restore files from part3 for selected files 
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part3.cpio | cpio -icdvB -E reload_nightly_part3 > backup_nightly_part3_select.log
#date

echo "Restore is done"
Get-Date
