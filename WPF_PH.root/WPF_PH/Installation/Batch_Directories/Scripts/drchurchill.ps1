#-------------------------------------------------------------------------------
# File 'drchurchill.ps1'
# Converted to PowerShell by CORE Migration on 2017-10-01 10:16:47
# Original file name was 'drchurchill'
#-------------------------------------------------------------------------------

$rcmd = $env:QTP +"f050ma1"
invoke-expression $rcmd
$rcmd = $env:QTP+"f050_bi"
invoke-expression $rcmd