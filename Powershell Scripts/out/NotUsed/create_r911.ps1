#-------------------------------------------------------------------------------
# File 'create_r911.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_r911'
#-------------------------------------------------------------------------------

#
# CREATE A LIST OF ASSIGNED DOCTOR NUMBERS R911.TXT 
#

Set-Location $env:application_production

Remove-Item r911.txt *> $null

echo " --- r911.qzc --- "
&$env:QUIZ r911

Get-Content r911.txt | Out-Printer
