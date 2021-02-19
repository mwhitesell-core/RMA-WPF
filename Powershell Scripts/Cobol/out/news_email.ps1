#-------------------------------------------------------------------------------
# File 'news_email.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'news_email'
#-------------------------------------------------------------------------------

Set-Location $root\alpha\rmabill\rmabill101c\production

echo "Start Time of $cmd\portal_reports is$(udate)"

quiz++ $obj\newsemail

echo "End Time of $cmd\portal_reports is$(udate)"
