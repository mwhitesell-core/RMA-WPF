#-------------------------------------------------------------------------------
# File 'rerun_r004_portal_80_84_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_r004_portal_80_84_91to96'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\80

&$env:QUIZ r004c_portal > r004_portal.log
Move-Item -Force r004c_portal.txt r004c_portal_80.txt

Set-Location $env:application_production\84
&$env:QUIZ r004c_portal > r004_portal.log
Move-Item -Force r004c_portal.txt r004c_portal_84.txt

Set-Location $env:application_production\91
&$env:QUIZ r004c_portal > r004_portal.log
Move-Item -Force r004c_portal.txt r004c_portal_91.txt

Set-Location $env:application_production\92
&$env:QUIZ r004c_portal > r004_portal.log
Move-Item -Force r004c_portal.txt r004c_portal_92.txt

Set-Location $env:application_production\93
&$env:QUIZ r004c_portal > r004_portal.log
Move-Item -Force r004c_portal.txt r004c_portal_93.txt

Set-Location $env:application_production\94
&$env:QUIZ r004c_portal > r004_portal.log
Move-Item -Force r004c_portal.txt r004c_portal_94.txt

Set-Location $env:application_production\95
&$env:QUIZ r004c_portal > r004_portal.log
Move-Item -Force r004c_portal.txt r004c_portal_95.txt

Set-Location $env:application_production\96
&$env:QUIZ r004c_portal > r004_portal.log
Move-Item -Force r004c_portal.txt r004c_portal_96.txt
