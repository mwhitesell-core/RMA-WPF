#-------------------------------------------------------------------------------
# File 'u020.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u020'
#-------------------------------------------------------------------------------

# U020
Set-Location $env:application_production
#CORE - PowerHouse use file on UNIX, split into each QTP
$rcmd = $env:QTP + "u020b"
Invoke-Expression $rcmd
$rcmd = $env:QTP + "u020c"
Invoke-Expression $rcmd
#$rcmd = $env:QUIZ + "r020
$rcmd = $env:QUIZ + "r020a2"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r020a3"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r020a3.txt > ru020mr.txt

$rcmd = $env:QUIZ + "r020d"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r020d.txt > ru020a.txt

$rcmd = $env:QUIZ + "r020e1"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r020e2"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r020e3"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r020e4"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r020e5"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r020e5.txt > ru020b_d.txt

$rcmd = $env:QUIZ + "r020e6"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r020e6.txt > ru020b_s.txt

$rcmd = $env:QUIZ + "r020f"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r020f.txt > ru020c.txt
