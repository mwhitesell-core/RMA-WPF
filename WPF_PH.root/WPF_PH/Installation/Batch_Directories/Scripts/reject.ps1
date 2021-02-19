#-------------------------------------------------------------------------------
# File 'reject.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'reject'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: gsttax - upload gsttax to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call

Push-Location
echo "FROM EP NBR (YYYYMM): "
$2 = Read-Host

echo "TO  EP NBR (YYYYMM): "
$3 = Read-Host
 
&$env:cmd\u132 100 $1 DC
echo "Running reject...."
$rcmd = $env:QUIZ + "reject $2 $3"
invoke-expression $rcmd
echo "Done .. paging reject.txt report"
Get-Content reject.txt
Pop-Location