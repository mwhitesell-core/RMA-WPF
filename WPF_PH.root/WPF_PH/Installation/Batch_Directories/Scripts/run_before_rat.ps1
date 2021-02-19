#-------------------------------------------------------------------------------
# File 'run_before_rat.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_before_rat'
#-------------------------------------------------------------------------------

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location \\$Env:root\charly\purge

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > checkf002tech_servdate.log

$rcmd = $env:QTP + "checkf002tech_serv_date" 
Invoke-Expression $rcmd >> checkf002tech_servdate.log

$rcmd = $env:QUIZ + "diffamt" 
Invoke-Expression $rcmd >> checkf002tech_servdate.log

$rcmd = $env:QUIZ + "diffdate" 
Invoke-Expression $rcmd >> checkf002tech_servdate.log

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> checkf002tech_servdate.log

Move-Item -Force diffamt.txt  diffamt.txt_$(Get-Date -uformat "%20%y%m%d")
Move-Item -Force diffdate.txt  diffdate.txt_$(Get-Date -uformat "%20%y%m%d")
Move-Item -Force checkf002tech_servdate.log  checkf002tech_servdate.log_$(Get-Date -uformat "%20%y%m%d")

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $env:application_production
