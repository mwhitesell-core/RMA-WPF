#-------------------------------------------------------------------------------
# File 'appl_of_rat_22_to_48_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'appl_of_rat_22_to_48_part2'
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

Set-Location $application_production

#lp u030.ls
Remove-Item ru030a_22
Move-Item ru030a.txt ru030a_22
Get-Contents ru030a_22| Out-Printer
Remove-Item ru030b_22
Move-Item ru030b.txt ru030b_22
Get-Contents ru030b_22| Out-Printer
Remove-Item ru030c_22
Move-Item ru030c.txt ru030c_22
Get-Contents ru030c_22| Out-Printer
Remove-Item ru030d_22
Move-Item ru030d.txt ru030d_22
Get-Contents ru030d_22| Out-Printer
Remove-Item ru030e_22
Move-Item ru030e.txt ru030e_22
Get-Contents ru030e_22| Out-Printer
Remove-Item ru030f_22
Move-Item ru030f.txt ru030f_22
#lp ru030f_22
Remove-Item r997_22
Move-Item r997.txt r997_22
#lp r997_22

echo ""

Set-Location $application_production\23

#lp u030.ls
Remove-Item ru030a_23
Move-Item ru030a.txt ru030a_23
Get-Contents ru030a_23| Out-Printer
Remove-Item ru030b_23
Move-Item ru030b.txt ru030b_23
Get-Contents ru030b_23| Out-Printer
Remove-Item ru030c_23
Move-Item ru030c.txt ru030c_23
Get-Contents ru030c_23| Out-Printer
Remove-Item ru030d_23
Move-Item ru030d.txt ru030d_23
Get-Contents ru030d_23| Out-Printer
Remove-Item ru030e_23
Move-Item ru030e.txt ru030e_23
Get-Contents ru030e_23| Out-Printer
Remove-Item ru030f_23
Move-Item ru030f.txt ru030f_23
#lp ru030f_23
Remove-Item r997_23
Move-Item r997.txt r997_23
#lp r997_23

echo ""

Set-Location $application_production\24
#lp u030.ls
Remove-Item ru030a_24
Move-Item ru030a.txt ru030a_24
Get-Contents ru030a_24| Out-Printer
Remove-Item ru030b_24
Move-Item ru030b.txt ru030b_24
Get-Contents ru030b_24| Out-Printer
Remove-Item ru030c_24
Move-Item ru030c.txt ru030c_24
Get-Contents ru030c_24| Out-Printer
Remove-Item ru030d_24
Move-Item ru030d.txt ru030d_24
Get-Contents ru030d_24| Out-Printer
Remove-Item ru030e_24
Move-Item ru030e.txt ru030e_24
Get-Contents ru030e_24| Out-Printer
Remove-Item ru030f_24
Move-Item ru030f.txt ru030f_24
#lp ru030f_24
Remove-Item r997_24
Move-Item r997.txt r997_24
#lp r997_24

echo ""
Set-Location $application_production\25
#lp u030.ls
Remove-Item ru030a_25
Move-Item ru030a.txt ru030a_25
Get-Contents ru030a_25| Out-Printer
Remove-Item ru030b_25
Move-Item ru030b.txt ru030b_25
Get-Contents ru030b_25| Out-Printer
Remove-Item ru030c_25
Move-Item ru030c.txt ru030c_25
Get-Contents ru030c_25| Out-Printer
Remove-Item ru030d_25
Move-Item ru030d.txt ru030d_25
Get-Contents ru030d_25| Out-Printer
Remove-Item ru030e_25
Move-Item ru030e.txt ru030e_25
Get-Contents ru030e_25| Out-Printer
Remove-Item ru030f_25
Move-Item ru030f.txt ru030f_25
#lp ru030f_25
Remove-Item r997_25
Move-Item r997.txt r997_25
#lp r997_25

echo ""
Set-Location $application_production\26
#lp u030.ls
Remove-Item ru030a_26
Move-Item ru030a.txt ru030a_26
Get-Contents ru030a_26| Out-Printer
Remove-Item ru030b_26
Move-Item ru030b.txt ru030b_26
Get-Contents ru030b_26| Out-Printer
Remove-Item ru030c_26
Move-Item ru030c.txt ru030c_26
Get-Contents ru030c_26| Out-Printer
Remove-Item ru030d_26
Move-Item ru030d.txt ru030d_26
Get-Contents ru030d_26| Out-Printer
Remove-Item ru030e_26
Move-Item ru030e.txt ru030e_26
Get-Contents ru030e_26| Out-Printer
Remove-Item ru030f_26
Move-Item ru030f.txt ru030f_26
#lp ru030f_26
Remove-Item r997_26
Move-Item r997.txt r997_26
#lp r997_26

echo ""
Set-Location $application_production\30
#lp u030.ls
Remove-Item ru030a_30
Move-Item ru030a.txt ru030a_30
Get-Contents ru030a_30| Out-Printer
Remove-Item ru030b_30
Move-Item ru030b.txt ru030b_30
Get-Contents ru030b_30| Out-Printer
Remove-Item ru030c_30
Move-Item ru030c.txt ru030c_30
Get-Contents ru030c_30| Out-Printer
Remove-Item ru030d_30
Move-Item ru030d.txt ru030d_30
Get-Contents ru030d_30| Out-Printer
Remove-Item ru030e_30
Move-Item ru030e.txt ru030e_30
Get-Contents ru030e_30| Out-Printer
Remove-Item ru030f_30
Move-Item ru030f.txt ru030f_30
#lp ru030f_30
Remove-Item r997_30
Move-Item r997.txt r997_30
#lp r997_30

echo ""
Set-Location $application_production\31
#lp u030.ls
Remove-Item ru030a_31
Move-Item ru030a.txt ru030a_31
Get-Contents ru030a_31| Out-Printer
Remove-Item ru030b_31
Move-Item ru030b.txt ru030b_31
Get-Contents ru030b_31| Out-Printer
Remove-Item ru030c_31
Move-Item ru030c.txt ru030c_31
Get-Contents ru030c_31| Out-Printer
Remove-Item ru030d_31
Move-Item ru030d.txt ru030d_31
Get-Contents ru030d_31| Out-Printer
Remove-Item ru030e_31
Move-Item ru030e.txt ru030e_31
Get-Contents ru030e_31| Out-Printer
Remove-Item ru030f_31
Move-Item ru030f.txt ru030f_31
#lp ru030f_31
Remove-Item r997_31
Move-Item r997.txt r997_31
#lp r997_31

echo ""
Set-Location $application_production\32

#lp u030.ls
Remove-Item ru030a_32
Move-Item ru030a.txt ru030a_32
Get-Contents ru030a_32| Out-Printer
Remove-Item ru030b_32
Move-Item ru030b.txt ru030b_32
Get-Contents ru030b_32| Out-Printer
Remove-Item ru030c_32
Move-Item ru030c.txt ru030c_32
Get-Contents ru030c_32| Out-Printer
Remove-Item ru030d_32
Move-Item ru030d.txt ru030d_32
Get-Contents ru030d_32| Out-Printer
Remove-Item ru030e_32
Move-Item ru030e.txt ru030e_32
Get-Contents ru030e_32| Out-Printer
Remove-Item ru030f_32
Move-Item ru030f.txt ru030f_32
#lp ru030f_32
Remove-Item r997_32
Move-Item r997.txt r997_32
#lp r997_32

echo ""

Set-Location $application_production\33

#lp u030.ls
Remove-Item ru030a_33
Move-Item ru030a.txt ru030a_33
Get-Contents ru030a_33| Out-Printer
Remove-Item ru030b_33
Move-Item ru030b.txt ru030b_33
Get-Contents ru030b_33| Out-Printer
Remove-Item ru030c_33
Move-Item ru030c.txt ru030c_33
Get-Contents ru030c_33| Out-Printer
Remove-Item ru030d_33
Move-Item ru030d.txt ru030d_33
Get-Contents ru030d_33| Out-Printer
Remove-Item ru030e_33
Move-Item ru030e.txt ru030e_33
Get-Contents ru030e_33| Out-Printer
Remove-Item ru030f_33
Move-Item ru030f.txt ru030f_33
#lp ru030f_33
Remove-Item r997_33
Move-Item r997.txt r997_33
#lp r997_33

echo ""

Set-Location $application_production\34

#lp u030.ls
Remove-Item ru030a_34
Move-Item ru030a.txt ru030a_34
Get-Contents ru030a_34| Out-Printer
Remove-Item ru030b_34
Move-Item ru030b.txt ru030b_34
Get-Contents ru030b_34| Out-Printer
Remove-Item ru030c_34
Move-Item ru030c.txt ru030c_34
Get-Contents ru030c_34| Out-Printer
Remove-Item ru030d_34
Move-Item ru030d.txt ru030d_34
Get-Contents ru030d_34| Out-Printer
Remove-Item ru030e_34
Move-Item ru030e.txt ru030e_34
Get-Contents ru030e_34| Out-Printer
Remove-Item ru030f_34
Move-Item ru030f.txt ru030f_34
#lp ru030f_34
Remove-Item r997_34
Move-Item r997.txt r997_34
#lp r997_34

echo ""

Set-Location $application_production\35

#lp u030.ls
Remove-Item ru030a_35
Move-Item ru030a.txt ru030a_35
Get-Contents ru030a_35| Out-Printer
Remove-Item ru030b_35
Move-Item ru030b.txt ru030b_35
Get-Contents ru030b_35| Out-Printer
Remove-Item ru030c_35
Move-Item ru030c.txt ru030c_35
Get-Contents ru030c_35| Out-Printer
Remove-Item ru030d_35
Move-Item ru030d.txt ru030d_35
Get-Contents ru030d_35| Out-Printer
Remove-Item ru030e_35
Move-Item ru030e.txt ru030e_35
Get-Contents ru030e_35| Out-Printer
Remove-Item ru030f_35
Move-Item ru030f.txt ru030f_35
#lp ru030f_35
Remove-Item r997_35
Move-Item r997.txt r997_35
#lp r997_35

echo ""

Set-Location $application_production\36

#lp u030.ls
Remove-Item ru030a_36
Move-Item ru030a.txt ru030a_36
Get-Contents ru030a_36| Out-Printer
Remove-Item ru030b_36
Move-Item ru030b.txt ru030b_36
Get-Contents ru030b_36| Out-Printer
Remove-Item ru030c_36
Move-Item ru030c.txt ru030c_36
Get-Contents ru030c_36| Out-Printer
Remove-Item ru030d_36
Move-Item ru030d.txt ru030d_36
Get-Contents ru030d_36| Out-Printer
Remove-Item ru030e_36
Move-Item ru030e.txt ru030e_36
Get-Contents ru030e_36| Out-Printer
Remove-Item ru030f_36
Move-Item ru030f.txt ru030f_36
#lp ru030f_36
Remove-Item r997_36
Move-Item r997.txt r997_36
#lp r997_36

echo ""

Set-Location $application_production\41

#lp u030.ls
Remove-Item ru030a_41
Move-Item ru030a.txt ru030a_41
Get-Contents ru030a_41| Out-Printer
Remove-Item ru030b_41
Move-Item ru030b.txt ru030b_41
Get-Contents ru030b_41| Out-Printer
Remove-Item ru030c_41
Move-Item ru030c.txt ru030c_41
Get-Contents ru030c_41| Out-Printer
Remove-Item ru030d_41
Move-Item ru030d.txt ru030d_41
Get-Contents ru030d_41| Out-Printer
Remove-Item ru030e_41
Move-Item ru030e.txt ru030e_41
Get-Contents ru030e_41| Out-Printer
Remove-Item ru030f_41
Move-Item ru030f.txt ru030f_41
#lp ru030f_41
Remove-Item r997_41
Move-Item r997.txt r997_41
#lp r997_41

echo ""

Set-Location $application_production\42

#lp u030.ls
Remove-Item ru030a_42
Move-Item ru030a.txt ru030a_42
Get-Contents ru030a_42| Out-Printer
Remove-Item ru030b_42
Move-Item ru030b.txt ru030b_42
Get-Contents ru030b_42| Out-Printer
Remove-Item ru030c_42
Move-Item ru030c.txt ru030c_42
Get-Contents ru030c_42| Out-Printer
Remove-Item ru030d_42
Move-Item ru030d.txt ru030d_42
Get-Contents ru030d_42| Out-Printer
Remove-Item ru030e_42
Move-Item ru030e.txt ru030e_42
Get-Contents ru030e_42| Out-Printer
Remove-Item ru030f_42
Move-Item ru030f.txt ru030f_42
#lp ru030f_42
Remove-Item r997_42
Move-Item r997.txt r997_42
#lp r997_42

echo ""

Set-Location $application_production\43
#lp u030_43.ls
Remove-Item ru030a_43
Move-Item ru030a.txt ru030a_43
Get-Contents ru030a_43| Out-Printer
Remove-Item u030b_43
Move-Item ru030b.txt ru030b_43
Get-Contents ru030b_43| Out-Printer
Remove-Item ru030c_43
Move-Item ru030c.txt ru030c_43
Get-Contents ru030c_43| Out-Printer
Remove-Item ru030d_43
Move-Item ru030d.txt ru030d_43
Get-Contents ru030d_43| Out-Printer
Remove-Item ru030e_43
Move-Item ru030e.txt ru030e_43
Get-Contents ru030e_43| Out-Printer
Remove-Item ru030f_43
Move-Item ru030f.txt ru030f_43
#lp ru030f_43
Remove-Item r997_43
Move-Item r997.txt r997_43
#lp r997_43

echo ""

Set-Location $application_production\44

#lp u030.ls
Remove-Item ru030a_44
Move-Item ru030a.txt ru030a_44
Get-Contents ru030a_44| Out-Printer
Remove-Item ru030b_44
Move-Item ru030b.txt ru030b_44
Get-Contents ru030b_44| Out-Printer
Remove-Item ru030c_44
Move-Item ru030c.txt ru030c_44
Get-Contents ru030c_44| Out-Printer
Remove-Item ru030d_44
Move-Item ru030d.txt ru030d_44
Get-Contents ru030d_44| Out-Printer
Remove-Item ru030e_44
Move-Item ru030e.txt ru030e_44
Get-Contents ru030e_44| Out-Printer
Remove-Item ru030f_44
Move-Item ru030f.txt ru030f_44
#lp ru030f_44
Remove-Item r997_44
Move-Item r997.txt r997_44
#lp r997_44

echo ""

Set-Location $application_production\45

#lp u030.ls
Remove-Item ru030a_45
Move-Item ru030a.txt ru030a_45
Get-Contents ru030a_45| Out-Printer
Remove-Item ru030b_45
Move-Item ru030b.txt ru030b_45
Get-Contents ru030b_45| Out-Printer
Remove-Item ru030c_45
Move-Item ru030c.txt ru030c_45
Get-Contents ru030c_45| Out-Printer
Remove-Item ru030d_45
Move-Item ru030d.txt ru030d_45
Get-Contents ru030d_45| Out-Printer
Remove-Item ru030e_45
Move-Item ru030e.txt ru030e_45
Get-Contents ru030e_45| Out-Printer
Remove-Item ru030f_45
Move-Item ru030f.txt ru030f_45
#lp ru030f_45
Remove-Item r997_45
Move-Item r997.txt r997_45
#lp r997_45

echo ""

Set-Location $application_production\46

#lp u030.ls
Remove-Item ru030a_46
Move-Item ru030a.txt ru030a_46
Get-Contents ru030a_46| Out-Printer
Remove-Item ru030b_46
Move-Item ru030b.txt ru030b_46
Get-Contents ru030b_46| Out-Printer
Remove-Item ru030c_46
Move-Item ru030c.txt ru030c_46
Get-Contents ru030c_46| Out-Printer
Remove-Item ru030d_46
Move-Item ru030d.txt ru030d_46
Get-Contents ru030d_46| Out-Printer
Remove-Item ru030e_46
Move-Item ru030e.txt ru030e_46
Get-Contents ru030e_46| Out-Printer
Remove-Item ru030f_46
Move-Item ru030f.txt ru030f_46
#lp ru030f_46
Remove-Item r997_46
Move-Item r997.txt r997_46
#lp r997_46

echo ""

Set-Location $application_production\48

#lp u030.ls
Remove-Item ru030a_48
Move-Item ru030a.txt ru030a_48
Get-Contents ru030a_48| Out-Printer
Remove-Item ru030b_48
Move-Item ru030b.txt ru030b_48
Get-Contents ru030b_48| Out-Printer
Remove-Item ru030c_48
Move-Item ru030c.txt ru030c_48
Get-Contents ru030c_48| Out-Printer
Remove-Item ru030d_48
Move-Item ru030d.txt ru030d_48
Get-Contents ru030d_48| Out-Printer
Remove-Item ru030e_48
Move-Item ru030e.txt ru030e_48
Get-Contents ru030e_48| Out-Printer
Remove-Item ru030f_48
Move-Item ru030f.txt ru030f_48
#lp ru030f_48
Remove-Item r997_48
Move-Item r997.txt r997_48
#lp r997_48

echo ""

Get-Date
Set-Location $application_production

echo "TO FINISH THIS RUN  HIT  `"NEWLINE`"  ..."
$garbage = Read-Host
