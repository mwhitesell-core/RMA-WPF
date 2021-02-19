#-------------------------------------------------------------------------------
# File 'backupdata_101c_mp_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backupdata_101c_mp_to_disk'
#-------------------------------------------------------------------------------

# 2008/10/07            yas - added solo data to be ba
# 2009/01/28            MC  - backup to cpio with compress

echo "backupdata"
echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
echo "Finding directories with sub directories and files..."

Set-Location $Env:root\
Get-Location

echo "Finding files in '101c' data without sub-directories and f002 and f010 ..."
Get-ChildItem -recurse -File -Exclude "f010_pat_mstr", "f010_pat_mstr.dat", "f010_pat_mstr.idx", "f002_claims_mstr", `
  "f002_claims_mstr.dat", "f002_claims_mstr.idx" $Env:root\alpha\rmabill\rmabill101c\data\* | Select -ExpandProperty `
  FullName > $pb_data\backup_101c_mp_data.ls


echo "Finding files in 'mp' data without sub-directories ..."
Get-ChildItem -File $Env:root\alpha\rmabill\rmabillmp\data\* | Select -ExpandProperty FullName `
  >> $pb_data\backup_101c_mp_data.ls

echo ""
Get-Date

echo "Finding files in 'solo' data without sub-directories ..."
Get-ChildItem -File $Env:root\alpha\rmabill\rmabillsolo\data\* | Select -ExpandProperty FullName `
  >> $pb_data\backup_101c_mp_data.ls

echo ""
Get-Date

echo "backup to tape commencing ..."

# CONVERSION ERROR (expected, #44): compressing to cpio.
# cat $pb_data/backup_101c_mp_data.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_mp_data.cpio
echo ""
Get-Date

Get-Date
echo ""
echo "VERIFICATION NOW COMMENCING ... Be patient - this may take some time!"
echo ""
echo "Output is being sent to a file that will be paged out at end of verify ..."
echo ""
echo ""
Get-Date
echo ""
# CONVERSION ERROR (expected, #57): compressing to cpio.
# cpio -itcvB | uncompress -c  < /charly/backup_transfer_area/backup_101c_mp_data.cpio > $pb_data/backup_101c_mp_data.log

echo ""
Get-ChildItem $pb_data\backup_101c_mp_data.ls, $pb_data\backup_101c_mp_data.log
Get-Content $pb_data\backup_101c_mp_data.ls | Measure-Object -line -word -character
Get-Content $pb_data\backup_101c_mp_data.log | Measure-Object -line -word -character
echo ""
Get-Date
echo ""
#echo Press Enter to page out verification log
#read garbage
#pg backup_101c_mp_data.log

echo ""
Get-Date
echo "DONE!"
