#-------------------------------------------------------------------------------
# File 'r004_ph_portal_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'r004_ph_portal_22to48'
#-------------------------------------------------------------------------------

echo " --- r004c_portal (PH) --- "
Get-Date

Set-Location $application_production
$cmd\r004_portal  22@  22

Set-Location $application_production\23
$cmd\r004_portal  23@  23

Set-Location $application_production\24
$cmd\r004_portal  24@  24

Set-Location $application_production\25
$cmd\r004_portal  25@  25

Set-Location $application_production\26
$cmd\r004_portal  26@  26

Set-Location $application_production\30
$cmd\r004_portal  30@  30

Set-Location $application_production\31
$cmd\r004_portal  31@  31

Set-Location $application_production\32
$cmd\r004_portal  32@  32

Set-Location $application_production\33
$cmd\r004_portal  33@  33

Set-Location $application_production\34
$cmd\r004_portal  34@  34

Set-Location $application_production\35
$cmd\r004_portal  35@  35

Set-Location $application_production\36
$cmd\r004_portal  36@  36

Set-Location $application_production\41
$cmd\r004_portal  41@  41

Set-Location $application_production\42
$cmd\r004_portal  42@  42

Set-Location $application_production\43
$cmd\r004_portal  43@  43

Set-Location $application_production\44
$cmd\r004_portal  44@  44

Set-Location $application_production\45
$cmd\r004_portal  45@  45

Set-Location $application_production\46
$cmd\r004_portal  46@  46

#cd $application_production/48
#$cmd/r004_portal  48@  48

Set-Location $application_production\98
$cmd\r004_portal  98@  98

Get-Date
echo "Done!"
