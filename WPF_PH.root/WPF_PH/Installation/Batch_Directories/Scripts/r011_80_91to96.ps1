#-------------------------------------------------------------------------------
# File 'r011_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r011_80_91to96'
#-------------------------------------------------------------------------------

echo " --- r011.gnt for clinic 37 --- "
$rcmd =  $env:COBOL + "r011 37 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_37
#lp r011_37

echo " --- r011.gnt for clinic 68 --- "
$rcmd =  $env:COBOL + "r011 68 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_68
#lp r011_68

echo " --- r011.gnt for clinic 69 --- "
$rcmd =  $env:COBOL + "r011 69 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_69
#lp r011_69

echo " --- r011.gnt for clinic 78 --- "
$rcmd =  $env:COBOL + "r011 78 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_78
#lp r011_78

echo " --- r011.gnt for clinic 79 --- "
$rcmd =  $env:COBOL + "r011 79 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_79
#lp r011_79

echo " --- r011.gnt for clinic 80 --- "
$rcmd =  $env:COBOL + "r011 80 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_80
#lp r011_80

echo " --- r011.gnt for clinic 84--- "
$rcmd =  $env:COBOL + "r011 84 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_84
#lp r011_84

echo " --- r011.gnt for clinic 87--- "
$rcmd =  $env:COBOL + "r011 87 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_87
#lp r011_87

echo " --- r011.gnt for clinic 88--- "
$rcmd =  $env:COBOL + "r011 88 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_88
#lp r011_88

echo " --- r011.gnt for clinic 89--- "
$rcmd =  $env:COBOL + "r011 89 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_89
#lp r011_89

echo " --- r011.gnt for clinic 91 --- "
$rcmd =  $env:COBOL + "r011 91 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_91
#lp r011_91


echo " --- r011.gnt for clinic 92 --- "
$rcmd =  $env:COBOL + "r011 92 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_92
#lp r011_92


echo " --- r011.gnt for clinic 93 --- "
$rcmd =  $env:COBOL + "r011 93 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_93
#lp r011_93


echo " --- r011.gnt for clinic 94 --- "
$rcmd =  $env:COBOL + "r011 94 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_94
#lp r011_94


echo " --- r011.gnt for clinic 95 --- "
$rcmd =  $env:COBOL + "r011 95 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_95
#lp r011_95


echo " --- r011.gnt for clinic 96 --- "
$rcmd =  $env:COBOL + "r011 96 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_96
#lp r011_96
