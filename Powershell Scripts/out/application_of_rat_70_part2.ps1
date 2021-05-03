#-------------------------------------------------------------------------------
# File 'application_of_rat_70_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'application_of_rat_70_part2'
#-------------------------------------------------------------------------------

echo "************************************************************"
echo "DO NOT HIT NEWLINE AFTER U030 IS FINISHED IN BATCH"
echo "DO?? FROM ANOTHER TERMINAL TO CHECK"
echo "PRINT OR TYPE OUT U030_71.LS TO U030_75.LS CHECK FOR ERRORS"
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

Set-Location $env:application_production\71
#lp u030_71.ls
Remove-Item ru030a_71
Move-Item -Force ru030a.txt ru030a_71
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_71 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_71
Move-Item -Force ru030b.txt ru030b_71
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_71 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_71
Move-Item -Force ru030c.txt ru030c_71
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_71 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_71
Move-Item -Force ru030d.txt ru030d_71
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_71 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_71
Move-Item -Force ru030e.txt ru030e_71
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_71 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_71
Move-Item -Force ru030f.txt ru030f_71
#lp ru030f_71
Remove-Item r997_71
Move-Item -Force r997.txt r997_71
#lp r997_71
##lp r997_71
echo ""

Set-Location $env:application_production\72
#lp u030_72.ls
Remove-Item ru030a_72
Move-Item -Force ru030a.txt ru030a_72
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_72 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_72
Move-Item -Force ru030b.txt ru030b_72
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_72 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_72
Move-Item -Force ru030c.txt ru030c_72
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_72 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_72
Move-Item -Force ru030d.txt ru030d_72
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_72 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_72
Move-Item -Force ru030e.txt ru030e_72
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_72 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_72
Move-Item -Force ru030f.txt ru030f_72
#lp ru030f_72
Remove-Item r997_72
Move-Item -Force r997.txt r997_72
#lp r997_72
##lp r997_72
echo ""

Set-Location $env:application_production\73
#lp u030_73.ls
Remove-Item ru030a_73
Move-Item -Force ru030a.txt ru030a_73
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_73 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_73
Move-Item -Force ru030b.txt ru030b_73
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_73 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_73
Move-Item -Force ru030c.txt ru030c_73
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_73 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_73
Move-Item -Force ru030d.txt ru030d_73
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_73 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_73
Move-Item -Force ru030e.txt ru030e_73
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_73 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_73
Move-Item -Force ru030f.txt ru030f_73
Remove-Item ru030f_73
Move-Item -Force  ru030f_73
#lp ru030f_73
Remove-Item r997_73
Move-Item -Force r997.txt r997_73
#lp r997_73
##lp r997_73
echo ""

Set-Location $env:application_production\74
#lp u030_74.ls
Remove-Item ru030a_74
Move-Item -Force ru030a.txt ru030a_74
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_74 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_74
Move-Item -Force ru030b.txt ru030b_74
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_74 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_74
Move-Item -Force ru030c.txt ru030c_74
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_74 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_74
Move-Item -Force ru030d.txt ru030d_74
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_74 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_74
Move-Item -Force ru030e.txt ru030e_74
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_74 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_74
Move-Item -Force ru030f.txt ru030f_74
#lp ru030f_74
Remove-Item r997_74
Move-Item -Force r997.txt r997_74
#lp r997_74
##lp r997_74
echo ""

Set-Location $env:application_production\75
#lp u030_75.ls
Remove-Item ru030a_75
Move-Item -Force ru030a.txt ru030a_75
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030a_75 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030b_75
Move-Item -Force ru030b.txt ru030b_75
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030b_75 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030c_75
Move-Item -Force ru030c.txt ru030c_75
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030c_75 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030d_75
Move-Item -Force ru030d.txt ru030d_75
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030d_75 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030e_75
Move-Item -Force ru030e.txt ru030e_75
if ( $env:networkprinter -ne 'null'  )
{
   Get-Content ru030e_75 | Out-Printer -Name $env:networkprinter
}

Remove-Item ru030f_75
Move-Item -Force ru030f.txt ru030f_75
#lp ru030f_75
Remove-Item r997_75
Move-Item -Force r997.txt r997_75
#lp r997_75
##lp r997_75
echo ""

Get-Date
echo ""
echo "TO FINISH THIS RUN  HIT  `"NEWLINE`"  ..."
$garbage = Read-Host
