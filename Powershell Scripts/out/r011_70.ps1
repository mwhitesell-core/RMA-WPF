#-------------------------------------------------------------------------------
# File 'r011_70.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r011_70'
#-------------------------------------------------------------------------------

$rcmd = $env:QUIZ + "r011a_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011b_70"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011c_70"
Invoke-Expression $rcmd

Get-Content r011b_70.txt, r011c_70.txt | Add-Content r011a_70.txt
Move-Item -Force r011a_70.txt r011_70
