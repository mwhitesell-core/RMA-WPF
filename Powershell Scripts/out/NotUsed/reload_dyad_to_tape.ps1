#-------------------------------------------------------------------------------
# File 'reload_dyad_to_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_dyad_to_tape'
#-------------------------------------------------------------------------------

# backup was: cat data/backup_dyad_to_tape.ls  | cpio -ocuvB | compress -c | dd of=/dev/rmt/1

# dd if=/dev/rmt/1 | uncompress -c | cpio -icvB -E reload_dyad_to_tape.ls
##--------------------------------------------------------------------------

# 2009/feb/03   MC      - backup format has changed from $cmd/backup_dyad_to_tape to exclude compress
#                         correct the restore statement accordingly

## backup was: cat data/backup_dyad_to_tape.ls  | cpio -ocuvB  | dd of=/dev/rmt/1
#  dd if=/dev/rmt/1 | uncompress -c | cpio -icvB 
# CONVERSION ERROR (expected, #11): tape device is involved.
# dd if=/dev/rmt/1 |  cpio -icvB 


## /macros/backup_nightly_to_dyad_with_part1to3.com has changed to create cpio with compress

## backup was : cat data/nightly_to_dyad_part1.ls  | cpio -ocuvB | compress -c  > /dyad/backup_transfer_area/backup_nightly_part1.cpio
# cpio -icdvB < /beta/backup_transfer_area/backup_nightly_part1.cpio
# cpio -icdvB < /beta/backup_transfer_area/backup_nightly_part2.cpio
# cpio -icdvB < /beta/backup_transfer_area/backup_nightly_part3.cpio

# CONVERSION ERROR (expected, #21): compressing to cpio.
# uncompress -c | cpio -icdvB < /beta/backup_transfer_area/backup_nightly_part1.cpio
# CONVERSION ERROR (expected, #22): compressing to cpio.
# uncompress -c | cpio -icdvB < /beta/backup_transfer_area/backup_nightly_part2.cpio
# CONVERSION ERROR (expected, #23): compressing to cpio.
# uncompress -c | cpio -icdvB < /beta/backup_transfer_area/backup_nightly_part3.cpio
