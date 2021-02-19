#-------------------------------------------------------------------------------
# File 'rat_2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_2'
#-------------------------------------------------------------------------------

Get-ChildItem -Force ru030a.txt
echo "Hit   `"NEWLINE`"  to queue the unmatched ohip payment report"
$garbage = Read-Host
Move-Item -Force ru030a.txt ru030a_22 *> $null
Get-Content ru030a_22 | Out-Printer
echo ""
echo ""
Get-ChildItem -Force ru030b.txt
echo ""
echo "Hit   `"NEWLINE`"  to queue the ohip partial payment report"
$garbage = Read-Host
Move-Item -Force ru030b.txt ru030b_22 *> $null
Get-Content ru030b_22 | Out-Printer
Get-ChildItem -Force ru030c.txt
echo ""
echo ""
echo "Hit   `"NEWLINE`"  to queue the ophip partial payment report"
$garbage = Read-Host
Move-Item -Force ru030c.txt ru030c_22 *> $null
Get-Content ru030c_22 | Out-Printer
Get-ChildItem -Force ru030d.txt
echo ""
echo ""
echo "Hit   `"NEWLINE`"  to queue the no equivalence oma code report"
$garbage = Read-Host
Move-Item -Force ru030d.txt ru030d_22 *> $null
Get-Content ru030d_22 | Out-Printer
echo ""
echo ""
Get-Content u030.ls | Out-Printer
echo ""
Move-Item -Force r997.txt r997_22 *> $null
Get-Content r997_22 | Out-Printer
echo ""
echo "A doctor revenue backup will now be run ---after--- update ..."
echo ""
echo "Load an unlabelled tape to commence backup --"
echo ""
echo "Hit   `"NEWLINE`"   when ready ..."
$garbage = Read-Host
#  $cmd/backup_f002_rat_files
&$env:cmd\backup_f002_rat_files_part1
&$env:cmd\backup_f002_rat_files_part2
echo ""
echo "To finish this run  hit   `"NEWLINE`"  ..."
$garbage = Read-Host
