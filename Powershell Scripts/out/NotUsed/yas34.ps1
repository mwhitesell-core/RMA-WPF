#-------------------------------------------------------------------------------
# File 'yas34.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas34'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\34
Remove-Item r004*portal*
&$env:QUIZ r004a 34000000 34ZZZ999 > r004_portal.log
&$env:QUIZ r004b >> r004_portal.log
&$env:QUIZ r004c >> r004_portal.log
&$env:QUIZ r004d >> r004_portal.log
&$env:QUIZ r004c_portal >> r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_34.txt


Set-Location $env:application_production\34
Remove-Item r051*portal*
&$env:QUIZ r051ca_portal 34@ > r051_portal.log
&$env:QUIZ r051cb_portal 34@ >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_34.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_34.txt
