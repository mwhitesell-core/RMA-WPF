#-------------------------------------------------------------------------------
# File 'backup_disk_101c_data_to_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_disk_101c_data_to_tape'
#-------------------------------------------------------------------------------


# backup disk 101c data on tape

echo ""
Get-Date
echo ""

Set-Location $Env:root\charly\backup_transfer_area

Get-ChildItem -recurse backup_101c*cpio | Select -ExpandProperty FullName > backup_disk_101c_data_on_tape.ls

# CONVERSION ERROR (expected, #12): tape device is involved.
# cat backup_disk_101c_data_on_tape.ls            \                | cpio -ocuvB           \                | dd of=/dev/rmt/1
# CONVERSION ERROR (expected, #15): tape device is involved.
# mt -f /dev/rmt/1 rewind

echo ""
Get-Date
echo ""

# To restore all files from tape:
# dd if=/dev/rmt/1 | cpio -icuvB
# To restore some files from filelist
# dd if=/dev/rmt/1 | uncompress | cpio -icuvB -E <filename>
# To verify the tape
# dd if=/dev/rmt/1 | uncompress | cpio -icvt
