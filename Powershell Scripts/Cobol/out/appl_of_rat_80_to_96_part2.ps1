#-------------------------------------------------------------------------------
# File 'appl_of_rat_80_to_96_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'appl_of_rat_80_to_96_part2'
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

Set-Location $application_production\37
#lp u030_37.ls
Remove-Item ru030a_37
Move-Item ru030a.txt ru030a_37
Get-Contents ru030a_37| Out-Printer
Remove-Item ru030b_37
Move-Item ru030b.txt ru030b_37
Get-Contents ru030b_37| Out-Printer
Remove-Item ru030c_37
Move-Item ru030c.txt ru030c_37
Get-Contents ru030c_37| Out-Printer
Remove-Item u030d_37
Move-Item ru030d.txt ru030d_37
Get-Contents ru030d_37| Out-Printer
Remove-Item ru030e_37
Move-Item ru030e.txt ru030e_37
Get-Contents ru030e_37| Out-Printer
Remove-Item ru030f_37
Move-Item ru030f.txt ru030f_37
#lp ru030f_37
Remove-Item r997_37
Move-Item r997.txt r997_37
#lp r997_37
echo ""


Set-Location $application_production\78
#lp u030_78.ls
Remove-Item ru030a_78
Move-Item ru030a.txt ru030a_78
Get-Contents ru030a_78| Out-Printer
Remove-Item ru030b_78
Move-Item ru030b.txt ru030b_78
Get-Contents ru030b_78| Out-Printer
Remove-Item ru030c_78
Move-Item ru030c.txt ru030c_78
Get-Contents ru030c_78| Out-Printer
Remove-Item u030d_78
Move-Item ru030d.txt ru030d_78
Get-Contents ru030d_78| Out-Printer
Remove-Item ru030e_78
Move-Item ru030e.txt ru030e_78
Get-Contents ru030e_78| Out-Printer
Remove-Item ru030f_78
Move-Item ru030f.txt ru030f_78
#lp ru030f_78
Remove-Item r997_78
Move-Item r997.txt r997_78
#lp r997_78
echo ""

Set-Location $application_production\79
#lp u030_79.ls
Remove-Item ru030a_79
Move-Item ru030a.txt ru030a_79
Get-Contents ru030a_79| Out-Printer
Remove-Item ru030b_79
Move-Item ru030b.txt ru030b_79
Get-Contents ru030b_79| Out-Printer
Remove-Item ru030c_79
Move-Item ru030c.txt ru030c_79
Get-Contents ru030c_79| Out-Printer
Remove-Item u030d_79
Move-Item ru030d.txt ru030d_79
Get-Contents ru030d_79| Out-Printer
Remove-Item ru030e_79
Move-Item ru030e.txt ru030e_79
Get-Contents ru030e_79| Out-Printer
Remove-Item ru030f_79
Move-Item ru030f.txt ru030f_79
#lp ru030f_79
Remove-Item r997_79
Move-Item r997.txt r997_79
#lp r997_79
echo ""

Set-Location $application_production\80
#lp u030_80.ls
Remove-Item ru030a_80
Move-Item ru030a.txt ru030a_80
Get-Contents ru030a_80| Out-Printer
Remove-Item ru030b_80
Move-Item ru030b.txt ru030b_80
Get-Contents ru030b_80| Out-Printer
Remove-Item ru030c_80
Move-Item ru030c.txt ru030c_80
Get-Contents ru030c_80| Out-Printer
Remove-Item ru030d_80
Move-Item ru030d.txt ru030d_80
Get-Contents ru030d_80| Out-Printer
Remove-Item ru030e_80
Move-Item ru030e.txt ru030e_80
Get-Contents ru030e_80| Out-Printer
Remove-Item ru030f_80
Move-Item ru030f.txt ru030f_80
#lp ru030f_80
Remove-Item r997_80
Move-Item r997.txt r997_80
#lp r997_80
echo ""

#cd $application_production/81
#lp u030_81.ls
#rm ru030a_81
#mv ru030a.txt ru030a_81
#lp ru030a_81
#rm ru030b_81
#mv ru030b.txt ru030b_81
#lp ru030b_81
#rm ru030c_81
#mv ru030c.txt ru030c_81
#lp ru030c_81
#rm ru030d_81
#mv ru030d.txt ru030d_81
Get-Contents ru030d_81| Out-Printer
#rm ru030e_81
#mv ru030e.txt ru030e_81
#lp ru030e_81
#rm ru030f_81
#mv ru030f.txt ru030f_81
#lp ru030f_81
#rm r997_81
#mv r997.txt r997_81
#lp r997_81
echo ""

Set-Location $application_production\82
#lp u030_82.ls
Remove-Item ru030a_82
Move-Item ru030a.txt ru030a_82
Get-Contents ru030a_82| Out-Printer
Remove-Item ru030b_82
Move-Item ru030b.txt ru030b_82
Get-Contents ru030b_82| Out-Printer
Remove-Item ru030c_82
Move-Item ru030c.txt ru030c_82
Get-Contents ru030c_82| Out-Printer
Remove-Item ru030d_82
Move-Item ru030d.txt ru030d_82
Get-Contents ru030d_82| Out-Printer
Remove-Item ru030e_82
Move-Item ru030e.txt ru030e_82
Get-Contents ru030e_82| Out-Printer
Remove-Item ru030f_82
Move-Item ru030f.txt ru030f_82
#lp ru030f_82
Remove-Item r997_82
Move-Item r997.txt r997_82
#lp r997_82
echo ""

Set-Location $application_production\83
#lp u030_83.ls
Remove-Item ru030a_83
Move-Item ru030a.txt ru030a_83
Get-Contents ru030a_83| Out-Printer
Remove-Item u030b_83
Move-Item ru030b.txt ru030b_83
Get-Contents ru030b_83| Out-Printer
Remove-Item ru030c_83
Move-Item ru030c.txt ru030c_83
Get-Contents ru030c_83| Out-Printer
Remove-Item ru030d_83
Move-Item ru030d.txt ru030d_83
Get-Contents ru030d_83| Out-Printer
Remove-Item ru030e_83
Move-Item ru030e.txt ru030e_83
Get-Contents ru030e_83| Out-Printer
Remove-Item ru030f_83
Move-Item ru030f.txt ru030f_83
#lp ru030f_83
Remove-Item r997_83
Move-Item r997.txt r997_83
#lp r997_83

echo ""

Set-Location $application_production\84
#lp u030_84.ls
Remove-Item ru030a_84
Move-Item ru030a.txt ru030a_84
Get-Contents ru030a_84| Out-Printer
Remove-Item ru030b_84
Move-Item ru030b.txt ru030b_84
Get-Contents ru030b_84| Out-Printer
Remove-Item ru030c_84
Move-Item ru030c.txt ru030c_84
Get-Contents ru030c_84| Out-Printer
Remove-Item ru030d_84
Move-Item ru030d.txt ru030d_84
Get-Contents ru030d_84| Out-Printer
Remove-Item ru030e_84
Move-Item ru030e.txt ru030e_84
Get-Contents ru030e_84| Out-Printer
Remove-Item ru030f_84
Move-Item ru030f.txt ru030f_84
#lp ru030f_84
Remove-Item r997_84
Move-Item r997.txt r997_84
#lp r997_84
echo ""

Set-Location $application_production\86
#lp u030_86.ls
Remove-Item ru030a_86
Move-Item ru030a.txt ru030a_86
Get-Contents ru030a_86| Out-Printer
Remove-Item ru030b_86
Move-Item ru030b.txt ru030b_86
Get-Contents ru030b_86| Out-Printer
Remove-Item ru030c_86
Move-Item ru030c.txt ru030c_86
Get-Contents ru030c_86| Out-Printer
Remove-Item ru030d_86
Move-Item ru030d.txt ru030d_86
Get-Contents ru030d_86| Out-Printer
Remove-Item ru030e_86
Move-Item ru030e.txt ru030e_86
Get-Contents ru030e_86| Out-Printer
Remove-Item ru030f_86
Move-Item ru030f.txt ru030f_86
#lp ru030f_86
Remove-Item r997_86
Move-Item r997.txt r997_86
#lp r997_86

Set-Location $application_production\87
#lp u030_87.ls
Remove-Item ru030a_87
Move-Item ru030a.txt ru030a_87
Get-Contents ru030a_87| Out-Printer
Remove-Item ru030b_87
Move-Item ru030b.txt ru030b_87
Get-Contents ru030b_87| Out-Printer
Remove-Item ru030c_87
Move-Item ru030c.txt ru030c_87
Get-Contents ru030c_87| Out-Printer
Remove-Item ru030d_87
Move-Item ru030d.txt ru030d_87
Get-Contents ru030d_87| Out-Printer
Get-Contents ru030e_87| Out-Printer
Remove-Item ru030f_87
Move-Item ru030f.txt ru030f_87
#lp ru030f_87
Remove-Item r997_87
Move-Item r997.txt r997_87
#lp r997_87

Set-Location $application_production\88
#lp u030_88.ls
Remove-Item ru030a_88
Move-Item ru030a.txt ru030a_88
Get-Contents ru030a_88| Out-Printer
Remove-Item ru030b_88
Move-Item ru030b.txt ru030b_88
Get-Contents ru030b_88| Out-Printer
Remove-Item ru030c_88
Move-Item ru030c.txt ru030c_88
Get-Contents ru030c_88| Out-Printer
Remove-Item ru030d_88
Move-Item ru030d.txt ru030d_88
Get-Contents ru030d_88| Out-Printer
Remove-Item ru030e_88
Move-Item ru030e.txt ru030e_88
Get-Contents ru030e_88| Out-Printer
Remove-Item ru030f_88
Move-Item ru030f.txt ru030f_88
#lp ru030f_88
Remove-Item r997_88
Move-Item r997.txt r997_88
#lp r997_88

Set-Location $application_production\89
#lp u030_89.ls
Remove-Item ru030a_89
Move-Item ru030a.txt ru030a_89
Get-Contents ru030a_89| Out-Printer
Remove-Item ru030b_89
Move-Item ru030b.txt ru030b_89
Get-Contents ru030b_89| Out-Printer
Remove-Item ru030c_89
Move-Item ru030c.txt ru030c_89
Get-Contents ru030c_89| Out-Printer
Remove-Item ru030d_89
Move-Item ru030d.txt ru030d_89
Get-Contents ru030d_89| Out-Printer
Get-Contents ru030e_89| Out-Printer
Remove-Item ru030f_89
Move-Item ru030f.txt ru030f_89
#lp ru030f_89
Remove-Item r997_89
Move-Item r997.txt r997_89
#lp r997_89

Set-Location $application_production\91
#lp u030_91.ls
Remove-Item ru030a_91
Move-Item ru030a.txt ru030a_91
Get-Contents ru030a_91| Out-Printer
Remove-Item u030b_91
Move-Item ru030b.txt ru030b_91
Get-Contents ru030b_91| Out-Printer
Remove-Item ru030c_91
Move-Item ru030c.txt ru030c_91
Get-Contents ru030c_91| Out-Printer
Remove-Item ru030d_91
Move-Item ru030d.txt ru030d_91
Get-Contents ru030d_91| Out-Printer
Remove-Item ru030e_91
Move-Item ru030e.txt ru030e_91
Get-Contents ru030e_91| Out-Printer
Remove-Item ru030f_91
Move-Item ru030f.txt ru030f_91
#lp ru030f_91
Remove-Item r997_91
Move-Item r997.txt r997_91
#lp r997_91
#lp r997_paid.txt

echo ""

Set-Location $application_production\92
#lp u030_92.ls
Remove-Item ru030a_92
Move-Item ru030a.txt ru030a_92
Get-Contents ru030a_92| Out-Printer
Remove-Item u030b_92
Move-Item ru030b.txt ru030b_92
Get-Contents ru030b_92| Out-Printer
Remove-Item ru030c_92
Move-Item ru030c.txt ru030c_92
Get-Contents ru030c_92| Out-Printer
Remove-Item ru030d_92
Move-Item ru030d.txt ru030d_92
Get-Contents ru030d_92| Out-Printer
Remove-Item ru030e_92
Move-Item ru030e.txt ru030e_92
Get-Contents ru030e_92| Out-Printer
Remove-Item ru030f_92
Move-Item ru030f.txt ru030f_92
#lp ru030f_92
Remove-Item r997_92
Move-Item r997.txt r997_92
#lp r997_92
#lp r997_paid.txt

echo ""

Set-Location $application_production\93
#lp u030_93.ls
Remove-Item ru030a_93
Move-Item ru030a.txt ru030a_93
Get-Contents ru030a_93| Out-Printer
Remove-Item u030b_93
Move-Item ru030b.txt ru030b_93
Get-Contents ru030b_93| Out-Printer
Remove-Item ru030c_93
Move-Item ru030c.txt ru030c_93
Get-Contents ru030c_93| Out-Printer
Remove-Item ru030d_93
Move-Item ru030d.txt ru030d_93
Get-Contents ru030d_93| Out-Printer
Remove-Item ru030e_93
Move-Item ru030e.txt ru030e_93
Get-Contents ru030e_93| Out-Printer
Remove-Item ru030f_93
Move-Item ru030f.txt ru030f_93
#lp ru030f_93
Remove-Item r997_93
Move-Item r997.txt r997_93
#lp r997_93
#lp r997_paid.txt

echo ""

Set-Location $application_production\94
#lp u030_94.ls
Remove-Item ru030a_94
Move-Item ru030a.txt ru030a_94
Get-Contents ru030a_94| Out-Printer
Remove-Item u030b_94
Move-Item ru030b.txt ru030b_94
Get-Contents ru030b_94| Out-Printer
Remove-Item ru030c_94
Move-Item ru030c.txt ru030c_94
Get-Contents ru030c_94| Out-Printer
Remove-Item ru030d_94
Move-Item ru030d.txt ru030d_94
Get-Contents ru030d_94| Out-Printer
Remove-Item ru030e_94
Move-Item ru030e.txt ru030e_94
Get-Contents ru030e_94| Out-Printer
Remove-Item ru030f_94
Move-Item ru030f.txt ru030f_94
#lp ru030f_94
Remove-Item r997_94
Move-Item r997.txt r997_94
#lp r997_94
#lp r997_paid.txt

echo ""

Set-Location $application_production\95
#lp u030_95.ls
Remove-Item ru030a_95
Move-Item ru030a.txt ru030a_95
Get-Contents ru030a_95| Out-Printer
Remove-Item u030b_95
Move-Item ru030b.txt ru030b_95
Get-Contents ru030b_95| Out-Printer
Remove-Item ru030c_95
Move-Item ru030c.txt ru030c_95
Get-Contents ru030c_95| Out-Printer
Remove-Item ru030d_95
Move-Item ru030d.txt ru030d_95
Get-Contents ru030d_95| Out-Printer
Remove-Item ru030e_95
Move-Item ru030e.txt ru030e_95
Get-Contents ru030e_95| Out-Printer
Remove-Item ru030f_95
Move-Item ru030f.txt ru030f_95
#lp ru030f_95
Remove-Item r997_95
Move-Item r997.txt r997_95
#lp r997_95
#lp r997_paid.txt

echo ""


Set-Location $application_production\96
#lp u030_96.ls
Remove-Item ru030a_96
Move-Item ru030a.txt ru030a_96
Get-Contents ru030a_96| Out-Printer
Remove-Item u030b_96
Move-Item ru030b.txt ru030b_96
Get-Contents ru030b_96| Out-Printer
Remove-Item ru030c_96
Move-Item ru030c.txt ru030c_96
Get-Contents ru030c_96| Out-Printer
Remove-Item ru030d_96
Move-Item ru030d.txt ru030d_96
Get-Contents ru030d_96| Out-Printer
Remove-Item ru030e_96
Move-Item ru030e.txt ru030e_96
Get-Contents ru030e_96| Out-Printer
Remove-Item ru030f_96
Move-Item ru030f.txt ru030f_96
#lp ru030f_96
Remove-Item r997_96
Move-Item r997.txt r997_96
#lp r997_96
#lp r997_paid.txt
echo ""
Set-Location $application_production\68
#lp u030_68.ls
Remove-Item ru030a_68
Move-Item ru030a.txt ru030a_68
Get-Contents ru030a_68| Out-Printer
Remove-Item ru030b_68
Move-Item ru030b.txt ru030b_68
Get-Contents ru030b_68| Out-Printer
Remove-Item ru030c_68
Move-Item ru030c.txt ru030c_68
Get-Contents ru030c_68| Out-Printer
Remove-Item ru030d_68
Move-Item ru030d.txt ru030d_68
Get-Contents ru030d_68| Out-Printer
Remove-Item ru030e_68
Move-Item ru030e.txt ru030e_68
Get-Contents ru030e_68| Out-Printer
Remove-Item ru030f_68
Move-Item ru030f.txt ru030f_68
#lp ru030f_68
Remove-Item r997_68
Move-Item r997.txt r997_68
#lp r997_68
##lp r997_68
echo ""
Get-Date
echo ""
Set-Location $application_production\69
#lp u030_69.ls
Remove-Item ru030a_69
Move-Item ru030a.txt ru030a_69
Get-Contents ru030a_69| Out-Printer
Remove-Item ru030b_69
Move-Item ru030b.txt ru030b_69
Get-Contents ru030b_69| Out-Printer
Remove-Item ru030c_69
Move-Item ru030c.txt ru030c_69
Get-Contents ru030c_69| Out-Printer
Remove-Item ru030d_69
Move-Item ru030d.txt ru030d_69
Get-Contents ru030d_69| Out-Printer
Remove-Item ru030e_69
Move-Item ru030e.txt ru030e_69
Get-Contents ru030e_69| Out-Printer
Remove-Item ru030f_69
Move-Item ru030f.txt ru030f_69
#lp ru030f_69
Remove-Item r997_69
Move-Item r997.txt r997_69
#lp r997_69
##lp r997_69
echo ""
Get-Date
echo ""
Get-Date
echo ""
echo "TO FINISH THIS RUN  HIT  `"NEWLINE`"  ..."
$garbage = Read-Host
