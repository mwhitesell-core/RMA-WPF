#-------------------------------------------------------------------------------
# File 'backup_charly_data.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_charly_data.com'
#-------------------------------------------------------------------------------

echo "backup_charly_data.com"
# 2005/jul/18 b.e. added backup of obj and cmd in rmabill mp
# 2007/nov/01 M.C. modify accordingly
# 2007/nov/05 M.C. Yasemin requested to backup everything under production

echo ""
echo "BACKUP NOW COMMENCING ..."
echo ""

echo ""
Get-Date
echo ""

$application_root = "$Env:root\alpha\rmabill\rmabill101c"
Set-Location $env:application_root
$pb_data = "$Env:root\alpha\rmabill\rmabill101c\data"


echo "Finding directories: charly\101c\data except current f010 ...."
Get-ChildItem -Exclude "f010_pat_mstr", "f010_pat_mstr.idx" $Env:root\charly\rmabill\rmabill101c\data | Select `
  -ExpandProperty FullName > $pb_data\backup_charly_data.ls

echo ""
Get-Date


echo "Starting copy of files to TAPE ..."
Get-Location

# CONVERSION ERROR (expected, #33): tape device is involved.
# cat    $pb_data/backup_charly_data.ls    \    | cpio -ocuvB > /dev/rmt/1

echo " "
Get-Date
echo "DONE!"

echo ""
Get-Date
echo ""
