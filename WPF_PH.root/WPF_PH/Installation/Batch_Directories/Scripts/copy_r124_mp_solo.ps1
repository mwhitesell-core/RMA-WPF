#-------------------------------------------------------------------------------
# File 'copy_r124_mp_solo.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_r124_mp_solo'
#-------------------------------------------------------------------------------

Set-Location \\$Env:root\alpha\rmabill\rmabillmp\data2\ma
Copy-Item r124b*mp*201609*.txt \\$Env:root\alpha\rmabill\rmabill101c\production
Copy-Item r124b*paycode7*201609*.txt \\$Env:root\alpha\rmabill\rmabill101c\production

Set-Location \\$Env:root\alpha\rmabill\rmabillsolo\data2\ma
Copy-Item r124b*solo*201608*.txt \\$Env:root\alpha\rmabill\rmabill101c\production

Set-Location \\$Env:root\alpha\rmabill\rmabill101c\production
