#!/bin/ksh
# 2014/Oct/01	MC1 include part4.cpio in the reload (ma folder)

echo "reload_nightly_from_disk.com"

echo
date

application_root=/alpha/rmabill/rmabill101c
cd $application_root

uncompress -c < /charly/backup_transfer_area/backup_nightly_part1.cpio | cpio -icdvB
uncompress -c < /charly/backup_transfer_area/backup_nightly_part2.cpio | cpio -icdvB
uncompress -c < /charly/backup_transfer_area/backup_nightly_part3.cpio | cpio -icdvB
#MC1
uncompress -c < /charly/backup_transfer_area/backup_nightly_part4.cpio | cpio -icdvB

echo "restore is done"
date

