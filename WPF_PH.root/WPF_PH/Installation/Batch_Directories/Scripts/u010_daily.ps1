#-------------------------------------------------------------------------------
# File 'u010_daily.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u010_daily'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

# U010_DAILY
echo "Running u010daily ... starting -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') "
echo "Running u010daily ... starting -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') " >> u010daily.log

Set-Location $env:application_production

$rcmd = $env:QTP + "u010daily" 
Invoke-Expression $rcmd >> u010daily.log

echo "Running r010daily_1 ... starting -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') " >> r010daily.log

$rcmd = $env:QUIZ + "r010daily_1" 
Invoke-Expression $rcmd >> r010daily.log

echo "Running r010daily_2 ... starting -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') " >> r010daily.log

$rcmd = $env:QUIZ + "r010daily_2" 
Invoke-Expression $rcmd >> r010daily.log

#Core - Added to rename report according to quiz file
Get-Content r010daily_1.txt > r010daily.txt
Get-Content r010daily_2.txt >> r010daily.txt

Move-Item -Force r010daily.txt r010daily_${1}.txt

Get-Content extf001aa.sf | Add-Content extf001aa_cycle.sf
Get-Content extf001.sf | Add-Content extf001_cycle.sf
Get-Content r010daily.sf | Add-Content r010daily_cycle.sf

echo "u010daily ...   ending -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') "
echo "u010daily ...   ending -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') " >> u010daily.log
