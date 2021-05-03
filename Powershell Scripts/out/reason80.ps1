#-------------------------------------------------------------------------------
# File 'reason80.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reason80'
#-------------------------------------------------------------------------------

Remove-Item reason80.dat

utouch reason80.dat

Get-Content $pb_prod\61\u030_tape_rmb_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\62\u030_tape_rmb_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\63\u030_tape_rmb_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\64\u030_tape_rmb_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\65\u030_tape_rmb_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\61\u030_tape_145_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\62\u030_tape_145_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\63\u030_tape_145_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\64\u030_tape_145_file.dat | Add-Content reason80.dat
Get-Content $pb_prod\65\u030_tape_145_file.dat | Add-Content reason80.dat

Move-Item -Force u030_tape_145_file.dat u030_tape_bkp.dat
Move-Item -Force reason80.dat u030_tape_145_file.dat

&$env:QUIZ reason80

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content reason80.txt | Out-Printer -Name $env:networkprinter
}

Remove-Item u030_tape_145_file.dat
Move-Item -Force u030_tape_bkp.dat u030_tape_145_file.dat
