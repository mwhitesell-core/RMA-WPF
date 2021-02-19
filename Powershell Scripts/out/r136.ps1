#-------------------------------------------------------------------------------
# File 'r136.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r136'
#-------------------------------------------------------------------------------

# 2015/Apr/22   MC              include the run of r136.qtc/qzc 

Set-Location $env:application_root\production

$rcmd = $env:QTP + "r136"
Invoke-Expression $rcmd

$rcmd = $env:QUIZ + "r136 DISC_R136.rf"
Invoke-Expression $rcmd
