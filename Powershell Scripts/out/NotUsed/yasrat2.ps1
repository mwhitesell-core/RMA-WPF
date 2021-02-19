#-------------------------------------------------------------------------------
# File 'yasrat2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yasrat2'
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


Set-Location $env:application_production\82
Get-Content u030_82.ls | Out-Printer
Remove-Item ru030a_82
Move-Item -Force ru030a.txt ru030a_82
Get-Content ru030a_82 | Out-Printer
Remove-Item ru030b_82
Move-Item -Force ru030b.txt ru030b_82
Get-Content ru030b_82 | Out-Printer
Remove-Item ru030c_82
Move-Item -Force ru030c.txt ru030c_82
Get-Content ru030c_82 | Out-Printer
Remove-Item ru030d_82
Move-Item -Force ru030d.txt ru030d_82
Get-Content ru030d_82 | Out-Printer
Remove-Item ru030e_82
Move-Item -Force ru030e.txt ru030e_82
Get-Content ru030e_82 | Out-Printer
Remove-Item ru030f_82
Move-Item -Force ru030f.txt ru030f_82
Get-Content ru030f_82 | Out-Printer
Remove-Item r997_82
Move-Item -Force r997.txt r997_82
Get-Content r997_82 | Out-Printer
echo ""

Set-Location $env:application_production\83
Get-Content u030_83.ls | Out-Printer
Remove-Item ru030a_83
Move-Item -Force ru030a.txt ru030a_83
Get-Content ru030a_83 | Out-Printer
Remove-Item u030b_83
Move-Item -Force ru030b.txt ru030b_83
Get-Content ru030b_83 | Out-Printer
Remove-Item ru030c_83
Move-Item -Force ru030c.txt ru030c_83
Get-Content ru030c_83 | Out-Printer
Remove-Item ru030d_83
Move-Item -Force ru030d.txt ru030d_83
Get-Content ru030d_83 | Out-Printer
Remove-Item ru030e_83
Move-Item -Force ru030e.txt ru030e_83
Get-Content ru030e_83 | Out-Printer
Remove-Item ru030f_83
Move-Item -Force ru030f.txt ru030f_83
Get-Content ru030f_83 | Out-Printer
Remove-Item r997_83
Move-Item -Force r997.txt r997_83
Get-Content r997_83 | Out-Printer
echo ""
Get-Date
echo ""
echo "TO FINISH THIS RUN  HIT  `"NEWLINE`"  ..."
$garbage = Read-Host
