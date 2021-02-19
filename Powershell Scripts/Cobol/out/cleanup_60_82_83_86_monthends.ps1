#-------------------------------------------------------------------------------
# File 'cleanup_60_82_83_86_monthends.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'cleanup_60_82_83_86_monthends'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE Clinics 82 and 83 and 61 to 65 reports"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host
echo ""
Get-Date

$cmd\cleanup_82_monthend
$cmd\cleanup_86_monthend
$cmd\cleanup_60_monthend
$cmd\cleanup_70_monthend

Get-Date
