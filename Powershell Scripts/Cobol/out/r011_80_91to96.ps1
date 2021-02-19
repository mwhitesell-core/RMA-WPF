#-------------------------------------------------------------------------------
# File 'r011_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r011_80_91to96'
#-------------------------------------------------------------------------------

echo " --- r011.gnt for clinic 37 --- "
$pipedInput = @"
37
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_37
#lp r011_37

echo " --- r011.gnt for clinic 68 --- "
$pipedInput = @"
68
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_68
#lp r011_68

echo " --- r011.gnt for clinic 69 --- "
$pipedInput = @"
69
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_69
#lp r011_69

echo " --- r011.gnt for clinic 78 --- "
$pipedInput = @"
78
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_78
#lp r011_78

echo " --- r011.gnt for clinic 79 --- "
$pipedInput = @"
79
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_79
#lp r011_79

echo " --- r011.gnt for clinic 80 --- "
$pipedInput = @"
80
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_80
#lp r011_80

echo " --- r011.gnt for clinic 84--- "
$pipedInput = @"
84
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_84
#lp r011_84

echo " --- r011.gnt for clinic 87--- "
$pipedInput = @"
87
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_87
#lp r011_87

echo " --- r011.gnt for clinic 88--- "
$pipedInput = @"
88
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_88
#lp r011_88

echo " --- r011.gnt for clinic 89--- "
$pipedInput = @"
89
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_89
#lp r011_89

echo " --- r011.gnt for clinic 91 --- "
$pipedInput = @"
91
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_91
#lp r011_91


echo " --- r011.gnt for clinic 92 --- "
$pipedInput = @"
92
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_92
#lp r011_92


echo " --- r011.gnt for clinic 93 --- "
$pipedInput = @"
93
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_93
#lp r011_93


echo " --- r011.gnt for clinic 94 --- "
$pipedInput = @"
94
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_94
#lp r011_94


echo " --- r011.gnt for clinic 95 --- "
$pipedInput = @"
95
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_95
#lp r011_95


echo " --- r011.gnt for clinic 96 --- "
$pipedInput = @"
96
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_96
#lp r011_96
