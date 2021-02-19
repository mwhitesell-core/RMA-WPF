#-------------------------------------------------------------------------------
# File 'utl0017.com.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'utl0017.com'
#-------------------------------------------------------------------------------

# 2014/Jul/22   Change new fee for comp code 'RMACHR' & 'GSTTAX' in f113 file (98 screen)

param(
  [string] $1
)

Set-Location $env:application_root\production

Remove-Item utl0017.log *> $null

echo "utl0017.com  -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > utl0017.log

$rcmd = $env:QTP + "utl0017 ${1}"
Invoke-Expression $rcmd >> utl0017.log

echo "utl0017.com - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> utl0017.log
