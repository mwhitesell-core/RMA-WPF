#-------------------------------------------------------------------------------
# File 'utl0012.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0012.com'
#-------------------------------------------------------------------------------

##  2016/Nov/28 MC      - change to run 2 passes

Set-Location $Env:root\charly\purge

Remove-Item utl0012.log

echo "utl0012.com  -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > utl0012.log

&$env:QUIZ utl0012_a >> utl0012.log
&$env:QUIZ utl0012_b >> utl0012.log

echo "utl0012 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> utl0012.log
