#-------------------------------------------------------------------------------
# File 'rmachr.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'rmachr'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# file: rmachr - upload RMACHR to f113 in payroll
# 2007/jan/09 b.e. added new param to u132 call
$cmd\u132 100 $1 DC
echo "Running maryrmachr ..."
quiz++ $pb_obj\maryrmachr
echo "Done .. paging rmachr.txt report"
Get-Contents rmachr.txt | Out-Host -paging
