#-------------------------------------------------------------------------------
# File 'u010_daily.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u010_daily.bk1'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# U010_DAILY
echo "Running u010daily ... starting -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') "

Set-Location $env:application_production

&$env:QTP u010daily >> u010daily.log
&$env:QUIZ r010daily_1 >> r010daily.log
&$env:QUIZ r010daily_2 >> r010daily.log

Move-Item -Force r010daily.txt r010daily_${1}.txt

Get-Content extf001aa.sf | Add-Content extf001aa_cycle.sf
Get-Content extf001.sf | Add-Content extf001_cycle.sf
Get-Content r010daily.sf | Add-Content r010daily_cycle.sf

echo "u010daily ...   ending -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') "
