#-------------------------------------------------------------------------------
# File 'backup_dyad_to_tape2_new.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_dyad_to_tape2_new'
#-------------------------------------------------------------------------------

# 2006/oct/11 b.e. removed data2/ma and icu from backups as per yas request
# 2007/nov/14 M.C. modify and correct accordingly based on Yasemin's agreement
#                  101c/data & mp/data are being backup once a week by $cmd/backupdata_101c_mp
# 2007/dec/19 M.C. this macro only backup data2 for 101c and mp, backing up of 3 cpio files
#                  with compress is done in $cmd/backup_dyad_to_tape1
# 2013/jul/22 MC1  change from /dev/rmt/1 to /dev/rmt/0

echo "BACKUP_DYAD_TO_TAPE2"
echo ""

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
echo ""
Get-Date
echo ""

#mt -f /dev/rmt/1 rewind
# CONVERSION ERROR (expected, #20): tape device is involved.
# mt -f /dev/rmt/0 rewind

Set-Location $env:application_root
# remove flag that indicates job finished successfully
echo "Removing process flag"
Remove-Item backup_dyad_to_tape2.flg *> $null

echo "Building list of files to backup to TAPE ..."
# backup 101c & mp data2 files


Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101c\data2\ma\* | Select -ExpandProperty FullName `
  > $pb_data\backup_dyad_to_tape2.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data2\ma\* | Select -ExpandProperty FullName `
  >> $pb_data\backup_dyad_to_tape2.ls
echo ""
echo ""
Get-Date

Set-Location $env:application_root
Get-Location
echo "Starting cpio to tape device ..."
#cat $pb_data/backup_dyad_to_tape2.ls | cpio -ocuvB > /dev/rmt/1
# CONVERSION ERROR (expected, #41): tape device is involved.
# cat $pb_data/backup_dyad_to_tape2.ls | cpio -ocuvB > /dev/rmt/0

echo "Done writing to TAPE"
# set flag that indicates job finished successfully
utouch backup_dyad_to_tape2.flg
echo " "

echo ""
Get-Date
echo ""

echo "Rewinding tape ..."
#mt -f /dev/rmt/1 rewind
# CONVERSION ERROR (expected, #54): tape device is involved.
# mt -f /dev/rmt/0 rewind
echo ""

Get-Date
echo "DONE!"
