#-------------------------------------------------------------------------------
# File 'r011_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r011_60_82_83_86'
#-------------------------------------------------------------------------------

echo " --- r011.gnt for clinic 82 --- "
$pipedInput = @"
82
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_82
#lp r011_82

echo " --- r011.gnt for clinic 86--- "
$pipedInput = @"
86
Y
"@

$pipedInput | cobrun++ $obj\r011
Get-ChildItem r011
Move-Item r011 r011_86
#lp r011_86

$cmd\r011_60
$cmd\r011_70
