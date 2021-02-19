#-------------------------------------------------------------------------------
# File 'copy_f113_solo.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_f113_solo'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabillsolo\data
Copy-Item f113_default_comp.dat $Env:root\alpha\rmabill\rmabillsolo\data\backup
Copy-Item f113_default_comp.idx $Env:root\alpha\rmabill\rmabillsolo\data\backup
Set-Location $Env:root\alpha\rmabill\rmabillsolo\upload
