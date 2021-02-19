#-------------------------------------------------------------------------------
# File 'backup_mp_solo_data_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_mp_solo_data_to_disk'
#-------------------------------------------------------------------------------

# 2008/12/03            MC - backup MP & Solo data 
# 2009/01/28            MC - backupto cpio with compress

echo "backup_mp_solo_data_to_disk"
echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""

echo "Finding files in 'mp' data without sub-directories ..."
Get-ChildItem -File $Env:root\alpha\rmabill\rmabillmp\data\* | Select -ExpandProperty FullName `
  > $pb_data\backup_mp_data.ls

echo ""
Get-Date

echo "Finding files in 'solo' data without sub-directories ..."
Get-ChildItem -File $Env:root\alpha\rmabill\rmabillsolo\data\* | Select -ExpandProperty FullName `
  > $pb_data\backup_solo_data.ls

echo ""
Get-Date

echo "backup to disk commencing ..."

# CONVERSION ERROR (expected, #28): compressing to cpio.
# cat $pb_data/backup_mp_data.ls   |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_mp_data.cpio
# CONVERSION ERROR (expected, #29): compressing to cpio.
# cat $pb_data/backup_solo_data.ls |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_solo_data.cpio
echo ""
Get-Date

echo ""
Get-Date
echo "DONE!"
