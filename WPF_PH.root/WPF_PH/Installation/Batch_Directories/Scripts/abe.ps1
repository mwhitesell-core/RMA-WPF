#-------------------------------------------------------------------------------
# File 'abe.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'abe'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running abe"
$rcmd = $env:QUIZ + "abe"
Invoke-Expression $rcmd
echo "Done .. paging abe.txt report"
Get-Content abe.txt
Pop-Location
