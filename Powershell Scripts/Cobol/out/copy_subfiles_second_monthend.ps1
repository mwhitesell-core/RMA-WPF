#-------------------------------------------------------------------------------
# File 'copy_subfiles_second_monthend.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'copy_subfiles_second_monthend'
#-------------------------------------------------------------------------------

Set-Location $application_production\60
Copy-Item claims_subfile_60_*.sf $root\alpha\rmabill\rmabill101c\data2\ma
Copy-Item claims_subfile_60_*.sfd $root\alpha\rmabill\rmabill101c\data2\ma
Set-Location $application_production\70
Copy-Item claims_subfile_70_*.sf $root\alpha\rmabill\rmabill101c\data2\ma
Copy-Item claims_subfile_70_*.sfd $root\alpha\rmabill\rmabill101c\data2\ma
Set-Location $application_production\82
Copy-Item claims_subfile_82_*.sf $root\alpha\rmabill\rmabill101c\data2\ma
Copy-Item claims_subfile_82_*.sfd $root\alpha\rmabill\rmabill101c\data2\ma
Set-Location $application_production\86
Copy-Item claims_subfile_86_*.sf $root\alpha\rmabill\rmabill101c\data2\ma
Copy-Item claims_subfile_86_*.sfd $root\alpha\rmabill\rmabill101c\data2\ma

Set-Location $application_production
