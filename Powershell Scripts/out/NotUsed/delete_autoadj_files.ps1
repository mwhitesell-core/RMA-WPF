#-------------------------------------------------------------------------------
# File 'delete_autoadj_files.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_autoadj_files'
#-------------------------------------------------------------------------------

echo "delete files from autoadj in each clinic subdirectory"

Set-Location $env:application_production
Remove-Item -Recurse autoadj

Set-Location $env:application_production\31
Remove-Item -Recurse autoadj

Set-Location $env:application_production\32
Remove-Item -Recurse autoadj

Set-Location $env:application_production\34
Remove-Item -Recurse autoadj

Set-Location $env:application_production\35
Remove-Item -Recurse autoadj

Set-Location $env:application_production\36
Remove-Item -Recurse autoadj

Set-Location $env:application_production\37
Remove-Item -Recurse autoadj

Set-Location $env:application_production\41
Remove-Item -Recurse autoadj

Set-Location $env:application_production\42
Remove-Item -Recurse autoadj

Set-Location $env:application_production\43
Remove-Item -Recurse autoadj

Set-Location $env:application_production\44
Remove-Item -Recurse autoadj

Set-Location $env:application_production\45
Remove-Item -Recurse autoadj

Set-Location $env:application_production\46
Remove-Item -Recurse autoadj

Set-Location $env:application_production\61
Remove-Item -Recurse autoadj

Set-Location $env:application_production\62
Remove-Item -Recurse autoadj

Set-Location $env:application_production\63
Remove-Item -Recurse autoadj

Set-Location $env:application_production\64
Remove-Item -Recurse autoadj

Set-Location $env:application_production\65
Remove-Item -Recurse autoadj

Set-Location $env:application_production\71
Remove-Item -Recurse autoadj

Set-Location $env:application_production\72
Remove-Item -Recurse autoadj

Set-Location $env:application_production\73
Remove-Item -Recurse autoadj

Set-Location $env:application_production\74
Remove-Item -Recurse autoadj

Set-Location $env:application_production\75
Remove-Item -Recurse autoadj

Set-Location $env:application_production\78
Remove-Item -Recurse autoadj

Set-Location $env:application_production\79
Remove-Item -Recurse autoadj

Set-Location $env:application_production\80
Remove-Item -Recurse autoadj

Set-Location $env:application_production\82
Remove-Item -Recurse autoadj

Set-Location $env:application_production\84
Remove-Item -Recurse autoadj

Set-Location $env:application_production\86
Remove-Item -Recurse autoadj

Set-Location $env:application_production\87
Remove-Item -Recurse autoadj

Set-Location $env:application_production\88
Remove-Item -Recurse autoadj

Set-Location $env:application_production\91
Remove-Item -Recurse autoadj

Set-Location $env:application_production\92
Remove-Item -Recurse autoadj

Set-Location $env:application_production\93
Remove-Item -Recurse autoadj

Set-Location $env:application_production\94
Remove-Item -Recurse autoadj

Set-Location $env:application_production\95
Remove-Item -Recurse autoadj

Set-Location $env:application_production\96
Remove-Item -Recurse autoadj

Set-Location $env:application_production

echo "Done!"
