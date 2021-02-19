#-------------------------------------------------------------------------------
# File 'solo_income_summary.ps1'
# Converted to PowerShell by CORE Migration on 2019-08-15 12:12:44
#-------------------------------------------------------------------------------

param(
  [string] $1,
  [string] $2,
  [string] $3,
  [string] $4
)
echo ''
echo 'Enter payment summary EP number start date 1: '
$1 = Read-Host
echo ''
echo 'Enter payment summary EP number end date 1: '
$2 = Read-Host
echo ''
echo 'Enter payment summary EP number start date 2: '
$3 = Read-Host
echo ''
echo 'Enter payment summary EP number end date 2: '
$4 = Read-Host
echo ''
echo "executing solo_income_summary.qts"
echo ''
$rcmd = $env:QTP + "solo_income_summary $1 $2 $3 $4"
Invoke-Expression $rcmd 