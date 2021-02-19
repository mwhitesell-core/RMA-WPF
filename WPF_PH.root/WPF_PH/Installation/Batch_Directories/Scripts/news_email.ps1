#-------------------------------------------------------------------------------
# File 'news_email.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'news_email'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production

echo "Start Time of $env:cmd\portal_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QUIZ news_email

echo "End Time of $env:cmd\portal_reports is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
