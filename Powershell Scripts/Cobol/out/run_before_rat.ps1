#-------------------------------------------------------------------------------
# File 'run_before_rat.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'run_before_rat'
#-------------------------------------------------------------------------------

echo "Start Time is$(udate)"

Set-Location $root\charly\purge

echo "Start Time is$(udate)"  > checkf002tech_servdate.log

qtp++ $obj\checkf002tech_serv_date  >> checkf002tech_servdate.log

quiz++ $src\diffamt  >> checkf002tech_servdate.log

quiz++ $src\diffdate  >> checkf002tech_servdate.log

echo "End Time is$(udate)"  >> checkf002tech_servdate.log

Move-Item diffamt.txt  diffamt.txt_$(Get-Date -uformat "%20%y%m%d")
Move-Item diffdate.txt  diffdate.txt_$(Get-Date -uformat "%20%y%m%d")
Move-Item checkf002tech_servdate.log  checkf002tech_servdate.log_$(Get-Date -uformat "%20%y%m%d")

echo "End Time is$(udate)"

Set-Location $application_production
