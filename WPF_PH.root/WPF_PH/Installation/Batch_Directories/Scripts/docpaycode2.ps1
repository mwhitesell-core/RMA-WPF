#-------------------------------------------------------------------------------
# File 'docpaycode2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'docpaycode2'
#-------------------------------------------------------------------------------
param(
      [string]$var0
     )

$rcmd = $env:QUIZ + "docpaycode ${var0}" 
Invoke-Expression $rcmd > $null
