#-------------------------------------------------------------------------------
# File 'application_of_rat_60_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'application_of_rat_60_part2'
#-------------------------------------------------------------------------------

echo "************************************************************"
echo "DO NOT HIT NEWLINE AFTER U030 IS FINISHED IN BATCH"
echo "DO?? FROM ANOTHER TERMINAL TO CHECK"
echo "PRINT OR TYPE OUT U030_61.LS TO U030_65.LS CHECK FOR ERRORS"
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
echo ""

echo ""
echo "HIT `"NEWLINE`" TO QUEUE THE RU030A\RU030B\RU030C\RU030D\R997 REPORTS"
$garbage = Read-Host

Set-Location $env:application_production\60
#lp u030_60.ls
#rm ru030a_60
#mv ru030a.txt ru030a_60
#lp ru030a_60
#rm ru030b_60
#mv ru030b.txt ru030b_60
#lp ru030b_60
#rm ru030c_60
#mv ru030c.txt ru030c_60
#lp ru030c_60
#rm ru030d_60
#mv ru030d.txt ru030d_60
#lp ru030d_60
#rm ru030e_60
#mv ru030e.txt ru030e_60
#lp ru030e_60
#rm ru030f_60
#mv ru030f.txt ru030f_60
#lp ru030f_60
#rm r997_60
#mv r997.txt r997_60
##lp r997_60
#lp R997_60
echo ""

Set-Location $env:application_production\61
#lp u030_61.ls
Remove-Item ru030a_61
Move-Item -Force ru030a.txt ru030a_61
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_61 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_61
Move-Item -Force ru030b.txt ru030b_61
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_61 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_61
Move-Item -Force ru030c.txt ru030c_61
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_61 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_61
Move-Item -Force ru030d.txt ru030d_61
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_61 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_61
Move-Item -Force ru030e.txt ru030e_61
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_61 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_61
Move-Item -Force ru030f.txt ru030f_61
#lp ru030f_61
Remove-Item r997_61
Move-Item -Force r997.txt r997_61
#lp r997_61
##lp r997_61
echo ""

Set-Location $env:application_production\62
#lp u030_62.ls
Remove-Item ru030a_62
Move-Item -Force ru030a.txt ru030a_62
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_62 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_62
Move-Item -Force ru030b.txt ru030b_62
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_62 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_62
Move-Item -Force ru030c.txt ru030c_62
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_62 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_62
Move-Item -Force ru030d.txt ru030d_62
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_62 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_62
Move-Item -Force ru030e.txt ru030e_62
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_62 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_62
Move-Item -Force ru030f.txt ru030f_62
#lp ru030f_62
Remove-Item r997_62
Move-Item -Force r997.txt r997_62
#lp r997_62
##lp r997_62
echo ""

Set-Location $env:application_production\63
#lp u030_63.ls
Remove-Item ru030a_63
Move-Item -Force ru030a.txt ru030a_63
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_63 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_63
Move-Item -Force ru030b.txt ru030b_63
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_63 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_63
Move-Item -Force ru030c.txt ru030c_63
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_63 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_63
Move-Item -Force ru030d.txt ru030d_63
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_63 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_63
Move-Item -Force ru030e.txt ru030e_63
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_63 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_63
Move-Item -Force ru030f.txt ru030f_63
Remove-Item ru030f_63
Move-Item -Force  ru030f_63
#lp ru030f_63
Remove-Item r997_63
Move-Item -Force r997.txt r997_63
#lp r997_63
##lp r997_63
echo ""

Set-Location $env:application_production\64
#lp u030_64.ls
Remove-Item ru030a_64
Move-Item -Force ru030a.txt ru030a_64
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_64 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_64
Move-Item -Force ru030b.txt ru030b_64
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_64 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_64
Move-Item -Force ru030c.txt ru030c_64
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_64 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_64
Move-Item -Force ru030d.txt ru030d_64
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_64 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_64
Move-Item -Force ru030e.txt ru030e_64
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_64 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_64
Move-Item -Force ru030f.txt ru030f_64
#lp ru030f_64
Remove-Item r997_64
Move-Item -Force r997.txt r997_64
#lp r997_64
##lp r997_64
echo ""

Set-Location $env:application_production\65
#lp u030_65.ls
Remove-Item ru030a_65
Move-Item -Force ru030a.txt ru030a_65
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_65 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_65
Move-Item -Force ru030b.txt ru030b_65
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_65 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_65
Move-Item -Force ru030c.txt ru030c_65
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_65 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_65
Move-Item -Force ru030d.txt ru030d_65
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_65 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_65
Move-Item -Force ru030e.txt ru030e_65
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_65 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_65
Move-Item -Force ru030f.txt ru030f_65
#lp ru030f_65
Remove-Item r997_65
Move-Item -Force r997.txt r997_65
#lp r997_65
##lp r997_65
echo ""

Set-Location $env:application_production\66
#lp u030_66.ls
Remove-Item ru030a_66
Move-Item -Force ru030a.txt ru030a_66
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_66 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_66
Move-Item -Force ru030b.txt ru030b_66
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_66 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_66
Move-Item -Force ru030c.txt ru030c_66
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_66 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_66
Move-Item -Force ru030d.txt ru030d_66
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_66 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_66
Move-Item -Force ru030e.txt ru030e_66
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_66 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_66
Move-Item -Force ru030f.txt ru030f_66
#lp ru030f_66
Remove-Item r997_66
Move-Item -Force r997.txt r997_66
#lp r997_66
##lp r997_66
echo ""
echo ""
Get-Date
Get-Date
echo ""
echo "TO FINISH THIS RUN  HIT  `"NEWLINE`"  ..."
$garbage = Read-Host
