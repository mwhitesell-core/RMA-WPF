#-------------------------------------------------------------------------------
# File 'spepre.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'spepre'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
$cmd\u132 200 $1 SP
echo "Running spepre ...."
quiz++ $pb_obj\spepre
echo "Done .. paging spepre.txt"
Get-Contents spepre.txt | Out-Host -paging
