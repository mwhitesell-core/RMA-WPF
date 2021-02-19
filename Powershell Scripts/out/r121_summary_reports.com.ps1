#-------------------------------------------------------------------------------
# File 'r121_summary_reports.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r121_summary_reports.com'
#-------------------------------------------------------------------------------

# 2015/Jan/19   MC   $cmd/r121_summary_reports.com

param(  
  [string] $1,
  [string] $2,
  [string] $3,
  [string] $4
)
echo ' '
echo 'enter ep nbr: '
$1 = Read-Host
echo ' '
echo 'enter ep nbr: '
$2 = Read-Host
echo ' '
echo 'enter ep nbr: '
$3 = Read-Host
echo ''
echo 'enter calendar year: '
$4 = Read-Host
echo ''

Set-Location $env:application_root\production ; Get-Location

echo "r121_summary_reports.com  -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > r121_summary_reports.log

# you must define the calendar year below as the parameter
&$env:cmd\r121_summary_reports $1 $2 $3 $4 >> r121_summary_reports.log

echo "r121_summary_reports.com - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> r121_summary_reports.log
