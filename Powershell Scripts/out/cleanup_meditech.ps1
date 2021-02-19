#-------------------------------------------------------------------------------
# File 'cleanup_meditech.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'cleanup_meditech'
#-------------------------------------------------------------------------------

Get-Date
Set-Location $env:application_production

Remove-Item ru011*
Remove-Item meditech_patient_file
#rm meditech_patient_file.out
Remove-Item meditech_patient_file.u011*

Get-Date
