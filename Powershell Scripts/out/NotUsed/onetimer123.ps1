#-------------------------------------------------------------------------------
# File 'onetimer123.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'onetimer123'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

&$env:cmd\r123
Remove-Item r123*_${1}.txt *> $null
Move-Item -Force r123a r123a_${1}.txt
Move-Item -Force r123b r123b_${1}.txt
Move-Item -Force r123c r123c_${1}.txt
echo "--- PH program r123d ---"
&$env:QUIZ r123d1
Move-Item -Force r123d.txt r123d_${1}.txt
Get-Content r123ef | Out-Printer
Get-Content r123ef | Out-Printer
