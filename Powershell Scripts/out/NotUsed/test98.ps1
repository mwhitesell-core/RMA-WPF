#-------------------------------------------------------------------------------
# File 'test98.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'test98'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\98
Remove-Item r004*portal*
&$env:QUIZ r004a 98000000 98ZZZ999 > r004_portal.log
&$env:QUIZ r004b >> r004_portal.log
&$env:QUIZ r004c >> r004_portal.log
&$env:QUIZ r004d >> r004_portal.log
&$env:QUIZ r004c_portal >> r004_portal.log

Move-Item -Force r004c_portal.txt r004c_portal_98.txt

echo "Done!"
