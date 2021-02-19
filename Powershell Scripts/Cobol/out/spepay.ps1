#-------------------------------------------------------------------------------
# File 'spepay.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'spepay'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload SHIFT to f114 in payroll
# 2007/jan/09 b.e. added new param to u132 call
$cmd\u132 200 $1 SP
echo "Running spepay.."
quiz++ $pb_obj\spepay
echo "Done .. paging spepay.txt report"
Get-Contents spepay.txt | Out-Host -paging
