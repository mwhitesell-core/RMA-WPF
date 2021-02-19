#-------------------------------------------------------------------------------
# File 'u010_daily.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'u010_daily'
#-------------------------------------------------------------------------------

# U010_DAILY
echo "Running u010daily ... starting -$(udate) "
echo "Running u010daily ... starting -$(udate) "  >> u010daily.log

Set-Location $application_production

qtp++ $obj\u010daily  >> u010daily.log

echo "Running r010daily_1 ... starting -$(udate) "  >> r010daily.log

quiz++ $obj\r010daily_1  >> r010daily.log

echo "Running r010daily_2 ... starting -$(udate) "  >> r010daily.log

quiz++ $obj\r010daily_2  >> r010daily.log

Move-Item r010daily.txt r010daily_${1}.txt

Get-Content extf001aa.sf  >> extf001aa_cycle.sf
Get-Content extf001.sf  >> extf001_cycle.sf
Get-Content r010daily.sf  >> r010daily_cycle.sf

echo "u010daily ...   ending -$(udate) "
echo "u010daily ...   ending -$(udate) "  >> u010daily.log
