#-------------------------------------------------------------------------------
# File 'application_of_rat_22_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'application_of_rat_22_part2'
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

#cd $application_production/90

#lp u030_90.ls
#mv ru030a.txt ru030a_90
#lp ru030a_90
#mv ru030b.txt ru030b_90
#lp ru030b_90
#mv ru030c.txt ru030c_90
#lp ru030c_90
#mv ru030d.txt ru030d_90
#lp ru030d_90
#mv ru030e.txt ru030e_90
#lp ru030e_90
#mv ru030f.txt ru030f_90
#lp ru030f_90
#mv r997.txt   r997_90
#lp r997_90
#lp r997_90

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
#lp ru030b_22


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
#lp ru030f_22

echo ""
echo ""
#lp u030.ls
echo ""

Move-Item -Force r997.txt r997_22
Get-Content r997_22 | Out-Printer

Get-ChildItem ru030c.txt
echo ""
echo ""
echo "HIT  `"NEWLINE`" TO QUEUE THE OPHIP PARTIAL PAYMENT REPORT"
$garbage = Read-Host

Move-Item -Force ru030c.txt ru030c_22
#lp ru030c_22
echo ""

Get-Date
echo ""
echo "TO FINISH THIS RUN  HIT  `"NEWLINE`"  ..."
$garbage = Read-Host
