#-------------------------------------------------------------------------------
# File 'backup_data2_ma_to_disk.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_data2_ma_to_disk'
#-------------------------------------------------------------------------------

echo "backup_data2_ma_to_disk"
echo ""
echo "Hit NEWLINE to continue ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $pb_data2
Get-Location

Get-ChildItem ma\* > backup_data2_ma.ls


echo ""
Get-Date
Get-Location

# CONVERSION ERROR (expected, #21): piping to cpio.
# cat     backup_data2_ma.ls |cpio -ocuvB  > /charly/backup_transfer_area/backup_data2_ma_to_disk.cpio
echo ""
Get-Date
echo "backup to disk is done ..."


echo ""
Get-Date
echo "DONE!"

