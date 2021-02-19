#-------------------------------------------------------------------------------
# File 'printyastest.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'printyastest'
#-------------------------------------------------------------------------------

Set-Location $env:application_production\31\rerun_u030
Get-Content ru030b.txt | Out-Printer
Get-Content autoadj.txt | Out-Printer

Set-Location $env:application_production\32\rerun_u030
Get-Content ru030b.txt | Out-Printer
Get-Content autoadj.txt | Out-Printer

Set-Location $aplication_production\33\rerun_u030
Get-Content ru030b.txt | Out-Printer
Get-Content autoadj.txt | Out-Printer

Set-Location $env:application_production\34\rerun_u030
Get-Content ru030b.txt | Out-Printer
Get-Content autoadj.txt | Out-Printer

Set-Location $env:application_production\35\rerun_u030
Get-Content ru030b.txt | Out-Printer
Get-Content autoadj.txt | Out-Printer

Set-Location $env:application_production\36\rerun_u030
Get-Content ru030b.txt | Out-Printer
Get-Content autoadj.txt | Out-Printer
