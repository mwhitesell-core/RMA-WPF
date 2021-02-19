#-------------------------------------------------------------------------------
# File 't4a_addrlabels2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 't4a_addrlabels2'
#-------------------------------------------------------------------------------
param(
      [string]$1,
      [string]$2,
      [string]$3,
      [string]$4,
      [string]$5,
      [string]$6
     )

$rcmd = $env:QUIZ + "t4a_addrlabels_1 ${1} ${2} ${3} ${4} ${5}"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "t4a_addrlabels_2"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "t4a_addrlabels_3 ${6}"
Invoke-Expression $rcmd
