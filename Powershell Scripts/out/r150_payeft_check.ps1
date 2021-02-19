#-------------------------------------------------------------------------------
# File 'r150_payeft_check.ps1'
# Converted to PowerShell by CORE Migration on 2019-08-15 11:57:52
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2,
  [string] $3,
  [string] $4
)
echo ' '
echo 'Enter payment summary EP starting date for f110-compensation-history: '
$1 = Read-Host
echo ''
echo 'Enter payment summary EP end date for f110-compensation-history: '
$2 = Read-Host
echo ''
echo "executing r150_payeft_check__pass1.qzs"
echo ''
$rcmd = $env:QUIZ + "r150_payeft_check__pass1 $1 $2"
Invoke-Expression $rcmd
echo ''
echo 'Enter payment summary EP starting date for f110-compensation files: '
$3 = Read-Host
echo ''
echo 'Enter payment summary EP end date for f110-compensation files: '
$4 = Read-Host
echo ''
echo "executing r150_payeft_check__pass2.qzs"
echo ''
$rcmd = $env:QUIZ + "r150_payeft_check__pass2 $3 $4"
Invoke-Expression $rcmd
echo ''

echo "executing r150_payeft_check__pass3.qzs"
echo ''
$rcmd = $env:QUIZ + "r150_payeft_check__pass3"
Invoke-Expression $rcmd