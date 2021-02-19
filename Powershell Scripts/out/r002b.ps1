#-------------------------------------------------------------------------------
# File 'r002b.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r002b'
#-------------------------------------------------------------------------------

Set-Location $env:application_production

$rcmd = $env:COBOL + "r002b"
Invoke-Expression $rcmd
