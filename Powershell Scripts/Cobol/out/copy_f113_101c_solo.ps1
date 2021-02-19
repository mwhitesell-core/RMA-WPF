#-------------------------------------------------------------------------------
# File 'copy_f113_101c_solo.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'copy_f113_101c_solo'
#-------------------------------------------------------------------------------

Set-Location $root\alpha\rmabill\rmabill101c\data

Copy-Item f113_default_comp.dat $root\alpha\rmabill\rmabill101c\data\backup
Copy-Item f113_default_comp.idx $root\alpha\rmabill\rmabill101c\data\backup
Copy-Item f113_default_comp_upload_driver.dat $root\alpha\rmabill\rmabill101c\data\backup
Copy-Item f113_default_comp_upload_driver.idx $root\alpha\rmabill\rmabill101c\data\backup

Set-Location $root\alpha\rmabill\rmabillsolo\data

Copy-Item f113_default_comp.dat $root\alpha\rmabill\rmabillsolo\data\backup
Copy-Item f113_default_comp.idx $root\alpha\rmabill\rmabillsolo\data\backup

Set-Location $root\alpha\rmabill\rmabill101c\production
