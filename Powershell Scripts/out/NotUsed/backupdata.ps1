#-------------------------------------------------------------------------------
# File 'backupdata.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backupdata'
#-------------------------------------------------------------------------------

echo "backupdata"
echo ""
echo "HIT  `"NEWLINE`"  TO COMMENCE BACKUPS ..."
$garbage = Read-Host

echo ""
echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
echo "Finding directories with sub directories and files..."

Set-Location $Env:root\
Get-Location

echo "Finding files in '101c' ..."
Get-ChildItem -Exclude "f010_pat_mstr", "f010_pat_mstr.idx", "f002_claims_mstr", "f002_claims_mstr.idx" `
  $Env:root\alpha\rmabill\rmabill101c\data | Select -ExpandProperty FullName > $pb_data\backupdata.ls

echo "Finding files in 'icu' ..."
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillicu\data\* | Select -ExpandProperty FullName `
  >> $pb_data\backupdata.ls

echo "Finding files in 'mp' ..."
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabillmp\data\* | Select -ExpandProperty FullName `
  >> $pb_data\backupdata.ls

echo "Finding files in '101' ..."
Get-ChildItem -recurse $Env:root\alpha\rmabill\rmabill101\data\* | Select -ExpandProperty FullName `
  >> $pb_data\backupdata.ls

echo ""
Get-Date

echo "backup to tape commencing ..."

# CONVERSION ERROR (expected, #39): tape device is involved.
# cat $pb_data/backupdata.ls |cpio -ocuvB > /dev/rmt/1
echo ""
Get-Date
echo "DONE!"

# CONVERSION ERROR (expected, #44): tape device is involved.
# mt -f /dev/rmt/1 rewind
