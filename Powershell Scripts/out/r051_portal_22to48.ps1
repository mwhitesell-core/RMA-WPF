#-------------------------------------------------------------------------------
# File 'r051_portal_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r051_portal_22to48'
#-------------------------------------------------------------------------------

echo " --- r051ca_portal (PH) --- "
Get-Date

### Clinic 22
Set-Location $env:application_production
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 22@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 22@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_22.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_22.txt

### Clinic 23
Set-Location $env:application_production\23
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 23@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 23@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_23.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_23.txt

### Clinic 24
Set-Location $env:application_production\24
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 24@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 24@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_24.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_24.txt

### Clinic 25
Set-Location $env:application_production\25
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 25@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 25@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_25.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_25.txt

### Clinic 26
Set-Location $env:application_production\26
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 26@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 26@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_26.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_26.txt

### Clinic 30
Set-Location $env:application_production\30
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 30@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 30@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_30.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_30.txt

### Clinic 31  
Set-Location $env:application_production\31
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 31@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 31@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_31.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_31.txt

### Clinic 32
Set-Location $env:application_production\32
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 32@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 32@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_32.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_32.txt

### Clinic 33
Set-Location $env:application_production\33
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 33@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 33@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_33.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_33.txt

### Clinic 34
Set-Location $env:application_production\34
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 34@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 34@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_34.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_34.txt

### Clinic 35
Set-Location $env:application_production\35
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 35@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 35@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_35.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_35.txt

### Clinic 36
Set-Location $env:application_production\36
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 36@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 36@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_36.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_36.txt

### Clinic 41
Set-Location $env:application_production\41
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 41@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 41@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_41.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_41.txt

### Clinic 42
Set-Location $env:application_production\42
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 42@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 42@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_42.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_42.txt

### Clinic 43
Set-Location $env:application_production\43
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 43@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 43@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_43.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_43.txt

### Clinic 44
Set-Location $env:application_production\44
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 44@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 44@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_44.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_44.txt

### Clinic 45
Set-Location $env:application_production\45
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 45@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 45@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_45.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_45.txt

### Clinic 46
Set-Location $env:application_production\46
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 46@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 46@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_46.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_46.txt

### Clinic 47
Set-Location $env:application_production\47
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 47@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 47@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_47.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_47.txt

### Clinic 48
#cd $application_production/48
#rm r051*portal*
#quiz << R051_EXIT  > r051_portal.log
#exec $obj/r051ca_portal
#48@
#exec $obj/r051cb_portal
#48@
#R051_EXIT

#mv r051ca_portal.txt r051ca_portal_48.txt
#mv r051cb_portal.txt r051cb_portal_48.txt

### Clinic 98
Set-Location $env:application_production\98
Remove-Item r051*portal*
$rcmd = $env:QUIZ + "r051ca_portal 98@"
Invoke-Expression $rcmd > r051_portal.log
$rcmd = $env:QUIZ + "r051cb_portal 98@"
Invoke-Expression $rcmd >> r051_portal.log

Move-Item -Force r051ca_portal.txt r051ca_portal_98.txt
Move-Item -Force r051cb_portal.txt r051cb_portal_98.txt

Get-Date
echo "Done!"
