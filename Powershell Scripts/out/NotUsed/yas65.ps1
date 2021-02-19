#-------------------------------------------------------------------------------
# File 'yas65.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas65'
#-------------------------------------------------------------------------------

echo "Now starting U030 for Clinic 65 ..."
Get-Date
Set-Location $env:application_production\65
Get-Location
Remove-Item u030_65.ls *> $null
&$env:cmd\u030 65 *> u030_65.ls
Get-Date
