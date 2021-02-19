#-------------------------------------------------------------------------------
# File 'backup_nightly_data_to_dyad_NOTUSED.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_nightly_data_to_dyad_NOTUSED'
#-------------------------------------------------------------------------------

# 2003/dec/08 b.e. removed 101c backup
#
echo "BACKUP_NIGHTLY_DATA_TO_DYAD"
echo ""
#echo  'HIT   "NEWLINE"   TO COMMENCE BACKUP ...'
#read garbage

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""
echo ""
Get-Date
echo ""

Set-Location $env:application_root
# remove flag that indicates job finished successfully
Remove-Item backup_nightly_data_to_dyad.flg *> $null


echo "Finding directories with sub directories and files..."
Set-Location $Env:root\
Get-Location
#find /alpha/rmabill/rmabill101c/data/*        -print >  $pb_data/nightly_data_to_dyad.ls
#find /alpha/rmabill/rmabill101c/data2/*       -print >> $pb_data/nightly_data_to_dyad.ls

Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\data\* | Select -ExpandProperty FullName `
  > $pb_data\nightly_data_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\data2\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_data_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_data_to_dyad.ls
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data2\* | Select -ExpandProperty FullName `
  >> $pb_data\nightly_data_to_dyad.ls
echo ""
echo ""
Get-Date

echo "Starting copy of file to tape ..."
Set-Location $env:application_root
Get-Location
echo "before cat"
# CONVERSION ERROR (expected, #39): piping to cpio.
# cat data/nightly_data_to_dyad.ls  | cpio -ocuvB > /dyad/backup_transfer_area/backup_nightly_data.cpio
echo "after cat"
# set flag that indicates job finished successfully
utouch backup_nightly_data_to_dyad.flg
echo "after touch"
echo " "
Get-Date
echo "DONE!"


#  ***** IF NEW Daily BACKUP ADDED UPDATE BACKUP_DAILY_to_disk  ALSO

echo ""
Get-Date
echo ""
