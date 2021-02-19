#-------------------------------------------------------------------------------
# File 'backup_foxtrot_purge.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_foxtrot_purge'
#-------------------------------------------------------------------------------

echo "backup_foxtrot_purge"
echo ""
echo "Hit NEWLINE to contine ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $Env:root\foxtrot\purge
Get-Location
Get-ChildItem -File $Env:root\foxtrot\purge\* | Select -ExpandProperty FullName `
  > $Env:root\foxtrot\purge\backup_foxtrot_purge.ls
Get-ChildItem -File $Env:root\foxtrot\purge\mp\* | Select -ExpandProperty FullName `
  >> $Env:root\foxtrot\purge\backup_foxtrot_purge.ls
Get-ChildItem -File $Env:root\foxtrot\purge\solo\* | Select -ExpandProperty FullName `
  >> $Env:root\foxtrot\purge\backup_foxtrot_purge.ls
Get-Date
# CONVERSION ERROR (expected, #20): tape device is involved.
# cat     /foxtrot/purge/backup_foxtrot_purge.ls | cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date
echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #24): tape device is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "Performing Tape Verify ..."
echo ""
# CONVERSION ERROR (expected, #29): tape device is involved.
# cpio -itcvB < /dev/rmt/0 >  /foxtrot/purge/backup_foxtrot_purge.log
echo ""
Get-Date
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem $Env:root\foxtrot\purge\backup_foxtrot_purge.ls, $Env:root\foxtrot\purge\backup_foxtrot_purge.log
echo ""
Get-Content $Env:root\foxtrot\purge\backup_foxtrot_purge.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content $Env:root\foxtrot\purge\backup_foxtrot_purge.log | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
echo "ENSURE above record counts MATCH!"
echo ""
Get-Date
echo ""
echo "DONE!"
