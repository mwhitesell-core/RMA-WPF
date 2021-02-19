#-------------------------------------------------------------------------------
# File 'copy_error_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'copy_error_files'
#-------------------------------------------------------------------------------

Set-Location $pb_data
Copy-Item f087_submitted_rejected_claims* $root\alpha\rmabill\rmabill101c\data\backup
Copy-Item f085_rejected_claims $root\alpha\rmabill\rmabill101c\data\backup
Copy-Item f085_rejected_claims.idx $root\alpha\rmabill\rmabill101c\data\backup
Set-Location $application_production
