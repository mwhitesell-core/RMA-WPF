#-------------------------------------------------------------------------------
# File 'copy_subfiles_third_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_subfiles_third_monthend'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\22
Move-Item -Force claims_subfile* \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data2\ma

Set-Location $env:application_production
