#-------------------------------------------------------------------------------
# File 'r004_ph_portal_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r004_ph_portal_22to48'
#-------------------------------------------------------------------------------

echo " --- r004c_portal (PH) --- "
Get-Date

Set-Location $env:application_production
&$env:cmd\r004_portal  22@  22

Set-Location $env:application_production\23
&$env:cmd\r004_portal  23@  23

Set-Location $env:application_production\24
&$env:cmd\r004_portal  24@  24

Set-Location $env:application_production\25
&$env:cmd\r004_portal  25@  25

Set-Location $env:application_production\26
&$env:cmd\r004_portal  26@  26

Set-Location $env:application_production\30
&$env:cmd\r004_portal  30@  30

Set-Location $env:application_production\31
&$env:cmd\r004_portal  31@  31

Set-Location $env:application_production\32
&$env:cmd\r004_portal  32@  32

Set-Location $env:application_production\33
&$env:cmd\r004_portal  33@  33

Set-Location $env:application_production\34
&$env:cmd\r004_portal  34@  34

Set-Location $env:application_production\35
&$env:cmd\r004_portal  35@  35

Set-Location $env:application_production\36
&$env:cmd\r004_portal  36@  36

Set-Location $env:application_production\41
&$env:cmd\r004_portal  41@  41

Set-Location $env:application_production\42
&$env:cmd\r004_portal  42@  42

Set-Location $env:application_production\43
&$env:cmd\r004_portal  43@  43

Set-Location $env:application_production\44
&$env:cmd\r004_portal  44@  44

Set-Location $env:application_production\45
&$env:cmd\r004_portal  45@  45

Set-Location $env:application_production\46
&$env:cmd\r004_portal  46@  46

#cd $application_production/48
#$cmd/r004_portal  48@  48

Set-Location $env:application_production\98
&$env:cmd\r004_portal  98@  98

Get-Date
echo "Done!"
