#-------------------------------------------------------------------------------
# File 'r051_portal_80_84_87_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r051_portal_80_84_87_91to96'
#-------------------------------------------------------------------------------

echo " --- r051_portal (PH) --- "

### Clinic 37
Set-Location $env:application_production\37
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 37@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 37@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_37.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_37.txt

### Clinic 68
Set-Location $env:application_production\68
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 68@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 68@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_68.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_68.txt

### Clinic 69
Set-Location $env:application_production\69
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 69@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 69@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_69.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_69.txt

### Clinic 78
Set-Location $env:application_production\78
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 78@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 78@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_78.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_78.txt

### Clinic 79
Set-Location $env:application_production\79
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 79@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 79@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_79.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_79.txt

### Clinic 80
Set-Location $env:application_production\80
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 80@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 80@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_80.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_80.txt

### Clinic 84
Set-Location $env:application_production\84
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 84@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 84@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_84.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_84.txt

### Clinic 87
Set-Location $env:application_production\87
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 87@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 87@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_87.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_87.txt

### Clinic 88
Set-Location $env:application_production\88
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 88@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 88@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_88.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_88.txt

### Clinic 89
Set-Location $env:application_production\89
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 89@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 89@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_89.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_89.txt

### Clinic 91
Set-Location $env:application_production\91
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 91@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 91@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_91.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_91.txt

### Clinic 92
Set-Location $env:application_production\92
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 92@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 92@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_92.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_92.txt

### Clinic 93
Set-Location $env:application_production\93
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 93@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 93@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_93.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_93.txt

### Clinic 94
Set-Location $env:application_production\94
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 94@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 94@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_94.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_94.txt

### Clinic 95
Set-Location $env:application_production\95
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 95@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 95@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_95.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_95.txt

### Clinic 96
Set-Location $env:application_production\96
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 96@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 96@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_96.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_96.txt

Get-Date
echo "Done!"
