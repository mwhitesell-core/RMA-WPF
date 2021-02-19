#-------------------------------------------------------------------------------
# File 'rerun_r004_portal_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'rerun_r004_portal_22to48'
#-------------------------------------------------------------------------------

Set-Location $env:application_production

&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_22.txt

Set-Location $env:application_production\31
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_31.txt

Set-Location $env:application_production\32
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_32.txt

Set-Location $env:application_production\33
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_33.txt

Set-Location $env:application_production\34
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_34.txt

Set-Location $env:application_production\35
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_35.txt

Set-Location $env:application_production\36
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_36.txt

Set-Location $env:application_production\41
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_41.txt

Set-Location $env:application_production\42
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_42.txt

Set-Location $env:application_production\43
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_43.txt

Set-Location $env:application_production\44
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_44.txt

Set-Location $env:application_production\45
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_45.txt

Set-Location $env:application_production\46
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_46.txt

Set-Location $env:application_production\48
&$env:QUIZ r004c_portal > r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_48.txt

echo "Done!"
