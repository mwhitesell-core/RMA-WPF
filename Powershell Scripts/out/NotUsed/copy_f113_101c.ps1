#-------------------------------------------------------------------------------
# File 'copy_f113_101c.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_f113_101c'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\data
Copy-Item f113_default_comp.dat $Env:root\alpha\rmabill\rmabill101c\data\backup
Copy-Item f113_default_comp.idx $Env:root\alpha\rmabill\rmabill101c\data\backup
Copy-Item f113_default_comp_upload_driver.dat $Env:root\alpha\rmabill\rmabill101c\data\backup
Copy-Item f113_default_comp_upload_driver.idx $Env:root\alpha\rmabill\rmabill101c\data\backup
Set-Location $Env:root\alpha\rmabill\rmabill101c\upload
