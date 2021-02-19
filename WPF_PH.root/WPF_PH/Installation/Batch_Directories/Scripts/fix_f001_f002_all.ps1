#-------------------------------------------------------------------------------
# File 'fix_f001_f002_all.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fix_f001_f002_all'
#-------------------------------------------------------------------------------

Set-Location $env:application_production

$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d.%H_%M`")"

$rcmd = $env:QTP + "fix_f001_f002_all" 
Invoke-Expression $rcmd > fix_f001_f002_all_$timeStamp.log
