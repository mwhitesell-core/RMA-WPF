#-------------------------------------------------------------------------------
# File 'afp_pedsurgery.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'afp_pedsurgery'
#-------------------------------------------------------------------------------

Remove-Item pedsurgery*.sf*
Remove-Item pedsurgery*.ps*

$rcmd = $env:QTP +"pedsurgery"
Invoke-Expression $rcmd
