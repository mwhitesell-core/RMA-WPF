#-------------------------------------------------------------------------------
# File 'copy_f114.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'copy_f114'
#-------------------------------------------------------------------------------

Set-Location $root\alpha\rmabill\rmabill101c\data
Copy-Item f114* $root\alpha\rmabill\rmabill101c\data\backup

Set-Location $root\alpha\rmabill\rmabillmp\data
Copy-Item f114* $root\alpha\rmabill\rmabillmp\data\backup

Set-Location $root\alpha\rmabill\rmabillsolo\data
Copy-Item f114* $root\alpha\rmabill\rmabillsolo\data\backup

Set-Location $root\alpha\rmabill\rmabill101c\upload
