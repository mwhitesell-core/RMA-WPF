#-------------------------------------------------------------------------------
# File 'reload_all_data_from_disk.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_all_data_from_disk.com'
#-------------------------------------------------------------------------------

## reload_all_data_from_disk.com
# 2012/06/21            MC1 - search dummy records in files as Brad suggested    after restore of files
# 2012/07/04            MC2 - delete dummy records in files as Brad suggested    after restore of files
# 2013/Apr/08           MC3 - add Setting up profile & environment in order to run powerhouse program properly & successfully

echo "reload_all_data_from_disk.com"

Get-Date
#MC3
echo ""
echo "Setting up Profile ..."
. $Env:root\macros\profile

#MC3
echo ""
echo "Setting up Environment ..."
rmabill 101c
echo ""


#application_root=/alpha/rmabill/rmabill101c
Set-Location $env:application_root

echo "restore 101c data from disk"
## rm data/*
# CONVERSION ERROR (expected, #27): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_101c_data.cpio | cpio -icdvB
Get-Date

echo "restore 101c f002 data from disk"

## 2009/may/20 - f002 files takes (91% - 58%) = 33% in dyad
## MUST delete the files before reload; otherwise receive error 'No space Left'

Remove-Item data\f002_claims_mstr
Remove-Item data\f002_claims_mstr.idx
# CONVERSION ERROR (expected, #37): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_101c_f002.cpio | cpio -icdvB
Get-Date

echo "restore 101c f010 data from disk"
## rm /charly/rmabill/rmabill101c/data/f010_pat_mstr
## rm /charly/rmabill/rmabill101c/data/f010_pat_mstr.idx

# CONVERSION ERROR (expected, #44): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_101c_f010.cpio | cpio -icdvB
Get-Date

echo "restore 101c production from disk"
## 2009/aug/10 - include disk1 to disk 10
## rm -r production/disk?/*
## rm -r production/disk10/*
## rm -r production/diskette/*
## rm -r production/diskette1/*
## rm -r production/kathy/*
## rm -r production/mumc/*
## rm -r production/stone/*
## rm -r production/web*/*   
## rm -r production/yasemin/yearend*/*
## rm    production/f002_suspend*

# CONVERSION ERROR (expected, #60): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_101c_prod.cpio | cpio -icdvB
Get-Date

echo "restore mp   data from disk"
# CONVERSION ERROR (expected, #64): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_mp_data.cpio | cpio -icdvB
Get-Date

echo "restore solo data from disk"
# CONVERSION ERROR (expected, #68): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_solo_data.cpio | cpio -icdvB
Get-Date

echo "restore 101 data from disk"
# CONVERSION ERROR (expected, #72): compressing to cpio.
# uncompress -c < /charly/backup_transfer_area/backup_101_data.cpio | cpio -icdvB
Get-Date

#MC1- start
##echo "search dummy records ...."
##$application_root/cmd/search_dummy_records > $application_root/production/search_dummy_records.log
#MC1- end

#MC2- start
echo "delete dummy records ...."
#$application_root/cmd/delete_dummy_records > $application_root/production/delete_dummy_records.log
&$env:application_root\cmd\delete_dummy_records
#MC2- end

#MC3- start
echo "check dummy records ...."
&$env:application_root\cmd\check_dummy_records
#MC3- end



## cd data
## echo "create links for files"
## . ./create_links.com
## ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr     f010_pat_mstr
## ln -s /charly/rmabill/rmabill101c/data/f010_pat_mstr.idx f010_pat_mstr.idx

echo "restore is done"
Get-Date
