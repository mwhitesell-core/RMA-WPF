#-------------------------------------------------------------------------------
# File 'rat_8081_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rat_8081_part2'
#-------------------------------------------------------------------------------

echo "************************************************************"
echo "DO NOT HIT NEWLINE AFTER U030 IS FINISHED IN BATCH"
echo "DO?? FROM ANOTHER TERMINAL TO CHECK"
echo "PRINT OR TYPE OUT U030_81.LS TO U030_65.LS CHECK FOR ERRORS"
echo "IF ERRORS RELOAD DAILY_BACKUP FROM LAST NIGHT AND"
echo "FOLLOW RE-RUN INSTRUCTIONS"
echo "*************************************************************"
echo ""
echo " HIT  NEWLINE  TO CONTINUE OR CTRL-C CTRL-A TO QUIT"
$garbage = Read-Host
echo ""

echo ""
echo "**********      S T O P     ***********"
echo ""
echo "MAKE SURE YOU HAVE READ THE 1ST MESSAGE BEFORE HITTING NEWLINE"
$garbage = Read-Host
echo ""

echo ""
echo "HIT `"NEWLINE`" TO QUEUE THE RU030A\RU030B\RU030C\RU030D\R997 REPORTS"
$garbage = Read-Host

Set-Location $env:application_production\80
Get-Content u030_80.ls | Out-Printer
Remove-Item ru030a_80
Move-Item -Force ru030a.txt ru030a_80
Get-Content ru030a_80 | Out-Printer
Remove-Item ru030b_80
Move-Item -Force ru030b.txt ru030b_80
Get-Content ru030b_80 | Out-Printer
Remove-Item ru030c_80
Move-Item -Force ru030c.txt ru030c_80
Get-Content ru030c_80 | Out-Printer
Remove-Item ru030d_80
Move-Item -Force ru030d.txt ru030d_80
Get-Content ru030d_80 | Out-Printer
Remove-Item ru030e_80
Move-Item -Force ru030e.txt ru030e_80
Get-Content ru030e_80 | Out-Printer
Remove-Item ru030f_80
Move-Item -Force ru030f.txt ru030f_80
Get-Content ru030f_80 | Out-Printer
Remove-Item r997_80
Move-Item -Force r997.txt r997_80
Get-Content r997_80 | Out-Printer
echo ""

Set-Location $env:application_production\81
Get-Content u030_81.ls | Out-Printer
Remove-Item ru030a_81
Move-Item -Force ru030a.txt ru030a_81
Get-Content ru030a_81 | Out-Printer
Remove-Item ru030b_81
Move-Item -Force ru030b.txt ru030b_81
Get-Content ru030b_81 | Out-Printer
Remove-Item ru030c_81
Move-Item -Force ru030c.txt ru030c_81
Get-Content ru030c_81 | Out-Printer
Remove-Item ru030d_81
Move-Item -Force ru030d.txt ru030d_81
Get-Content ru030d_81 | Out-Printer
Remove-Item ru030e_81
Move-Item -Force ru030e.txt ru030e_81
Get-Content ru030e_81 | Out-Printer
Remove-Item ru030f_81
Move-Item -Force ru030f.txt ru030f_81
Get-Content ru030f_81 | Out-Printer
Remove-Item r997_81
Move-Item -Force r997.txt r997_81
Get-Content r997_81 | Out-Printer
echo ""
