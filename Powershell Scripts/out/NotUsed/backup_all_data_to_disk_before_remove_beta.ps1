#-------------------------------------------------------------------------------
# File 'backup_all_data_to_disk_before_remove_beta.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_all_data_to_disk_before_remove_beta'
#-------------------------------------------------------------------------------

# 2009/02/11            MC - backup all data files to cpio  with compress
# 2009/08/10            MC - include subdirectories of disk1 to disk10 under 101c/production (data/disk*dir.ls)


echo "backup_all_data_to_disk"
echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
echo "Finding directories with sub directories and files..."

Set-Location $Env:root\
$application_root = "$Env:root\alpha\rmabill\rmabill101c"
$pb_data = "$env:application_root\data"


echo "Finding files in '101c' data without sub-directories and f002 and f010 ..."
Get-ChildItem -recurse -File -Exclude "f010_pat_mstr", "f010_pat_mstr.dat", "f010_pat_mstr.idx", "f002_claims_mstr", `
  "f002_claims_mstr.dat", "f002_claims_mstr.idx" $Env:root\alpha\rmabill\rmabill101c\data\* | Select -ExpandProperty `
  FullName > $pb_data\backup_101c_data.ls


echo "Finding files in '101c' data for f002 files only  ..."
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f002_claims_mstr.idx > $pb_data\backup_101c_f002.ls
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f002_claims_mstr >> $pb_data\backup_101c_f002.ls

echo "Finding files in '101c' data for f010 files only  ..."
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr.idx > $pb_data\backup_101c_f010.ls
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr >> $pb_data\backup_101c_f010.ls
echo ""
Get-Date

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

echo "Finding files in '101' data without sub-directories ..."
Get-ChildItem -File $Env:root\alpha\rmabill\rmabill101\data\* | Select -ExpandProperty FullName `
  > $pb_data\backup_101_data.ls

echo ""
Get-Date

Set-Location $env:application_root

Get-ChildItem production\ext*, production\f086*, production\moh_obec*, production\r010*, production\u010* `
  > $pb_data\backup_101c_prod.ls

echo "Finding production diskette upload files ..."
Get-Content $pb_data\diskettedir.ls, $pb_data\diskette1dir.ls, $pb_data\disk1dir.ls, $pb_data\disk2dir.ls, `
  $pb_data\disk3dir.ls, $pb_data\disk4dir.ls, $pb_data\disk5dir.ls, $pb_data\disk6dir.ls, $pb_data\disk7dir.ls, `
  $pb_data\disk8dir.ls, $pb_data\disk9dir.ls, $pb_data\disk10dir.ls, $pb_data\suspend.ls, $pb_data\kathydir.ls, `
  $pb_data\mumcdir.ls, $pb_data\stonedir.ls, $pb_data\webdir.ls, $pb_data\web1dir.ls, $pb_data\web2dir.ls, `
  $pb_data\web3dir.ls, $pb_data\web4dir.ls, $pb_data\web5dir.ls, $pb_data\web6dir.ls, $pb_data\web7dir.ls, `
  $pb_data\web8dir.ls, $pb_data\web9dir.ls, $pb_data\web10dir.ls, $pb_data\yasemin.ls `
  | Add-Content $pb_data\backup_101c_prod.ls

echo ""
Get-Date

$doBackupFlag = "Y"
echo "$doBackupFLag"
$testCounter = 1
while ($testCounter -ne 10)
{
  if (Test-Path $pb_data\delay_6pm_backup.flg)
  {
    $doBackupFlag = "N"
    echo "sleeping 1800 seconds or half hour ...."
    sleep 1800
&$testCounter += 1
  } else {
    $testCounter = 10
    $doBackupFlag = "Y"
  }
}
echo "ending $testCounter"
echo "ending $doBackupFlag"

if ("$doBackupFlag" -eq "Y")
{
        echo "DO BACKUP - no flag now"
echo "backup to disk commencing ..."

# CONVERSION ERROR (expected, #133): compressing to cpio.
# cat $pb_data/backup_101c_data.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_data.cpio
# CONVERSION ERROR (expected, #134): compressing to cpio.
# cat $pb_data/backup_101c_f002.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_f002.cpio
# CONVERSION ERROR (expected, #135): compressing to cpio.
# cat $pb_data/backup_101c_f010.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_f010.cpio
# CONVERSION ERROR (expected, #136): compressing to cpio.
# cat $pb_data/backup_101c_prod.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/backup_101c_prod.cpio
# CONVERSION ERROR (expected, #137): compressing to cpio.
# cat $pb_data/backup_mp_data.ls   |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_mp_data.cpio
# CONVERSION ERROR (expected, #138): compressing to cpio.
# cat $pb_data/backup_solo_data.ls |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_solo_data.cpio
# CONVERSION ERROR (expected, #139): compressing to cpio.
# cat $pb_data/backup_101_data.ls  |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_101_data.cpio

echo ""
Get-Date
echo "DONE!"
} else {
        echo "BYPASS backup - still a flag after 10 attempts!"
}
