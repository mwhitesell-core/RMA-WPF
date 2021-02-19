#-------------------------------------------------------------------------------
# File 'r011_60.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r011_60'
#-------------------------------------------------------------------------------

$rcmd = $env:QUIZ + "r011a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r011c"
Invoke-Expression $rcmd

Get-Content r011b.txt, r011c.txt | Add-Content r011a.txt
Move-Item -Force r011a.txt r011_60
