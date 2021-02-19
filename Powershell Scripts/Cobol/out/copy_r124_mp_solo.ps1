#-------------------------------------------------------------------------------
# File 'copy_r124_mp_solo.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'copy_r124_mp_solo'
#-------------------------------------------------------------------------------

Set-Location $root\alpha\rmabill\rmabillmp\data2\ma
Copy-Item r124b*mp*201512*.txt $root\alpha\rmabill\rmabill101c\production
Copy-Item r124b*paycode7*201512*.txt $root\alpha\rmabill\rmabill101c\production

Set-Location $root\alpha\rmabill\rmabillsolo\data2\ma
Copy-Item r124b*solo*201511*.txt $root\alpha\rmabill\rmabill101c\production

Set-Location $root\alpha\rmabill\rmabill101c\production
