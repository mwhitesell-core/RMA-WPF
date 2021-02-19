#-------------------------------------------------------------------------------
# File 'backupdata_101c_mp_solo.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backupdata_101c_mp_solo'
#-------------------------------------------------------------------------------

# 2014/08/14            MC1 - backup data for 101c, mp & solo cpio files that were created from the daily disk backup onto tape 
# 2014/09/29            MC2 - exclude the backup of f002 & f010 as Yasemin suggested because it cannot fit everything onto a tape

echo "backupdata_101c_mp_solo"
echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

Set-Location $Env:root\foxtrot\backup_transfer_area
Get-Location

#MC2
#find backup_101c_data.cpio                        \
#     backup_101c_f002.cpio                        \
#     backup_101c_f010.cpio                        \
#     backup_mp*cpio                               \
#     backup_solo*cpio                             \

Get-ChildItem -recurse backup_101c_data.cpio, backup_mp*cpio, backup_solo*cpio | Select -ExpandProperty FullName `
  > $pb_data\backup_101c_mp_solo_data.ls


echo "backup to tape commencing ..."

# CONVERSION ERROR (expected, #30): tape device is involved.
# cat $pb_data/backup_101c_mp_solo_data.ls |cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date

echo "Backup to tape done ... rewinding tape..."

# CONVERSION ERROR (expected, #36): tape device is involved.
# mt -f /dev/rmt/0 rewind

Get-Date
echo ""

echo ""
Get-Date
echo "DONE!"
