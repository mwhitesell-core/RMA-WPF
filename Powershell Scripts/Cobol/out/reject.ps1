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
$cmd\u132 100 $1 DC
echo "Running reject...."
quiz++ $pb_obj\reject
echo "Done .. paging reject.txt report"
Get-Contents reject.txt | Out-Host -paging
