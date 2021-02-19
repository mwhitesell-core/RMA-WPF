#-------------------------------------------------------------------------------
# File 'utl0016.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'utl0016.com'
#-------------------------------------------------------------------------------

# 2014/Jul/17   Terminated Doctors List

Set-Location $application_root\production

Remove-Item utl0016.log  > $null

echo "utl0016.com  -  STARTING -$(udate)"  > utl0016.log

quiz++ $src\utl0016  >> utl0016.log

echo "utl0016.com - ENDING -$(udate)"  >> utl0016.log
