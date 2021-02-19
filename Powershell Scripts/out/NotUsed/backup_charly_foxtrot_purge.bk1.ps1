#-------------------------------------------------------------------------------
# File 'backup_charly_foxtrot_purge.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'backup_charly_foxtrot_purge.bk1'
#-------------------------------------------------------------------------------

echo "backup_charly_foxtrot_purge"
echo ""
echo "Hit NEWLINE to contine ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $Env:root\charly\purge
Get-Location

Get-ChildItem -File $Env:root\charly\purge\* | Select -ExpandProperty FullName `
  > $Env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $Env:root\charly\purge\backup\* | Select -ExpandProperty FullName `
  >> $Env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $Env:root\foxtrot\purge\* | Select -ExpandProperty FullName `
  >> $Env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $Env:root\foxtrot\purge\mp\* | Select -ExpandProperty FullName `
  >> $Env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $Env:root\foxtrot\purge\solo\* | Select -ExpandProperty FullName `
  >> $Env:root\charly\purge\backup_charly_foxtrot_purge.ls
echo ""
Get-Date
# CONVERSION ERROR (expected, #26): tape device is involved.
# cat     /charly/purge/backup_charly_foxtrot_purge.ls | cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date
echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #30): tape device is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "Performing Tape Verify ..."
echo ""
# CONVERSION ERROR (expected, #35): tape device is involved.
# cpio -itcvB < /dev/rmt/0 >  /charly/purge/backup_charly_foxtrot_purge.log
echo ""
Get-Date
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem $Env:root\charly\purge\backup_charly_foxtrot_purge.ls, `
  $Env:root\charly\purge\backup_charly_foxtrot_purge.log
echo ""
Get-Content $Env:root\charly\purge\backup_charly_foxtrot_purge.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content $Env:root\charly\purge\backup_charly_foxtrot_purge.log | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
echo "ENSURE above record counts MATCH!"
echo ""
Get-Date
echo ""
echo "DONE!"
