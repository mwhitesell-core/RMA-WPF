#-------------------------------------------------------------------------------
# File 'r011_22_31to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r011_22_31to48'
#-------------------------------------------------------------------------------

Set-Location $root\alpha\rmabill\rmabill101c\data

echo " --- r011.gnt for clinic 22 --- "
$pipedInput = @"
22
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_22
#lp r011_22

echo " --- r011.gnt for clinic 23 --- "
$pipedInput = @"
23
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_23
#lp r011_23

echo " --- r011.gnt for clinic 24 --- "
$pipedInput = @"
24
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_24
#lp r011_24

echo " --- r011.gnt for clinic 25 --- "
$pipedInput = @"
25
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_25
#lp r011_25

echo " --- r011.gnt for clinic 26 --- "
$pipedInput = @"
26
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_26
#lp r011_26

echo " --- r011.gnt for clinic 30 --- "
$pipedInput = @"
30
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_30
#lp r011_30

echo " --- r011.gnt for clinic 31 --- "
$pipedInput = @"
31
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_31
#lp r011_31

echo " --- r011.gnt for clinic 32 --- "
$pipedInput = @"
32
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_32
#lp r011_32

echo " --- r011.gnt for clinic 33 --- "
$pipedInput = @"
33
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_33
#lp r011_33

echo " --- r011.gnt for clinic 34 --- "
$pipedInput = @"
34
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_34
#lp r011_34

echo " --- r011.gnt for clinic 35 --- "
$pipedInput = @"
35
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_35
#lp r011_35

echo " --- r011.gnt for clinic 36 --- "
$pipedInput = @"
36
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_36
#lp r011_36

echo " --- r011.gnt for clinic 41 --- "
$pipedInput = @"
41
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_41
#lp r011_41

echo " --- r011.gnt for clinic 42 --- "
$pipedInput = @"
42
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_42
#lp r011_42

echo " --- r011.gnt for clinic 43 --- "
$pipedInput = @"
43
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_43
#lp r011_43

echo " --- r011.gnt for clinic 44 --- "
$pipedInput = @"
44
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_44
#lp r011_44

echo " --- r011.gnt for clinic 45 --- "
$pipedInput = @"
45
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_45
#lp r011_45

echo " --- r011.gnt for clinic 46 --- "
$pipedInput = @"
46
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_46
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
$pipedInput = @"
98
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_98
#lp r011_98

Set-Location $root\alpha\rmabill\rmabill101c\production
