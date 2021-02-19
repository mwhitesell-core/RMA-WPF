#-------------------------------------------------------------------------------
# File 'mohprice_bkp.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'mohprice_bkp'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

Get-Content u030_tape_rmb_file.dat, $pb_prod\90\u030_tape_145_file.dat, $pb_prod\90\u030_tape_rmb_file.dat, `
  $pb_prod\80\u030_tape_145_file.dat, $pb_prod\80\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat


&$env:QUIZ u030aa3 WEB
Move-Item -Force mohprice.txt moh${1}.txt
