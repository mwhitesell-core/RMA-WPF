#-------------------------------------------------------------------------------
# File 'rat_90_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_90_part2'
#-------------------------------------------------------------------------------

echo "************************************************************"
echo "DO NOT HIT NEWLINE AFTER U030 IS FINISHED IN BATCH"
echo "DO?? FROM ANOTHER TERMINAL TO CHECK"
echo "PRINT OR TYPE OUT U030.LS TO CHECK FOR ERRORS"
echo "IF ERRORS RELOAD DAILY_BACKUP FROM LAST NIGHT AND"
echo "FOLLOW RE-RUN INSTRUCTIONS"
echo "*************************************************************"
echo ""
echo "HIT  NEWLINE  TO CONTINUE OR CTRL-C CTRL-A TO QUIT"
$garbage = Read-Host
echo ""

echo ""
echo "**********      S T O P     ***********"
echo ""
echo "MAKE SURE YOU HAVE READ THE 1ST MESSAGE BEFORE HITTING NEWLINE"
$garbage = Read-Host

Set-Location $env:application_production\90

Get-Content u030_90.ls | Out-Printer
Move-Item -Force ru030a.txt ru030a_90
Get-Content ru030a_90 | Out-Printer
Move-Item -Force ru030b.txt ru030b_90
Get-Content ru030b_90 | Out-Printer
Move-Item -Force ru030c.txt ru030c_90
Get-Content ru030c_90 | Out-Printer
Move-Item -Force ru030d.txt ru030d_90
Get-Content ru030d_90 | Out-Printer
Move-Item -Force ru030e.txt ru030e_90
Get-Content ru030e_90 | Out-Printer
Move-Item -Force ru030f.txt ru030f_90
Get-Content ru030f_90 | Out-Printer
Move-Item -Force r997.txt r997_90
Get-Content r997_90 | Out-Printer
Get-Content r997_90 | Out-Printer

Set-Location $env:application_production
