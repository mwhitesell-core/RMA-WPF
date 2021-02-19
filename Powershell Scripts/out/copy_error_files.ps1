#-------------------------------------------------------------------------------
# File 'copy_error_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'copy_error_files'
#-------------------------------------------------------------------------------

#CORE - Changed to SQL Backup
<#Set-Location $env:pb_data
Copy-Item f087_submitted_rejected_claims* \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data\backup
Copy-Item f085_rejected_claims \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data\backup
Copy-Item f085_rejected_claims.idx \\$Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\data\backup
Set-Location $env:application_production#>
$date = Get-Date -UFormat %Y%m%d
$rcmd = $env:QTP + "backup_earnings_daily $date copy_error_files"
Invoke-Expression $rcmd
