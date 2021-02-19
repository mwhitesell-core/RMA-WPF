#-------------------------------------------------------------------------------
# File 'check_u030_no_adj.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'check_u030_no_adj'
#-------------------------------------------------------------------------------

echo "check u030_no_adj for  clinic  22 to 48"

Set-Location $env:application_production
&$env:QUIZ checku030f002

Set-Location $env:application_production\31
&$env:QUIZ checku030f002

Set-Location $env:application_production\32
&$env:QUIZ checku030f002

Set-Location $env:application_production\33
&$env:QUIZ checku030f002

Set-Location $env:application_production\34
&$env:QUIZ checku030f002

Set-Location $env:application_production\35
&$env:QUIZ checku030f002

Set-Location $env:application_production\36
&$env:QUIZ checku030f002

Set-Location $env:application_production\41
&$env:QUIZ checku030f002

Set-Location $env:application_production\42
&$env:QUIZ checku030f002

Set-Location $env:application_production\43
&$env:QUIZ checku030f002

Set-Location $env:application_production\44
&$env:QUIZ checku030f002

Set-Location $env:application_production\45
&$env:QUIZ checku030f002

Set-Location $env:application_production\46
&$env:QUIZ checku030f002

Set-Location $env:application_production\48
&$env:QUIZ checku030f002


echo "Done!"
