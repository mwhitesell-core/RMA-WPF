#-------------------------------------------------------------------------------
# File 'r134_r135_portal.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r134_r135_portal'
#-------------------------------------------------------------------------------

# 2015/Apr/22   MC      include the parameter 'PORTAL' to run r134 & r135 

Set-Location $env:application_root\production

$rcmd = $env:QUIZ + "r134a 20160701 20170630"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r134b PORTAL"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content r134b.txt > r134.txt

$rcmd = $env:QUIZ + "r135a 20160701 20170630"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r135b PORTAL"
Invoke-Expression $rcmd


#Core - Added to rename report according to quiz file
Get-Content r135b.txt > r135.txt