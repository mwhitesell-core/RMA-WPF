#-------------------------------------------------------------------------------
# File 'backup_dyad_to_tape1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_dyad_to_tape1'
#-------------------------------------------------------------------------------

# 2006/oct/11 b.e. removed data2/ma and icu from backups as per yas request
# 2007/nov/14 M.C. modify and correct accordingly based on Yasemin's agreement
#                  101c/data & mp/data are being backup once a week by $cmd/backupdata_101c_mp
# 2007/dec/19 M.C. this macros only backup the part1 to 3 cpio files with compress, backup data2 for
#                  101c and mp will be done on $cmd/backup_dyad_to_tape2
#                  As Brad suggested to use tar -cv0 -I instead of cpio compress

echo "BACKUP_DYAD_TO_TAPE1"
echo ""

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #19): tape device is involved.
# mt -f /dev/rmt/1 rewind

Set-Location $env:application_root
# remove flag that indicates job finished successfully
echo "Removing process flag"
Remove-Item backup_dyad_to_tape1.flg *> $null

echo "Building list of files to backup to TAPE ..."
# backup non data files
Get-ChildItem $Env:root\beta\backup_transfer_area\backup_nightly_part1.cpio > $pb_data\backup_dyad_to_tape1.ls
Get-ChildItem $Env:root\beta\backup_transfer_area\backup_nightly_part2.cpio >> $pb_data\backup_dyad_to_tape1.ls
Get-ChildItem $Env:root\beta\backup_transfer_area\backup_nightly_part3.cpio >> $pb_data\backup_dyad_to_tape1.ls


echo ""
echo ""
Get-Date

Set-Location $env:application_root
Get-Location
echo "Starting cpio to tape device ..."

##cat data/backup_dyad_to_tape1.ls  | cpio -ocuvB | compress -c | dd of=/dev/rmt/1  

# CONVERSION ERROR (expected, #46): tar.
# tar -cv0 -I data/backup_dyad_to_tape1.ls

echo "Done writing to TAPE"
# set flag that indicates job finished successfully
utouch backup_dyad_to_tape1.flg
echo " "

echo ""
Get-Date
echo ""

# verify the files beings backup from tape
echo "Verify the files from tape"

# CONVERSION ERROR (expected, #60): tar.
# tar -tv0

echo "finish verifcation of files"
Get-Date
echo ""

echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #67): tape device is involved.
# mt -f /dev/rmt/1 rewind
echo ""

Get-Date
echo "DONE!"
