#-------------------------------------------------------------------------------
# File 'bridge.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'bridge'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running bridge ...."
$rcmd = $env:QUIZ + "bridge"
Invoke-Expression $rcmd
echo "Done .. paging bridge.txt report"
Get-Content bridge.txt
Pop-Location