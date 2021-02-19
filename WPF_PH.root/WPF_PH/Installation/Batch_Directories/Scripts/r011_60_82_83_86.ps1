#-------------------------------------------------------------------------------
# File 'r011_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r011_60_82_83_86'
#-------------------------------------------------------------------------------

echo " --- r011.gnt for clinic 82 --- "
$rcmd = $env:COBOL + "r011 82 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_82
#lp r011_82

echo " --- r011.gnt for clinic 86--- "
$rcmd = $env:COBOL + "r011 86 Y"
Invoke-Expression $rcmd
Get-ChildItem r011
Move-Item -Force r011 r011_86
#lp r011_86

&$env:cmd\r011_60
&$env:cmd\r011_70
