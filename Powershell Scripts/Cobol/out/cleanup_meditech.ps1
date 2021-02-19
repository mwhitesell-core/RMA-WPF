#-------------------------------------------------------------------------------
# File 'cleanup_meditech.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'cleanup_meditech'
#-------------------------------------------------------------------------------

Get-Date
Set-Location $application_production

Remove-Item ru011*
Remove-Item meditech_patient_file
#rm meditech_patient_file.out
Remove-Item meditech_patient_file.u011*

Get-Date
