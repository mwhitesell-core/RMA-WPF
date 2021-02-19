#-------------------------------------------------------------------------------
# File 'ovpay.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'ovpay'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
Push-Location
&$env:cmd\u132 200 $1 SP

echo "Running ovpay ...."
$rcmd = $env:QUIZ + "ovpay"
invoke-expression $rcmd
echo "Done .. paging ovpay.txt report"
Get-Content ovpay.txt
Pop-Location
