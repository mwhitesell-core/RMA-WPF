#-------------------------------------------------------------------------------
# File 'update_unprocessed_web_disk_patients.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'update_unprocessed_web_disk_patients'
#-------------------------------------------------------------------------------

echo "u704a   starting       -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') "

$rcmd = $env:QTP + "u704a" >> u704a.log
Invoke-Expression $rcmd
echo "u704a     ...   ending -  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S') "
