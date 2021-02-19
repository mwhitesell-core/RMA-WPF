#-------------------------------------------------------------------------------
# File 'dump_tech.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'dump_tech'
#-------------------------------------------------------------------------------

# dump_tech
# dump suspend dtl recs with non-zero priced tech fees

Remove-Item dump_tech.txt *> $null
$rcmd = $env:QUIZ + "dump_tech1"
Invoke-Expression $rcmd
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "dump_tech2 DISC_dump_tech.rf"

Get-Content dump_tech.txt | Out-Printer *> $null
