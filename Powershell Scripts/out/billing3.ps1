#-------------------------------------------------------------------------------
# File 'billing3.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'billing3'
#-------------------------------------------------------------------------------
param(
      [string]$1,
      [string]$2,
      [string]$3,
      [string]$4,
      [string]$5
     )

$rcmd = $env:QUIZ + "billinglist DISC_billinglist.rf ${1} ${2} ${3} ${4} ${5}" 
Invoke-Expression $rcmd
