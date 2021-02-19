#-------------------------------------------------------------------------------
# File 'check_u030_auto_adj.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_u030_auto_adj'
#-------------------------------------------------------------------------------

echo "check u030_auto_adj for  clinic  22 to 48"

Set-Location $env:application_production
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\31
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\32
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\33
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\34
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\35
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\36
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\41
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\42
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\43
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\44
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\45
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\46
&$env:QUIZ checkautoadjf002

Set-Location $env:application_production\48
&$env:QUIZ checkautoadjf002


echo "Done!"
