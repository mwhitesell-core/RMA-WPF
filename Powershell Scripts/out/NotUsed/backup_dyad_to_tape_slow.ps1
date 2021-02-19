#-------------------------------------------------------------------------------
# File 'backup_dyad_to_tape_slow.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_dyad_to_tape_slow'
#-------------------------------------------------------------------------------

# 2006/oct/11 b.e. removed data2/ma and icu from backups as per yas request
# 2007/nov/14 M.C. modify and correct accordingly based on Yasemin's agreement
#                  101c/data & mp/data are being backup once a week by $cmd/backupdata_101c_mp
# 2008/01/03  yas  comment out ma since we back it up monthly


echo "BACKUP_DYAD_TO_TAPE"
echo ""

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
echo ""
Get-Date
echo ""

# CONVERSION ERROR (expected, #18): tape device is involved.
# mt -f /dev/rmt/1 rewind

Set-Location $env:application_root
# remove flag that indicates job finished successfully
echo "Removing process flag"
Remove-Item backup_dyad_to_tape.flg *> $null

echo "Building list of files to backup to TAPE ..."
# backup non data files
Get-ChildItem $Env:root\beta\backup_transfer_area\backup_nightly_part2.cpio > $pb_data\backup_dyad_to_tape.ls
Get-ChildItem $Env:root\beta\backup_transfer_area\backup_nightly_part3.cpio >> $pb_data\backup_dyad_to_tape.ls
Get-ChildItem $Env:root\beta\backup_transfer_area\backup_nightly_part1.cpio >> $pb_data\backup_dyad_to_tape.ls


#find /alpha/rmabill/rmabill101c/data2/ma/*  -print >> $pb_data/backup_dyad_to_tape.ls
#find /alpha/rmabill/rmabillmp/data2/ma/*    -print >> $pb_data/backup_dyad_to_tape.ls 
echo ""
echo ""
Get-Date

Set-Location $env:application_root
Get-Location
echo "Starting cpio to tape device ..."
#cat /data/backup_dyad_to_tape.ls | cpio -ocuvB > /dev/rmt/1

# CONVERSION ERROR (expected, #46): tape device is involved.
# cat data/backup_dyad_to_tape.ls  | cpio -ocuvB | compress -c | dd of=/dev/rmt/1  
echo "Done writing to TAPE"
# set flag that indicates job finished successfully
utouch backup_dyad_to_tape.flg
echo " "

echo ""
Get-Date
echo ""

echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #57): tape device is involved.
# mt -f /dev/rmt/1 rewind
echo ""

Get-Date
echo "DONE!"
