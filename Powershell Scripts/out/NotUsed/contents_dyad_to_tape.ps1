#-------------------------------------------------------------------------------
# File 'contents_dyad_to_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'contents_dyad_to_tape'
#-------------------------------------------------------------------------------

# backup was: cat data/backup_dyad_to_tape.ls  | cpio -ocuvB | compress -c | dd of=/dev/rmt/1

# CONVERSION ERROR (expected, #3): tape device is involved.
# dd if=/dev/rmt/1 | uncompress -c | cpio -itcvB 
