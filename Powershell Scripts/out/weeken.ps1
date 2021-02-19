#-------------------------------------------------------------------------------
# File 'weeken.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'weeken'
#-------------------------------------------------------------------------------

param(
  [string] $1
)
Push-Location
# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
&$env:cmd\u132 200 $1 SP
echo "Running weeken.."
$rcmd = $env:QUIZ + "weeken"
Invoke-Expression $rcmd
echo "Done .. paging weeken.txt report"
Get-Content weeken.txt
Pop-Location