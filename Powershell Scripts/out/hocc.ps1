#-------------------------------------------------------------------------------
# File 'hocc.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'hocc'
#-------------------------------------------------------------------------------

# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call

param(
  [string] $1
)

Push-Location
&$env:cmd\u132 200 $1 SP
echo "Running hocc........"
$rcmd = $env:QUIZ + "hocc"
Invoke-Expression $rcmd
echo "Done .. paging hocc.txt report"
Get-Content hocc.txt
Pop-Location