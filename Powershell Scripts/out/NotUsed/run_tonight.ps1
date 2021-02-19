#-------------------------------------------------------------------------------
# File 'run_tonight.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_tonight'
#-------------------------------------------------------------------------------

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $Env:root\foxtrot\purge

&$env:QTP checkf002tech_serv_date > checkf002tech_servdate.log

Set-Location $Env:root\alpha\rmabill\rmabill101c\src\yas

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

##qtp auto=$obj/

##quiz auto=$obj/

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
