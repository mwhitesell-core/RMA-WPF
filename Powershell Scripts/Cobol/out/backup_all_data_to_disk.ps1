#-------------------------------------------------------------------------------
# File 'backup_all_data_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_all_data_to_disk'
#-------------------------------------------------------------------------------

# 2009/02/11            MC - backup all data files to cpio  with compress
# 2009/08/10            MC - include subdirectories of disk1 to disk10 under 101c/production (data/disk*dir.ls)
# 2009/10/27            MC - include specific full pathname fof f050/f050tp history files, has moved to /charly
# 2011/04/05            MC - include Maria's stuff (r087* r085e* u085*) in production as suggested by Brad       
# 2011/12/08            MC - comment out mumc, stone, diskette & diskette1 since no longer needed 
# 2011/12/12            be1 - allow the system to wait 20 times before giving up on finding the backup flag set
# 2012/04/05            MC - include subdirectories n85 & n85a from production
# 2012/06/20            MC1 - create dummy records in files as Brad suggested    before backup
#                             and delete dummy records in files after backup
# 2012/06/27            be2 - setup environment so that qtp can run
# 2012/07/04            MC2 - check  dummy records in files after deleting dummy records in files
# 2013/04/08            MC3 - change programs for check dummy records  
# 2013/07/30            MC4 - replace n85 with oscar because Yasemin has renamed the directories
# 2013/11/15            be3 - added u030* to backup of 'production'
# 2014/07/05            be4 - allow the system to wait 30 times before giving up on finding the backup flag set
#                             because 20 times didn't wait until 3:00am
# 2014/09/09            MC5 - include second* and u020c_ohip_run_date* subfile for ohip run

echo "backup_all_data_to_disk"
echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."

#be2
echo ""
echo "Setting up Profile ..."
. $root\macros\profile

#be2
echo ""
echo "Setting up Environment ..."
rmabill 101c
echo ""

Get-Date
echo ""
echo "Finding directories with sub directories and files..."

Set-Location $root\
#application_root=/alpha/rmabill/rmabill101c
$pb_data = "$application_root\data"


echo "Finding files in '101c' data without sub-directories and f002 and f010 ..."
Get-ChildItem -File -Exclude "f010_pat_mstr", "f010_pat_mstr.dat", "f010_pat_mstr.idx", "f002_claims_mstr", "f002_claims_mstr.dat", "f002_claims_mstr.idx" $root\alpha\rmabill\rmabill101c\data\* | Select -ExpandProperty FullName  > $pb_data\backup_101c_data.ls

echo "Finding files in '101c' data for f050 history files.."
Get-ChildItem $root\charly\rmabill\rmabill101c\data\f050*doc_revenue_*history*  >> $pb_data\backup_101c_data.ls

echo "Finding files in '101c' data for f002 files only  ..."
Get-ChildItem $root\alpha\rmabill\rmabill101c\data\f002_claims_mstr.idx  > $pb_data\backup_101c_f002.ls
Get-ChildItem $root\alpha\rmabill\rmabill101c\data\f002_claims_mstr  >> $pb_data\backup_101c_f002.ls

echo "Finding files in '101c' data for f010 files only  ..."
Get-ChildItem $root\charly\rmabill\rmabill101c\data\f010_pat_mstr.idx  > $pb_data\backup_101c_f010.ls
Get-ChildItem $root\charly\rmabill\rmabill101c\data\f010_pat_mstr  >> $pb_data\backup_101c_f010.ls
echo ""
Get-Date

echo "Finding files in 'mp' data without sub-directories ..."
Get-ChildItem -File $root\alpha\rmabill\rmabillmp\data\* | Select -ExpandProperty FullName  > $pb_data\backup_mp_data.ls

echo ""
Get-Date

echo "Finding files in 'solo' data without sub-directories ..."
Get-ChildItem -File $root\alpha\rmabill\rmabillsolo\data\* | Select -ExpandProperty FullName  > $pb_data\backup_solo_data.ls

echo ""
Get-Date

echo "Finding files in '101' data without sub-directories ..."
Get-ChildItem -File $root\alpha\rmabill\rmabill101\data\* | Select -ExpandProperty FullName  > $pb_data\backup_101_data.ls

echo ""
Get-Date

Set-Location $application_root
#be3 - added r997*, u030* and /1* /2* -9/*
#/bin/ls                                        \
Get-ChildItem -recurse production\ext* | Select -ExpandProperty FullName  > $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\f086* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\moh_obec* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\r010* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\r085* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\r087* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\r997* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\u085* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\u010* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\u030* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\2* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\3* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\4* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\5* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\6* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\7* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\8* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\9* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
#MC4
Get-ChildItem -recurse production\second* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls
Get-ChildItem -recurse production\u020c_ohip_run_date* | Select -ExpandProperty FullName  >> $pb_data\backup_101c_prod.ls

echo "Finding production diskette upload files ..."
#cat   $pb_data/diskettedir.ls  \
#      $pb_data/diskette1dir.ls  \
#      $pb_data/mumcdir.ls  \
#      $pb_data/stonedir.ls  \

Get-Content $pb_data\disk1dir.ls, $pb_data\disk2dir.ls, $pb_data\disk3dir.ls, $pb_data\disk4dir.ls, $pb_data\disk5dir.ls, $pb_data\disk6dir.ls, $pb_data\disk7dir.ls, $pb_data\disk8dir.ls, $pb_data\disk9dir.ls, $pb_data\disk10dir.ls, $pb_data\kathydir.ls, $pb_data\webdir.ls, $pb_data\web1dir.ls, $pb_data\web2dir.ls, $pb_data\web3dir.ls, $pb_data\web4dir.ls, $pb_data\web5dir.ls, $pb_data\web6dir.ls, $pb_data\web7dir.ls, $pb_data\web8dir.ls, $pb_data\web9dir.ls, $pb_data\web10dir.ls, $pb_data\yasemin.ls, $pb_data\oscar.ls  >> $pb_data\backup_101c_prod.ls

echo ""
Get-Date

$doBackupFlag = "Y"
echo "$doBackupFLag"
$testCounter = 1
#be1 while [ $testCounter != 12 ]
#be4 while [ $testCounter != 20 ]
echo "checking counter"
while ($testCounter -ne 30)
{
  if (Test-Path $pb_data\delay_6pm_backup.flg)
  {
    $doBackupFlag = "N"
    echo "sleeping 1800 seconds or half hour ...."
    #be3 display time as job waits
    echo "$(udate)"
    sleep 1800
$testCounter += 1
  } else {
#    testCounter=12
#be3    testCounter=20
    $testCounter = 30
    $doBackupFlag = "Y"
  }
}
echo "ending $testCounter"
echo "ending $doBackupFlag"

if ("$doBackupFlag" -eq "Y")
{

echo ""
Get-Date

#MC1- start
echo "create dummy records starting ...."
$application_root\cmd\create_dummy_records
#MC1- end

echo "DO BACKUP - no flag now"
echo "backup to disk commencing ..."

echo ""
Get-Date

# CONVERSION WARNING; compress+cpio is involved.
# cat $pb_data/backup_101c_data.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_data.cpio
# CONVERSION WARNING; compress+cpio is involved.
# cat $pb_data/backup_101c_f002.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_f002.cpio
# CONVERSION WARNING; compress+cpio is involved.
# cat $pb_data/backup_101c_f010.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_f010.cpio
# CONVERSION WARNING; compress+cpio is involved.
# cat $pb_data/backup_101c_prod.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_prod.cpio
# CONVERSION WARNING; compress+cpio is involved.
# cat $pb_data/backup_mp_data.ls   |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_mp_data.cpio
# CONVERSION WARNING; compress+cpio is involved.
# cat $pb_data/backup_solo_data.ls |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_solo_data.cpio
# CONVERSION WARNING; compress+cpio is involved.
# cat $pb_data/backup_101_data.ls  |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_101_data.cpio

#MC1- start
echo "delete dummy records starting ...."
echo ""
Get-Date
$application_root\cmd\delete_dummy_records
#MC1- end

#MC2- start
echo "check  dummy records starting ...."
echo ""
Get-Date
#MC3 - 2013/04/08
#quiz auto=$application_root/src/check_dummy_records.qzs > $application_root/production/check_dummy_records.log
#quiz auto=$application_root/cmd/check_dummy_records 
$application_root\cmd\check_dummy_records
#MC2- end

echo ""
Get-Date
echo "DONE!"
} else {
#        echo BYPASS backup - still a flag after 10 attempts!
#        echo BYPASS backup - still a flag after 20 attempts!
        echo "BYPASS backup - still a flag after 30 attempts!"
}
