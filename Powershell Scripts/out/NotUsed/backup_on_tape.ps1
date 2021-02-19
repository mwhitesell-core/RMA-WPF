#-------------------------------------------------------------------------------
# File 'backup_on_tape.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_on_tape'
#-------------------------------------------------------------------------------

# backup data 

echo ""
Get-Date
echo ""

Set-Location $pb_data
Get-ChildItem -recurse .\* | Select -ExpandProperty FullName > $pb_data\backup_on_tape.ls

# CONVERSION ERROR (expected, #10): tape device is involved.
# cat $pb_data/backup_on_tape.ls          \                | cpio -ocuvB           \                | dd of=/dev/rmt/1
# CONVERSION ERROR (expected, #13): tape device is involved.
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
