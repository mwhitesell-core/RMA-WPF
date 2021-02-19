#-------------------------------------------------------------------------------
# File 'cleanup_80_91to96_monthends.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'cleanup_80_91to96_monthends'
#-------------------------------------------------------------------------------

echo "********************************************************************"

echo "THIS PROGRAM WILL DELETE THE Clinics 80 and 91 to 96 reports"
echo "MAKE SURE ALL THE REPORTS ARE PRINTED AND COPY MAG TAPE IS RUN"
echo ""
echo "********************************************************************"
echo ""
echo "**** HIT NEW LINE TO CONTINUE ****"
$garbage = Read-Host
echo ""
Get-Date

$cmd\cleanup_37_monthend
$cmd\cleanup_68_monthend
$cmd\cleanup_69_monthend
$cmd\cleanup_78_monthend
$cmd\cleanup_79_monthend
$cmd\cleanup_80_monthend
$cmd\cleanup_84_monthend
$cmd\cleanup_87_monthend
$cmd\cleanup_88_monthend
$cmd\cleanup_89_monthend
$cmd\cleanup_91_monthend
$cmd\cleanup_92_monthend
$cmd\cleanup_93_monthend
$cmd\cleanup_94_monthend
$cmd\cleanup_95_monthend
$cmd\cleanup_96_monthend

Get-Date
