#-------------------------------------------------------------------------------
# File 'create_rerun_dir_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_rerun_dir_22to48'
#-------------------------------------------------------------------------------

echo "create rerun directory for r004 portal"

Set-Location $env:application_production
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\23
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\24
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\25
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\31
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\32
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\33
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\34
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\35
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\36
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\41
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\42
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\43
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\44
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\45
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

Set-Location $env:application_production\46
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004

#cd $application_production/48
#mkdir backup_r004  
#cp -p r004*.** backup_r004

Set-Location $env:application_production\98
New-Item -ItemType directory -Force -Path backup_r004
Copy-Item r004*.* backup_r004


echo "Done!"
