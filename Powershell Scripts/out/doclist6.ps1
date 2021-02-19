#-------------------------------------------------------------------------------
# File 'doclist6.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'doclist6'
#-------------------------------------------------------------------------------
param(
      [string]$1,
      [string]$2,
      [string]$3,
      [string]$4,
      [string]$5,
      [string]$6,
      [string]$7,
      [string]$8
     )

$rcmd = $env:QUIZ + "doctorlist ${1} ${2} ${3} ${4} ${5} ${6} ${7} ${8}"
Invoke-Expression $rcmd