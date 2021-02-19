#-------------------------------------------------------------------------------
# File 'copy_subfiles_third_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'copy_subfiles_third_monthend'
#-------------------------------------------------------------------------------

Set-Location $application_production\22
Move-Item claims_subfile* $root\alpha\rmabill\rmabill101c\data2\ma

Set-Location $application_production
