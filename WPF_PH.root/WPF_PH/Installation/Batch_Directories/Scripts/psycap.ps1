#-------------------------------------------------------------------------------
# File 'psycap.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'psycap'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

Push-Location
# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
&$env:cmd\u132 200 $1 SP
echo "Running psycap.."
$rcmd = $env:QUIZ + "psycap"
Invoke-Expression $rcmd
echo "Done .. paging psycap.txt report"
Get-Content psycap.txt
Pop-Location