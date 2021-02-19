#-------------------------------------------------------------------------------
# File 'backup_f010_production.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_f010_production'
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

Set-Location $pb_data
Get-ChildItem f010_pat_mstr* > patient.ls

# CONVERSION ERROR (expected, #18): tape device is involved.
# cat $pb_data/patient.ls |cpio -ocuvB |dd of=/dev/rmt/1

Get-Date

# CONVERSION ERROR (expected, #22): tape device is involved.
# mt -f /dev/rmt/1 rewind
