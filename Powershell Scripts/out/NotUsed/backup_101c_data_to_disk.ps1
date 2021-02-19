#-------------------------------------------------------------------------------
# File 'backup_101c_data_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_101c_data_to_disk'
#-------------------------------------------------------------------------------

# 2008/12//03           MC - backup 101c data to disk      
# 2009/01/28            MC - backup to cpio with compress
# 2009/10/27            MC - include specific full pathname fof f050/f050tp history files, has moved to /charly

echo "backup_101c_data_to_disk"
echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
echo "Finding directories with sub directories and files..."

Set-Location $Env:root\


echo "Finding files in '101c' data without sub-directories and f002 and f010 ..."
Get-ChildItem -recurse -File -Exclude "f010_pat_mstr", "f010_pat_mstr.dat", "f010_pat_mstr.idx", "f002_claims_mstr", `
  "f002_claims_mstr.dat", "f002_claims_mstr.idx" $Env:root\alpha\rmabill\rmabill101c\data\* | Select -ExpandProperty `
  FullName > $pb_data\backup_101c_data.ls

echo "Finding files in '101c' data for f050 history files.."
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f050*doc_revenue_*history* >> $pb_data\backup_101c_data.ls


echo "Finding files in '101c' data for f002 files only  ..."
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f002_claims_mstr.idx > $pb_data\backup_101c_f002.ls
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f002_claims_mstr >> $pb_data\backup_101c_f002.ls

echo "Finding files in '101c' data for f010 files only  ..."
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr.idx > $pb_data\backup_101c_f010.ls
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr >> $pb_data\backup_101c_f010.ls
echo ""
Get-Date


echo ""
Get-Date

echo "backup to disk commencing ..."

# CONVERSION ERROR (expected, #53): compressing to cpio.
# cat $pb_data/backup_101c_data.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_data.cpio
# CONVERSION ERROR (expected, #54): compressing to cpio.
# cat $pb_data/backup_101c_f002.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_f002.cpio
# CONVERSION ERROR (expected, #55): compressing to cpio.
# cat $pb_data/backup_101c_f010.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_f010.cpio
echo ""
Get-Date

echo ""
Get-Date
echo "DONE!"
