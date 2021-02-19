#!/bin/ksh

echo "reload_sel_nightly_from_disk.com"

echo
date

application_root=/alpha/rmabill/rmabill101c
cd $application_root

#echo Restore ALL ACTUAL  files from part1
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part1.cpio | cpio -icdvB
#echo Restore files from part1 with content only
#uncompress -c < /charly/backup_transfer_area/backup_nightly_part1.cpio | cpio -itcvB > backup_nightly_part1_content.log
echo Restore files from part1 for selected files 
uncompress -c < /charly/backup_transfer_area/backup_nightly_part1.cpio | cpio -icdvB -E reload_nightly_part1 > backup_nightly_part1_select.log
date


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
date

