#-------------------------------------------------------------------------------
# File 'copy_f113.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_f113'
#-------------------------------------------------------------------------------

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data
<#Copy-Item f113_default_comp.dat $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data\backup
Copy-Item f113_default_comp.idx $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data\backup
Copy-Item f113_default_comp_upload_driver.dat $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data\backup
Copy-Item f113_default_comp_upload_driver.idx $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data\backup#>

#CORE - Changed to QTP
$rcmd = $env:QTP + "copy_f113"
Invoke-Expression $rcmd

Set-Location \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\upload
