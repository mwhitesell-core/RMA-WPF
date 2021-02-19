#-------------------------------------------------------------------------------
# File 'reload_f114.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reload_f114'
#-------------------------------------------------------------------------------

Set-Location $pb_data
Set-Location backup
Copy-Item f114* $Env:root\alpha\rmabill\rmabill101c\data

Set-Location $Env:root\alpha\rmabill\rmabillsolo\data
Set-Location backup
Copy-Item f114* $Env:root\alpha\rmabill\rmabillsolo\data

Set-Location $Env:root\alpha\rmabill\rmabillmp\data
Set-Location backup
Copy-Item f114* $Env:root\alpha\rmabill\rmabillmp\data

Set-Location $Env:root\alpha\rmabill\rmabill101c\upload
