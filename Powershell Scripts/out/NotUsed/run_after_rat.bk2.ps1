#-------------------------------------------------------------------------------
# File 'run_after_rat.bk2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_after_rat.bk2'
#-------------------------------------------------------------------------------

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $Env:root\foxtrot\purge

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > checkf002tech_servdate.log

&$env:QTP checkf002tech_serv_date >> checkf002tech_servdate.log

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> checkf002tech_servdate.log

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $env:application_production
