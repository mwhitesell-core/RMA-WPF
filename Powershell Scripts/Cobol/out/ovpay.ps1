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
$cmd\u132 200 $1 SP
echo "Running ovpay ...."
quiz++ $pb_obj\ovpay
echo "Done .. paging ovpay.txt report"
Get-Contents ovpay.txt | Out-Host -paging
