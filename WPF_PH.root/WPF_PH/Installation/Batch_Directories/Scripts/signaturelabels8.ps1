#-------------------------------------------------------------------------------
# File 'signaturelabels8.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'signaturelabels8'
#-------------------------------------------------------------------------------
param(
      [string]$1,
      [string]$2,
      [string]$3,
      [string]$4
     )

$rcmd = $env:QUIZ + "signaturelabels ${1} ${2} ${3} ${4}"
Invoke-Expression $rcmd
