#-------------------------------------------------------------------------------
# File 'fix_u030b_reverse_22to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fix_u030b_reverse_22to48'
#-------------------------------------------------------------------------------

echo "u030b reverse for clinic 22 to 48"

Set-Location $env:application_production\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\31\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\32\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\33\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\34\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\35\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\36\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\41\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\42\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\43\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\44\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\45\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\46\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log

Set-Location $env:application_production\48\rerun_u030
&$env:QTP fixf002adjdtl > fixf002adjdtl.log


echo "Done!"
