#-------------------------------------------------------------------------------
# File 'r004_ph_portal_80_84_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r004_ph_portal_80_84_91to96'
#-------------------------------------------------------------------------------

echo " --- r004c_portal (PH) --- "

Set-Location $env:application_production\37
&$env:cmd\r004_portal 37@  37

Set-Location $env:application_production\68
&$env:cmd\r004_portal 68@  68

Set-Location $env:application_production\69
&$env:cmd\r004_portal 69@  69

Set-Location $env:application_production\78
&$env:cmd\r004_portal 78@  78

Set-Location $env:application_production\79
&$env:cmd\r004_portal 79@  79

Set-Location $env:application_production\80
&$env:cmd\r004_portal 80@  80

Set-Location $env:application_production\84
&$env:cmd\r004_portal 84@  84

Set-Location $env:application_production\87
&$env:cmd\r004_portal 87@  87

Set-Location $env:application_production\88
&$env:cmd\r004_portal 88@  88

Set-Location $env:application_production\89
&$env:cmd\r004_portal 89@  89

Set-Location $env:application_production\91
&$env:cmd\r004_portal 91@  91

Set-Location $env:application_production\92
&$env:cmd\r004_portal 92@  92

Set-Location $env:application_production\93
&$env:cmd\r004_portal 93@  93

Set-Location $env:application_production\94
&$env:cmd\r004_portal 94@  94

Set-Location $env:application_production\95
&$env:cmd\r004_portal 95@  95

Set-Location $env:application_production\96
&$env:cmd\r004_portal 96@  96

Get-Date
echo "Done!"
