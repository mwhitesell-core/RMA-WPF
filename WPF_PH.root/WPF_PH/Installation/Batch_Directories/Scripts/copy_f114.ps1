#-------------------------------------------------------------------------------
# File 'copy_f114.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_f114'
#-------------------------------------------------------------------------------

<#Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data
Copy-Item f114* \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data\backup

Set-Location \\$Env:root\alpha\rmabill\rmabillmp\data
Copy-Item f114* \\$Env:root\alpha\rmabill\rmabillmp\data\backup

Set-Location \\$Env:root\alpha\rmabill\rmabillsolo\data
Copy-Item f114* \\$Env:root\alpha\rmabill\rmabillsolo\data\backup

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\upload#>

#CORE - Changed to QTP
$rcmd = $env:QTP + "copy_f114"
Invoke-Expression $rcmd
