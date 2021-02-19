#-------------------------------------------------------------------------------
# File 'fix_f001_f002_all.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'fix_f001_f002_all'
#-------------------------------------------------------------------------------

Set-Location $application_production

$timeStamp = "20$(Get-Date -uformat `"%y_%m_%d.%H:%M`")"

qtp++ $obj\fix_f001_f002_all  > fix_f001_f002_all_$timeStamp.log
