#-------------------------------------------------------------------------------
# File 'reload_f113.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_f113'
#-------------------------------------------------------------------------------

Set-Location $pb_data
Set-Location backup
Copy-Item f113* $Env:root\alpha\rmabill\rmabill101c\data

Set-Location $pb_data
