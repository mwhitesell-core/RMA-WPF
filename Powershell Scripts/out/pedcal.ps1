#-------------------------------------------------------------------------------
# File 'pedcal.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'pedcal'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running pedcal.."
$rcmd = $env:QUIZ + "pedcal"
Invoke-Expression $rcmd
echo "Done .. paging pedcal.txt report"
Get-Content pedcal.txt
Pop-Location