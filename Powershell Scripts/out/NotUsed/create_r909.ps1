#-------------------------------------------------------------------------------
# File 'create_r909.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_r909'
#-------------------------------------------------------------------------------

#
# CREATE A LIST OF AVAILABLE DOCTOR NUMBERS R909.TXT 
#

Set-Location $env:application_production

Remove-Item r909.txt *> $null

echo " --- r909.qzc --- "
&$env:QUIZ r909

Get-Content r909.txt | Out-Printer
