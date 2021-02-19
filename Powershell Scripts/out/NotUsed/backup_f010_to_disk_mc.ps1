#-------------------------------------------------------------------------------
# File 'backup_f010_to_disk_mc.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_f010_to_disk_mc'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo "LOAD A BACKUP TAPE ONTO TAPE DRIVE  WITH WRITE RING IN."
echo ""
echo ""

echo ""
echo "BACKUP OF PATIENT MASTER FROM PRODUCTION ..."
echo "HIT  `"NEWLINE`"  TO COMMENCE PROCEDURE .."
$garbage = Read-Host
echo ""

Get-Date

Set-Location $env:application_root
Get-ChildItem $Env:root\charly\rmabill\rmabill101c\data\f010_pat_mstr* > data\patient.ls

# CONVERSION ERROR (expected, #18): compressing to cpio.
# cat $pb_data/patient.ls |cpio -ocuvB | compress -c  > /charly/backup_transfer_area/f010.cpio

Get-Date
