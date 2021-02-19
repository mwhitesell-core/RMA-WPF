#-------------------------------------------------------------------------------
# File 'r051_portal_60_70_82_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r051_portal_60_70_82_86'
#-------------------------------------------------------------------------------

echo " --- r051c_portal (PH) --- "

### Clinic 82
Set-Location $env:application_production\82
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 82@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 82@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_82.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_82.txt

### Clinic 86
Set-Location $env:application_production\86
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 86@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 86@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_86.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_86.txt

### Clinic 61
Set-Location $env:application_production\61
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 61@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 61@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_61.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_61.txt

### Clinic 62
Set-Location $env:application_production\62
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 62@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 62@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_62.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_62.txt

### Clinic 63
Set-Location $env:application_production\63
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 63@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 63@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_63.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_63.txt

### Clinic 64
Set-Location $env:application_production\64
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 64@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 64@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_64.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_64.txt

### Clinic 65
Set-Location $env:application_production\65
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 65@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 65@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_65.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_65.txt

### Clinic 66
Set-Location $env:application_production\66
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 66@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 66@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_66.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_66.txt

### Clinic 71
Set-Location $env:application_production\71
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 71@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 71@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_71.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_71.txt

### Clinic 72
Set-Location $env:application_production\72
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 72@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 72@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_72.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_72.txt

### Clinic 73
Set-Location $env:application_production\73
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 73@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 73@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_73.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_73.txt

### Clinic 74
Set-Location $env:application_production\74
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 74@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 74@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_74.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_74.txt

### Clinic 75
Set-Location $env:application_production\75
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051catp_portal 75@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cbtp_portal 75@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051catp_portal.txt r051ca_portal_75.txt
Move-Item -Force r051cbtp_portal.txt r051cb_portal_75.txt

Get-Date
echo "Done!"
