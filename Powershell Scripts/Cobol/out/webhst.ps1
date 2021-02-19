#-------------------------------------------------------------------------------
# File 'webhst.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'webhst'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: gsttax - upload gsttax to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call
$cmd\u132 100 $1 DC
echo "Running webhst ..."
quiz++ $pb_obj\webhst
echo "Done .. paging webhst.txt report"
Get-Contents webhst.txt | Out-Host -paging
