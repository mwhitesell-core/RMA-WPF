#-------------------------------------------------------------------------------
# File 'utl0016.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0016.com'
#-------------------------------------------------------------------------------

# 2014/Jul/17   Terminated Doctors List

Set-Location $env:application_root\production

Remove-Item utl0016.log *> $null

echo "utl0016.com  -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > utl0016.log

&$env:QUIZ utl0016 >> utl0016.log

echo "utl0016.com - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> utl0016.log
