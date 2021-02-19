#-------------------------------------------------------------------------------
# File 'copy_subfiles_second_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_subfiles_second_monthend'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\60
Copy-Item claims_subfile_60_*.sf \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma
Copy-Item claims_subfile_60_*.sfd \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma
Set-Location $env:application_production\70
Copy-Item claims_subfile_70_*.sf \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma
Copy-Item claims_subfile_70_*.sfd \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma
Set-Location $env:application_production\82
Copy-Item claims_subfile_82_*.sf \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma
Copy-Item claims_subfile_82_*.sfd \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma
Set-Location $env:application_production\86
Copy-Item claims_subfile_86_*.sf \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma
Copy-Item claims_subfile_86_*.sfd \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma

Set-Location $env:application_production
