#-------------------------------------------------------------------------------
# File 'clirep.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'clirep'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: ltd - upload postgrad     to f114 in payroll
# 2007/feb/12 added new param to u132 call
$cmd\u132 200 $1 SP
echo "Running maryclirep.."
quiz++ $pb_obj\maryclirep
echo "Done .. paging clirep.txt report"
Get-Contents clirep.txt | Out-Host -paging
