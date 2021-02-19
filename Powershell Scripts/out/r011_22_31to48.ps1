#-------------------------------------------------------------------------------
# File 'r011_22_31to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r011_22_31to48'
#-------------------------------------------------------------------------------

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data

echo " --- r011.gnt for clinic 22 --- "
$rcmd = $env:COBOL + " r011 22 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_22
#lp r011_22

echo " --- r011.gnt for clinic 23 --- "
$rcmd = $env:COBOL + " r011 23 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_23
#lp r011_23

echo " --- r011.gnt for clinic 24 --- "
$rcmd = $env:COBOL + " r011 24 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_24
#lp r011_24

echo " --- r011.gnt for clinic 25 --- "
$rcmd = $env:COBOL + " r011 25 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_25
#lp r011_25

echo " --- r011.gnt for clinic 26 --- "
$rcmd = $env:COBOL + " r011 26 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_26
#lp r011_26

echo " --- r011.gnt for clinic 30 --- "
$rcmd = $env:COBOL + " r011 30 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_30
#lp r011_30

echo " --- r011.gnt for clinic 31 --- "
$rcmd = $env:COBOL + " r011 31 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_31
#lp r011_31

echo " --- r011.gnt for clinic 32 --- "
$rcmd = $env:COBOL + " r011 32 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_32
#lp r011_32

echo " --- r011.gnt for clinic 33 --- "
$rcmd = $env:COBOL + " r011 33 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_33
#lp r011_33

echo " --- r011.gnt for clinic 34 --- "
$rcmd = $env:COBOL + " r011 34 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_34
#lp r011_34

echo " --- r011.gnt for clinic 35 --- "
$rcmd = $env:COBOL + " r011 35 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_35
#lp r011_35

echo " --- r011.gnt for clinic 36 --- "
$rcmd = $env:COBOL + " r011 36 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_36
#lp r011_36

echo " --- r011.gnt for clinic 41 --- "
$rcmd = $env:COBOL + " r011 41 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_41
#lp r011_41

echo " --- r011.gnt for clinic 42 --- "
$rcmd = $env:COBOL + " r011 42 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_42
#lp r011_42

echo " --- r011.gnt for clinic 43 --- "
$rcmd = $env:COBOL + " r011 43 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_43
#lp r011_43

echo " --- r011.gnt for clinic 44 --- "
$rcmd = $env:COBOL + " r011 44 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_44
#lp r011_44

echo " --- r011.gnt for clinic 45 --- "
$rcmd = $env:COBOL + " r011 45 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_45
#lp r011_45

echo " --- r011.gnt for clinic 46 --- "
$rcmd = $env:COBOL + " r011 46 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_46
#lp r011_45

#echo " --- r011.gnt for clinic 48 --- "
#cobrun $obj/r011 << R011_EXIT
#48
#Y
#R011_EXIT
#ls -l r011
#mv r011 r011_48
#lp r011_48

echo " --- r011.gnt for clinic 98 --- "
$rcmd = $env:COBOL + " r011 98 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_98
#lp r011_98

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production
