#-------------------------------------------------------------------------------
# File 'delete_rmdir.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_rmdir'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\46
Set-Location reverse_u030_autoadj
Remove-Item *
Set-Location ..
Remove-Item reverse_u030_autoadj

Set-Location rerun_u030
Remove-Item *
Set-Location ..
Remove-Item rerun_u030

Set-Location $env:application_production\48
Set-Location reverse_u030_autoadj
Remove-Item *
Set-Location ..
Remove-Item reverse_u030_autoadj

Set-Location rerun_u030
Remove-Item *
Set-Location ..
Remove-Item rerun_u030
