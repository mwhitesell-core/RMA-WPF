#-------------------------------------------------------------------------------
# File 'docrev.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'docrev'
#-------------------------------------------------------------------------------

$rcmd = $env:QUIZ + "docrev DISC_docrev.rf"
Invoke-Expression $rcmd > docrev.log
