#-------------------------------------------------------------------------------
# File 'prod_tithe.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'prod_tithe'
#-------------------------------------------------------------------------------

$rcmd = $env:QTP + "prodtithe"
invoke-expression $rcmd
