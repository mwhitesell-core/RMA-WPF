#-------------------------------------------------------------------------------
# File '60mohprice.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was '60mohprice'
#-------------------------------------------------------------------------------

param(
  [string] $1
)


 Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\62\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\62\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\63\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\63\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\64\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\64\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\65\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
 Get-Content $pb_prod\65\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat

&$env:QUIZ u030aa3 WEB
Move-Item -Force mohprice.txt moh${1}.txt

Remove-Item u030_tape_145_file.dat *> $null
Copy-Item u030_tape_145_file_bkp.dat u030_tape_145_file.dat
