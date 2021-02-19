#-------------------------------------------------------------------------------
# File 'rerun_r004_portal_60.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_r004_portal_60'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\61
&$env:QUIZ r004btp_portal > r004_portal.log

Move-Item -Force r004btp_portal.txt r004c_portal_61.txt

Set-Location $env:application_production\62
&$env:QUIZ r004btp_portal > r004_portal.log
Move-Item -Force r004btp_portal.txt r004c_portal_62.txt

Set-Location $env:application_production\63
&$env:QUIZ r004btp_portal > r004_portal.log
Move-Item -Force r004btp_portal.txt r004c_portal_63.txt

Set-Location $env:application_production\64
&$env:QUIZ r004btp_portal > r004_portal.log
Move-Item -Force r004btp_portal.txt r004c_portal_64.txt

Set-Location $env:application_production\65
&$env:QUIZ r004btp_portal > r004_portal.log
Move-Item -Force r004btp_portal.txt r004c_portal_65.txt
