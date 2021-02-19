#-------------------------------------------------------------------------------
# File 'docrevall.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'docrevall'
#-------------------------------------------------------------------------------

$rcmd = $env:QTP + "docrevall 2015 20160630"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "docrevall"
Invoke-Expression $rcmd
