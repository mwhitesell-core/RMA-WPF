#-------------------------------------------------------------------------------
# File 'r004_portal_rename.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r004_portal_rename'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\82
Move-Item -Force r004c_portal_82.txt r004c_portal_82_old.txt

Set-Location $env:application_production\83
Move-Item -Force r004c_portal_83.txt r004c_portal_83_old.txt

Set-Location $env:application_production\86
Move-Item -Force r004c_portal_86.txt r004c_portal_86_old.txt

Set-Location $env:application_production\61
Move-Item -Force r004c_portal_61.txt r004c_portal_61_old.txt

Set-Location $env:application_production\62
Move-Item -Force r004c_portal_62.txt r004c_portal_62_old.txt

Set-Location $env:application_production\63
Move-Item -Force r004c_portal_63.txt r004c_portal_63_old.txt

Set-Location $env:application_production\64
Move-Item -Force r004c_portal_64.txt r004c_portal_64_old.txt

Set-Location $env:application_production\65
Move-Item -Force r004c_portal_65.txt r004c_portal_65_old.txt
