#-------------------------------------------------------------------------------
# File 'copy_u030_rec_67.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'copy_u030_rec_67'
#-------------------------------------------------------------------------------

# macro: copy_u030_rec_67
# 07/Feb/08 M.C. copy all u030-tape-67-file from each clinic directory into production
# 2009/Jul/09 Yas. - Added clinics 78 79 and 88
# 2013/May/16 MC1  - exec $obj/r031b_agep.qzu for 2 passes instead of $obj/r031b_agep.qzc

Set-Location $application_production
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
22
"@

$pipedInput | quiz++

echo "Current Directory:"
Get-Location

echo ""
echo "append 67  file from each clinic into production r031_agep subfile"
echo ""

Set-Location $application_production\23
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
23
"@

$pipedInput | quiz++

Set-Location $application_production\24
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
24
"@

$pipedInput | quiz++

Set-Location $application_production\25
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
25
"@

$pipedInput | quiz++

Set-Location $application_production\26
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
26
"@

$pipedInput | quiz++

Set-Location $application_production\30
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
30
"@

$pipedInput | quiz++

Set-Location $application_production\31
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
31
"@

$pipedInput | quiz++

Set-Location $application_production\32
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
32
"@

$pipedInput | quiz++

Set-Location $application_production\33
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
33
"@

$pipedInput | quiz++

Set-Location $application_production\34
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
34
"@

$pipedInput | quiz++

Set-Location $application_production\35
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
35
"@

$pipedInput | quiz++

Set-Location $application_production\36
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
36
"@

$pipedInput | quiz++

Set-Location $application_production\37
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
37
"@

$pipedInput | quiz++

Set-Location $application_production\41
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
41
"@

$pipedInput | quiz++

Set-Location $application_production\42
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
42
"@

$pipedInput | quiz++

Set-Location $application_production\43
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
43
"@

$pipedInput | quiz++

Set-Location $application_production\44
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
44
"@

$pipedInput | quiz++

Set-Location $application_production\45
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
45
"@

$pipedInput | quiz++

Set-Location $application_production\46
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
46
"@

$pipedInput | quiz++

Set-Location $application_production\61
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
61
"@

$pipedInput | quiz++

Set-Location $application_production\62
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
62
"@

$pipedInput | quiz++

Set-Location $application_production\63
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
63
"@

$pipedInput | quiz++

Set-Location $application_production\64
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
64
"@

$pipedInput | quiz++

Set-Location $application_production\65
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
65
"@

$pipedInput | quiz++

Set-Location $application_production\66
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
66
"@

$pipedInput | quiz++

Set-Location $application_production\71
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
71
"@

$pipedInput | quiz++

Set-Location $application_production\72
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
72
"@

$pipedInput | quiz++

Set-Location $application_production\73
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
73
"@

$pipedInput | quiz++

Set-Location $application_production\74
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
74
"@

$pipedInput | quiz++

Set-Location $application_production\75
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
75
"@

$pipedInput | quiz++

Set-Location $application_production\78
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
78
"@

$pipedInput | quiz++

Set-Location $application_production\79
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
79
"@

$pipedInput | quiz++

Set-Location $application_production\84
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
84
"@

$pipedInput | quiz++

Set-Location $application_production\88
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
88
"@

$pipedInput | quiz++

Set-Location $application_production\96
Remove-Item r031a_agep.sf*
$pipedInput = @"
exec $obj/r031a_agep
96
"@

$pipedInput | quiz++


Set-Location $application_production
quiz++ $obj\r031b_agep

echo ""
echo "end of the run"
echo ""
Get-Date
