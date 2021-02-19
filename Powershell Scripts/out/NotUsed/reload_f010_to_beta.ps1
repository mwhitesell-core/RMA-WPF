#-------------------------------------------------------------------------------
# File 'reload_f010_to_beta.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_f010_to_beta'
#-------------------------------------------------------------------------------

echo ""
echo ""
echo "LOAD A BACKUP TAPE ONTO TAPE DRIVE  WITHOUT WRITE RING IN"
echo ""
echo ""

echo ""
echo "RELODING PATIENT MASTER INTO BETA ......."
echo "HIT  `"NEWLINE`"  TO COMMENCE PROCEDURE .."
$garbage = Read-Host
echo ""

Get-Date

Set-Location $pb_data
Remove-Item f010_pat_mstr_orig.dat
# CONVERSION ERROR (expected, #17): cpio.
# cpio -icuvB -I $pb_data/patient.ls

Get-Date
