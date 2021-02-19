#-------------------------------------------------------------------------------
# File 'tebr123.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'tebr123'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

Set-Location $env:application_production
echo "--- cobol program r123 ---"

&$env:cmd\r123
Remove-Item r123*_${1}.txt *> $null
Move-Item -Force r123a r123a_${1}.txt
Move-Item -Force r123b r123b_${1}.txt
Move-Item -Force r123c r123c_${1}.txt


&$env:cmd\backup_earnings_monthend ${1}
#echo
#echo
