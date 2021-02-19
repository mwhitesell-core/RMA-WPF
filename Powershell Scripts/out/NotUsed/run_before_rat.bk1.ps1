#-------------------------------------------------------------------------------
# File 'run_before_rat.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_before_rat.bk1'
#-------------------------------------------------------------------------------

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $Env:root\charly\purge

echo "Start Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > checkf002tech_servdate.log

&$env:QTP checkf002tech_serv_date >> checkf002tech_servdate.log

&$env:QUIZ diffamt >> checkf002tech_servdate.log

&$env:QUIZ diffdate >> checkf002tech_servdate.log

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >> checkf002tech_servdate.log

Move-Item -Force diffamt.txt  diffamt.txt_$(Get-Date -uformat "%20%y%m%d")
Move-Item -Force diffdate.txt  diffdate.txt_$(Get-Date -uformat "%20%y%m%d")
mv checkf002_tech_servdate.log  checkf002tech_servdate.log_$(Get-Date -uformat "20%y%m%d")

echo "End Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $env:application_production
