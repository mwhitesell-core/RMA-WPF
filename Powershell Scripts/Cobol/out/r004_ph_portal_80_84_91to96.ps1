#-------------------------------------------------------------------------------
# File 'r004_ph_portal_80_84_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r004_ph_portal_80_84_91to96'
#-------------------------------------------------------------------------------

echo " --- r004c_portal (PH) --- "

Set-Location $application_production\37
$cmd\r004_portal 37@  37

Set-Location $application_production\68
$cmd\r004_portal 68@  68

Set-Location $application_production\69
$cmd\r004_portal 69@  69

Set-Location $application_production\78
$cmd\r004_portal 78@  78

Set-Location $application_production\79
$cmd\r004_portal 79@  79

Set-Location $application_production\80
$cmd\r004_portal 80@  80

Set-Location $application_production\84
$cmd\r004_portal 84@  84

Set-Location $application_production\87
$cmd\r004_portal 87@  87

Set-Location $application_production\88
$cmd\r004_portal 88@  88

Set-Location $application_production\89
$cmd\r004_portal 89@  89

Set-Location $application_production\91
$cmd\r004_portal 91@  91

Set-Location $application_production\92
$cmd\r004_portal 92@  92

Set-Location $application_production\93
$cmd\r004_portal 93@  93

Set-Location $application_production\94
$cmd\r004_portal 94@  94

Set-Location $application_production\95
$cmd\r004_portal 95@  95

Set-Location $application_production\96
$cmd\r004_portal 96@  96

Get-Date
echo "Done!"
