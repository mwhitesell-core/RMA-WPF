#-------------------------------------------------------------------------------
# File 'utl0017.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'utl0017.com'
#-------------------------------------------------------------------------------

# 2014/Jul/22   Change new fee for comp code 'RMACHR' & 'GSTTAX' in f113 file (98 screen)

Set-Location $application_root\production

Remove-Item utl0017.log  -EA SilentlyContinue

echo "utl0017.com  -  STARTING -$(udate)"  > utl0017.log

qtp++ $obj\utl0017  >> utl0017.log

echo "utl0017.com - ENDING -$(udate)"  >> utl0017.log
