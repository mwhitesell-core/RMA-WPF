#-------------------------------------------------------------------------------
# File 'rat_22_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_22_part2'
#-------------------------------------------------------------------------------

Set-Location $env:application_production

Get-ChildItem ru030a.txt
echo ""
Move-Item -Force ru030a.txt ru030a_22
Get-Content ru030a_22 | Out-Printer
echo ""
echo ""
Get-ChildItem ru030b.txt
echo ""
echo "HIT  `"NEWLINE`" TO QUEUE THE OHIP PARTIAL PAYMENT REPORT"
$garbage = Read-Host

Move-Item -Force ru030b.txt ru030b_22
Get-Content ru030b_22 | Out-Printer


Get-ChildItem ru030d.txt
echo ""
echo ""
echo "HIT  `"NEWLINE`" TO QUEUE THE NO EQUIVALENCE OMA CODE REPORT"
$garbage = Read-Host

Move-Item -Force ru030d.txt ru030d_22
Get-Content ru030d_22 | Out-Printer


Move-Item -Force ru030e.txt ru030e_22
Get-Content ru030e_22 | Out-Printer


Move-Item -Force ru030f.txt ru030f_22
Get-Content ru030f_22 | Out-Printer

echo ""
echo ""
Get-Content u030.ls | Out-Printer
echo ""

Move-Item -Force r997.txt r997_22
Get-Content r997_22 | Out-Printer

Get-ChildItem ru030c.txt
echo ""
echo ""
echo "HIT  `"NEWLINE`" TO QUEUE THE OPHIP PARTIAL PAYMENT REPORT"
$garbage = Read-Host

Move-Item -Force ru030c.txt ru030c_22
Get-Content ru030c_22 | Out-Printer
echo ""

Get-Date
echo ""
echo "TO FINISH THIS RUN  HIT  `"NEWLINE`"  ..."
$garbage = Read-Host
