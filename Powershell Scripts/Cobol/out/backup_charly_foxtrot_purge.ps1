#-------------------------------------------------------------------------------
# File 'backup_charly_foxtrot_purge.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'backup_charly_foxtrot_purge'
#-------------------------------------------------------------------------------

echo "backup_charly_foxtrot_purge"
echo ""
echo "Hit NEWLINE to contine ..."
$garbage = Read-Host

echo ""
echo "BACKUP NOW COMMENCING ..."

Get-Date
echo ""
Set-Location $root\charly\purge
Get-Location

Get-ChildItem -File $root\charly\purge\* | Select -ExpandProperty FullName  > $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\charly\purge\backup\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\charly\purge\mp\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\charly\purge\solo\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\charly\purge\101c\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\charly\purge\costing\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\charly\purge\costing\noweb\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\foxtrot\purge\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\foxtrot\purge\mp\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\foxtrot\purge\solo\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File $root\foxtrot\purge\101c\* | Select -ExpandProperty FullName  >> $root\charly\purge\backup_charly_foxtrot_purge.ls
echo ""
Get-Date
# CONVERSION WARNING; tape is involved.
# cat     /charly/purge/backup_charly_foxtrot_purge.ls | cpio -ocuvB > /dev/rmt/0
echo ""
Get-Date
echo "Rewinding tape ..."
# CONVERSION WARNING; tape is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "Performing Tape Verify ..."
echo ""
# CONVERSION WARNING; tape is involved.
# cpio -itcvB < /dev/rmt/0 >  /charly/purge/backup_charly_foxtrot_purge.log
echo ""
Get-Date
echo ""
echo "Comparing lines in .ls vs .log"
Get-ChildItem $root\charly\purge\backup_charly_foxtrot_purge.ls, $root\charly\purge\backup_charly_foxtrot_purge.log
echo ""
Get-Content ${param.outputValue} | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content ${param.outputValue} | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
echo "ENSURE above record counts MATCH!"
echo ""
Get-Date
echo ""
echo "DONE!"

Set-Location $root\alpha\rmabill\rmabill101c\production
