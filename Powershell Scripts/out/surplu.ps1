#-------------------------------------------------------------------------------
# File 'surplu.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'surplu'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

Push-Location
# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
&$env:cmd\u132 200 $1 SP
echo "Running marysurplu.."
$rcmd = $env:QUIZ + "marysurplu"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content marysurplu.txt > surplu.txt

echo "Done .. paging surplu.txt report"
Get-Content surplu.txt
Pop-Location