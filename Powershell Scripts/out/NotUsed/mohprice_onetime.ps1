#-------------------------------------------------------------------------------
# File 'mohprice_onetime.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'mohprice_onetime'
#-------------------------------------------------------------------------------

param(
  [string] $1
)


 Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\33\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\33\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat

&$env:QUIZ u030aa3_onetime
Move-Item -Force mohprice.txt moh${1}.txt

Remove-Item u030*.dat *> $null
