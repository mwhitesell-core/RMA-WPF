#-------------------------------------------------------------------------------
# File 'backup_subfile_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_subfile_to_disk'
#-------------------------------------------------------------------------------

echo "backup_subfile_to_disk"
echo ""
echo "Hit NEWLINE to continue ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $pb_data2
Get-Location
#ma/claims_sub*.sf* > ma/backup_subfile.ls (changed on jan1898)
# changed below line as 'ma' directory was setup as a link and so actual
# linked directory had to be specified - be 2006/jun/15
#/bin/ls ma/claims_subfile*.* > ma/backup_subfile.ls

# 2007/sep20 b.e. on Dyad's backup machine - dir location changed
#
#/bin/ls /charly/rmabill/rmabill101c/data2/ma/claims_subfile*.* \
#      > /charly/rmabill/rmabill101c/data2/ma/backup_subfile.ls

# 2009/sep/21 M.C  since this macro is used for 3 different environments 101, mp & solo,
#                  the below is only work for 101c but not mp & solo, comment out and change accordingly
##/bin/ls /beta/rmabill/rmabill101c/data2/ma/claims_subfile*.* \
##      > /beta/rmabill/rmabill101c/data2/ma/backup_subfile.ls

Get-ChildItem ma\claims_subfile*.* > ma\backup_subfile.ls

##-------------------------------------------------------


echo ""
Get-Date
Get-Location

# CONVERSION ERROR (expected, #37): compressing to cpio.
# cat     ma/backup_subfile.ls |cpio -ocuvB | compress -c > /charly/backup_transfer_area/backup_subfile_to_disk.cpio
echo ""
Get-Date
echo "backup to disk is done ..."


echo ""
Get-Date
echo "DONE!"

