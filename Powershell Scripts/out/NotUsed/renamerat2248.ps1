#-------------------------------------------------------------------------------
# File 'renamerat2248.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'renamerat2248'
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

Set-Location $env:application_production

##lp u030.ls
Remove-Item ru030a_22
Move-Item -Force ru030a.txt ru030a_22
#lp ru030a_22
Remove-Item ru030b_22
Move-Item -Force ru030b.txt ru030b_22
##lp ru030b_22
Remove-Item ru030c_22
Move-Item -Force ru030c.txt ru030c_22
##lp ru030c_22
Remove-Item ru030d_22
Move-Item -Force ru030d.txt ru030d_22
#lp ru030d_22
Remove-Item ru030e_22
Move-Item -Force ru030e.txt ru030e_22
#lp ru030e_22
Remove-Item ru030f_22
Move-Item -Force ru030f.txt ru030f_22
##lp ru030f_22
Remove-Item r997_22
Move-Item -Force r997.txt r997_22
#lp r997_22

echo ""

Set-Location $env:application_production\31

##lp u030.ls
Remove-Item ru030a_31
Move-Item -Force ru030a.txt ru030a_31
#lp ru030a_31
Remove-Item ru030b_31
Move-Item -Force ru030b.txt ru030b_31
##lp ru030b_31
Remove-Item ru030c_31
Move-Item -Force ru030c.txt ru030c_31
##lp ru030c_31
Remove-Item ru030d_31
Move-Item -Force ru030d.txt ru030d_31
#lp ru030d_31
Remove-Item ru030e_31
Move-Item -Force ru030e.txt ru030e_31
#lp ru030e_31
Remove-Item ru030f_31
Move-Item -Force ru030f.txt ru030f_31
##lp ru030f_31
Remove-Item r997_31
Move-Item -Force r997.txt r997_31
#lp r997_31

echo ""

Set-Location $env:application_production\32

##lp u030.ls
Remove-Item ru030a_32
Move-Item -Force ru030a.txt ru030a_32
#lp ru030a_32
Remove-Item ru030b_32
Move-Item -Force ru030b.txt ru030b_32
##lp ru030b_32
Remove-Item ru030c_32
Move-Item -Force ru030c.txt ru030c_32
##lp ru030c_32
Remove-Item ru030d_32
Move-Item -Force ru030d.txt ru030d_32
#lp ru030d_32
Remove-Item ru030e_32
Move-Item -Force ru030e.txt ru030e_32
#lp ru030e_32
Remove-Item ru030f_32
Move-Item -Force ru030f.txt ru030f_32
##lp ru030f_32
Remove-Item r997_32
Move-Item -Force r997.txt r997_32
#lp r997_32

echo ""

Set-Location $env:application_production\33

##lp u030.ls
Remove-Item ru030a_33
Move-Item -Force ru030a.txt ru030a_33
#lp ru030a_33
Remove-Item ru030b_33
Move-Item -Force ru030b.txt ru030b_33
##lp ru030b_33
Remove-Item ru030c_33
Move-Item -Force ru030c.txt ru030c_33
##lp ru030c_33
Remove-Item ru030d_33
Move-Item -Force ru030d.txt ru030d_33
#lp ru030d_33
Remove-Item ru030e_33
Move-Item -Force ru030e.txt ru030e_33
#lp ru030e_33
Remove-Item ru030f_33
Move-Item -Force ru030f.txt ru030f_33
##lp ru030f_33
Remove-Item r997_33
Move-Item -Force r997.txt r997_33
#lp r997_33

echo ""

Set-Location $env:application_production\34

##lp u030.ls
Remove-Item ru030a_34
Move-Item -Force ru030a.txt ru030a_34
#lp ru030a_34
Remove-Item ru030b_34
Move-Item -Force ru030b.txt ru030b_34
##lp ru030b_34
Remove-Item ru030c_34
Move-Item -Force ru030c.txt ru030c_34
##lp ru030c_34
Remove-Item ru030d_34
Move-Item -Force ru030d.txt ru030d_34
#lp ru030d_34
Remove-Item ru030e_34
Move-Item -Force ru030e.txt ru030e_34
#lp ru030e_34
Remove-Item ru030f_34
Move-Item -Force ru030f.txt ru030f_34
##lp ru030f_34
Remove-Item r997_34
Move-Item -Force r997.txt r997_34
#lp r997_34

echo ""

Set-Location $env:application_production\35

##lp u030.ls
Remove-Item ru030a_35
Move-Item -Force ru030a.txt ru030a_35
#lp ru030a_35
Remove-Item ru030b_35
Move-Item -Force ru030b.txt ru030b_35
##lp ru030b_35
Remove-Item ru030c_35
Move-Item -Force ru030c.txt ru030c_35
##lp ru030c_35
Remove-Item ru030d_35
Move-Item -Force ru030d.txt ru030d_35
#lp ru030d_35
Remove-Item ru030e_35
Move-Item -Force ru030e.txt ru030e_35
#lp ru030e_35
Remove-Item ru030f_35
Move-Item -Force ru030f.txt ru030f_35
##lp ru030f_35
Remove-Item r997_35
Move-Item -Force r997.txt r997_35
#lp r997_35

echo ""

Set-Location $env:application_production\36

##lp u030.ls
Remove-Item ru030a_36
Move-Item -Force ru030a.txt ru030a_36
#lp ru030a_36
Remove-Item ru030b_36
Move-Item -Force ru030b.txt ru030b_36
##lp ru030b_36
Remove-Item ru030c_36
Move-Item -Force ru030c.txt ru030c_36
##lp ru030c_36
Remove-Item ru030d_36
Move-Item -Force ru030d.txt ru030d_36
#lp ru030d_36
Remove-Item ru030e_36
Move-Item -Force ru030e.txt ru030e_36
#lp ru030e_36
Remove-Item ru030f_36
Move-Item -Force ru030f.txt ru030f_36
##lp ru030f_36
Remove-Item r997_36
Move-Item -Force r997.txt r997_36
#lp r997_36

echo ""

Set-Location $env:application_production\41

##lp u030.ls
Remove-Item ru030a_41
Move-Item -Force ru030a.txt ru030a_41
#lp ru030a_41
Remove-Item ru030b_41
Move-Item -Force ru030b.txt ru030b_41
##lp ru030b_41
Remove-Item ru030c_41
Move-Item -Force ru030c.txt ru030c_41
##lp ru030c_41
Remove-Item ru030d_41
Move-Item -Force ru030d.txt ru030d_41
#lp ru030d_41
Remove-Item ru030e_41
Move-Item -Force ru030e.txt ru030e_41
#lp ru030e_41
Remove-Item ru030f_41
Move-Item -Force ru030f.txt ru030f_41
##lp ru030f_41
Remove-Item r997_41
Move-Item -Force r997.txt r997_41
#lp r997_41

echo ""

Set-Location $env:application_production\42

##lp u030.ls
Remove-Item ru030a_42
Move-Item -Force ru030a.txt ru030a_42
#lp ru030a_42
Remove-Item ru030b_42
Move-Item -Force ru030b.txt ru030b_42
##lp ru030b_42
Remove-Item ru030c_42
Move-Item -Force ru030c.txt ru030c_42
##lp ru030c_42
Remove-Item ru030d_42
Move-Item -Force ru030d.txt ru030d_42
#lp ru030d_42
Remove-Item ru030e_42
Move-Item -Force ru030e.txt ru030e_42
#lp ru030e_42
Remove-Item ru030f_42
Move-Item -Force ru030f.txt ru030f_42
##lp ru030f_42
Remove-Item r997_42
Move-Item -Force r997.txt r997_42
#lp r997_42

echo ""

Set-Location $env:application_production\43
##lp u030_43.ls
Remove-Item ru030a_43
Move-Item -Force ru030a.txt ru030a_43
#lp ru030a_43
Remove-Item u030b_43
Move-Item -Force ru030b.txt ru030b_43
#lp ru030b_43
Remove-Item ru030c_43
Move-Item -Force ru030c.txt ru030c_43
#lp ru030c_43
Remove-Item ru030d_43
Move-Item -Force ru030d.txt ru030d_43
#lp ru030d_43
Remove-Item ru030e_43
Move-Item -Force ru030e.txt ru030e_43
#lp ru030e_43
Remove-Item ru030f_43
Move-Item -Force ru030f.txt ru030f_43
##lp ru030f_43
Remove-Item r997_43
Move-Item -Force r997.txt r997_43
#lp r997_43

echo ""

Set-Location $env:application_production\44

##lp u030.ls
Remove-Item ru030a_44
Move-Item -Force ru030a.txt ru030a_44
#lp ru030a_44
Remove-Item ru030b_44
Move-Item -Force ru030b.txt ru030b_44
##lp ru030b_44
Remove-Item ru030c_44
Move-Item -Force ru030c.txt ru030c_44
##lp ru030c_44
Remove-Item ru030d_44
Move-Item -Force ru030d.txt ru030d_44
#lp ru030d_44
Remove-Item ru030e_44
Move-Item -Force ru030e.txt ru030e_44
#lp ru030e_44
Remove-Item ru030f_44
Move-Item -Force ru030f.txt ru030f_44
##lp ru030f_44
Remove-Item r997_44
Move-Item -Force r997.txt r997_44
#lp r997_44

echo ""

Set-Location $env:application_production\45

##lp u030.ls
Remove-Item ru030a_45
Move-Item -Force ru030a.txt ru030a_45
#lp ru030a_45
Remove-Item ru030b_45
Move-Item -Force ru030b.txt ru030b_45
##lp ru030b_45
Remove-Item ru030c_45
Move-Item -Force ru030c.txt ru030c_45
##lp ru030c_45
Remove-Item ru030d_45
Move-Item -Force ru030d.txt ru030d_45
#lp ru030d_45
Remove-Item ru030e_45
Move-Item -Force ru030e.txt ru030e_45
#lp ru030e_45
Remove-Item ru030f_45
Move-Item -Force ru030f.txt ru030f_45
##lp ru030f_45
Remove-Item r997_45
Move-Item -Force r997.txt r997_45
#lp r997_45

echo ""

Set-Location $env:application_production\46

##lp u030.ls
Remove-Item ru030a_46
Move-Item -Force ru030a.txt ru030a_46
#lp ru030a_46
Remove-Item ru030b_46
Move-Item -Force ru030b.txt ru030b_46
##lp ru030b_46
Remove-Item ru030c_46
Move-Item -Force ru030c.txt ru030c_46
##lp ru030c_46
Remove-Item ru030d_46
Move-Item -Force ru030d.txt ru030d_46
#lp ru030d_46
Remove-Item ru030e_46
Move-Item -Force ru030e.txt ru030e_46
#lp ru030e_46
Remove-Item ru030f_46
Move-Item -Force ru030f.txt ru030f_46
##lp ru030f_46
Remove-Item r997_46
Move-Item -Force r997.txt r997_46
#lp r997_46

echo ""

Set-Location $env:application_production\48

##lp u030.ls
Remove-Item ru030a_48
Move-Item -Force ru030a.txt ru030a_48
#lp ru030a_48
Remove-Item ru030b_48
Move-Item -Force ru030b.txt ru030b_48
##lp ru030b_48
Remove-Item ru030c_48
Move-Item -Force ru030c.txt ru030c_48
##lp ru030c_48
Remove-Item ru030d_48
Move-Item -Force ru030d.txt ru030d_48
#lp ru030d_48
Remove-Item ru030e_48
Move-Item -Force ru030e.txt ru030e_48
#lp ru030e_48
Remove-Item ru030f_48
Move-Item -Force ru030f.txt ru030f_48
##lp ru030f_48
Remove-Item r997_48
Move-Item -Force r997.txt r997_48
#lp r997_48

echo ""

Get-Date
Set-Location $env:application_production

echo "TO FINISH THIS RUN  HIT  `"NEWLINE`"  ..."
$garbage = Read-Host
