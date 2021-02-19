#-------------------------------------------------------------------------------
# File 'u920.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'u920.com'
#-------------------------------------------------------------------------------

Set-Location $Env:root\charly\purge

Remove-Item u920.log

echo "U920.com  -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > u920.log

&$env:QTP u920 >> u920.log 2> u920.log

echo "u920 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> u920.log
