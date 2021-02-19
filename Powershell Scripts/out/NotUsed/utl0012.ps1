#-------------------------------------------------------------------------------
# File 'utl0012.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'utl0012.com'
#-------------------------------------------------------------------------------

##  2016/Nov/28 MC      - change to run 2 passes

Set-Location $root\charly\purge

Remove-Item utl0012.log

echo "utl0012.com  -  STARTING -$(udate)"  > utl0012.log

quiz++ $obj\utl0012_a  >> utl0012.log
quiz++ $obj\utl0012_b  >> utl0012.log

echo "utl0012 - ENDING -$(udate)"  >> utl0012.log
