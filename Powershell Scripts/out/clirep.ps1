#-------------------------------------------------------------------------------
# File 'clirep.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'clirep'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running maryclirep.."
$rcmd = $env:QUIZ + "maryclirep"
Invoke-Expression $rcmd

#Core - Added to rename report according to quiz file
Get-Content maryclirep.txt > clirep.txt

echo "Done .. paging clirep.txt report"
Get-Content clirep.txt
Pop-Location