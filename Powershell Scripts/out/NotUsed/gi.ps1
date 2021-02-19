#-------------------------------------------------------------------------------
# File 'gi.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'gi'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

Set-Location $env:application_production

Get-Content u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\23\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\23\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\24\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\24\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\25\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\25\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\26\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\26\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\30\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\30\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\31\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\31\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\32\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\32\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\33\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\33\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\34\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\34\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\35\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\35\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\36\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\36\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\37\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\37\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\41\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\41\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\42\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\42\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\43\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\43\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\44\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\44\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\45\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\45\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\46\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\46\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\80\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\80\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\84\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\84\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\86\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\86\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\87\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\87\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\88\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\88\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\89\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\89\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\61\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\61\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\62\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\62\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\63\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\63\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\64\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\64\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\65\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\65\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\66\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\66\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\68\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\68\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\69\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\69\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\71\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\71\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\72\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\72\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\73\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\73\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\74\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\74\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\75\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\75\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\79\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\79\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\91\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\91\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\96\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\96\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\78\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\78\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\82\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\82\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\92\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\92\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\93\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\93\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\94\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\94\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\95\u030_tape_145_file.dat | Add-Content u030_tape_145_file.dat
Get-Content $pb_prod\95\u030_tape_rmb_file.dat | Add-Content u030_tape_145_file.dat

&$env:QUIZ u030aa3
Move-Item -Force mohprice.txt moh${1}.txt

Remove-Item u030_tape_145_file.dat *> $null
Copy-Item u030_tape_145_file_bkp.dat u030_tape_145_file.dat
