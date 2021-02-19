#-------------------------------------------------------------------------------
# File 'backup_charly_foxtrot_purge.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
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
Set-Location \\$env:root\charly\purge
Get-Location

Get-ChildItem -File \\$env:root\charly\purge\* | Select -ExpandProperty FullName `
  > \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\charly\purge\backup\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\charly\purge\mp\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\charly\purge\solo\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\charly\purge\101c\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\charly\purge\costing\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\charly\purge\costing\noweb\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\foxtrot\purge\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\foxtrot\purge\mp\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\foxtrot\purge\solo\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
Get-ChildItem -File \\$env:root\foxtrot\purge\101c\* | Select -ExpandProperty FullName `
  >> \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls
$Utf8NoBomEncoding = New-Object System.Text.UTF8Encoding $False
$ls = Get-Content $env:pb_data/backup_charly_foxtrot_purge.ls #| Set-Content -Encoding UTF8 -Path $env:pb_data/backup_earnings_daily$1.ls
[System.IO.File]::WriteAllLines("$env:pb_data/backup_charly_foxtrot_purge.ls",$ls, $Utf8NoBomEncoding)
echo ""
Get-Date
# CONVERSION ERROR (expected, #38): tape device is involved.
# cat     /charly/purge/backup_charly_foxtrot_purge.ls | cpio -ocuvB > /dev/rmt/0
&"C:\Program Files\7-Zip\7z.exe" a -aoa -spf2 $env:pb_data/backup_charly_foxtrot_purge.tar @$env:pb_data/backup_charly_foxtrot_purge.ls
&"C:\Program Files\7-Zip\7z.exe" rn $env:pb_data/backup_charly_foxtrot_purge.tar -r RMA/alpha alpha
echo ""
Get-Date
echo "Rewinding tape ..."
# CONVERSION ERROR (expected, #42): tape device is involved.
# mt -f /dev/rmt/0 rewind

echo ""
echo "Performing Tape Verify ..."
echo ""
# CONVERSION ERROR (expected, #47): tape device is involved.
# cpio -itcvB < /dev/rmt/0 >  /charly/purge/backup_charly_foxtrot_purge.log
echo ""
Get-Date
echo ""
echo "Comparing lines in .ls vs .log"

&"C:\Program Files\7-Zip\7z.exe" l $env:pb_data/backup_charly_foxtrot_purge.tar > $env:pb_data\backup_charly_foxtrot_purge.log
(Get-Content $env:pb_data\backup_charly_foxtrot_purge.log | Select-Object -Skip 17) | Set-Content $env:pb_data/backup_charly_foxtrot_purge.log
$test = Get-Content $env:pb_data/backup_charly_foxtrot_purge.log
$test = $test[0..($test.count-3)]
$test | ForEach { $_.Remove(0,53) } | Set-Content $env:pb_data/backup_charly_foxtrot_purge.log

Get-ChildItem \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls, `
  \\$env:root\charly\purge\backup_charly_foxtrot_purge.log
echo ""
Get-Content \\$env:root\charly\purge\backup_charly_foxtrot_purge.ls | Measure-Object -Line | Select -ExpandProperty Lines
Get-Content \\$env:root\charly\purge\backup_charly_foxtrot_purge.log | Measure-Object -Line | Select -ExpandProperty Lines

echo ""
echo "ENSURE above record counts MATCH!"
echo ""
Get-Date
echo ""
echo "DONE!"

Set-Location $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production
