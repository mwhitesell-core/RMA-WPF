#-------------------------------------------------------------------------------
# File 'costing_rerun_costing34.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'costing_rerun_costing34.com'
#-------------------------------------------------------------------------------

echo ""
Get-Date
echo ""

Set-Location $Env:root\charly\purge\costing

&$env:QTP costing3_not_yrend
&$env:QTP costing4_not_yrend

&$env:QUIZ costing10

echo ""
Get-Date
echo ""
