#-------------------------------------------------------------------------------
# File 'gstrej.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'gstrej'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: gsttax - upload gsttax to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call
$cmd\u132 100 $1 DC
echo "Running gstrej ..."
quiz++ $pb_obj\gstrej
echo "Done .. paging gstrej.txt report"
Get-Contents gstrej.txt | Out-Host -paging
