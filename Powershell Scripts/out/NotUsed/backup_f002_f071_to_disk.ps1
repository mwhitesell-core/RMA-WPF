#-------------------------------------------------------------------------------
# File 'backup_f002_f071_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_f002_f071_to_disk'
#-------------------------------------------------------------------------------

# 2011/02/17            MC - backup f002 claims, shadow & f071 to disk n /foxtrot/purge before claim purge


echo "backup_f002_f071_to_disk"
echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
echo "Finding directories with sub directories and files..."

Set-Location $Env:root\
$application_root = "$Env:root\alpha\rmabill\rmabill101c"
$pb_data = "$env:application_root\data"

echo "Finding files in '101c' data for f002 files only  ..."
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f002_claims_mstr.idx > $pb_data\backup_101c_f002.ls
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f002_claims_mstr >> $pb_data\backup_101c_f002.ls

echo "Finding files in '101c' data for f002 SHDW  only  ..."
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f002_claim_shadow.idx > $pb_data\backup_101c_shdw.ls
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f002_claim_shadow >> $pb_data\backup_101c_shdw.ls

echo "Finding files in '101c' data for f071 files only  ..."
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f071_client_rma_claim_nbr.idx > $pb_data\backup_101c_f071.ls
Get-ChildItem $Env:root\alpha\rmabill\rmabill101c\data\f071_client_rma_claim_nbr >> $pb_data\backup_101c_f071.ls

echo ""
Get-Date

echo "backup to disk commencing ..."

# CONVERSION ERROR (expected, #41): compressing to cpio.
# cat $pb_data/backup_101c_f002.ls |cpio -ocuvB | compress -c  > /foxtrot/purge/backup_101c_f002.cpio
# CONVERSION ERROR (expected, #42): compressing to cpio.
# cat $pb_data/backup_101c_shdw.ls |cpio -ocuvB | compress -c  > /foxtrot/purge/backup_101c_shdw.cpio
# CONVERSION ERROR (expected, #43): compressing to cpio.
# cat $pb_data/backup_101c_f071.ls |cpio -ocuvB | compress -c  > /foxtrot/purge/backup_101c_f071.cpio

echo ""
Get-Date
echo "DONE!"
