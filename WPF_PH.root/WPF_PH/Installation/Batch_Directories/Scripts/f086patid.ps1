#-------------------------------------------------------------------------------
# File 'f086patid.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'f086patid'
#-------------------------------------------------------------------------------

# /bin/ksh
# f086patid
# 00/jul/26 B.E. - changed backup of file f086_pat_id.dat to keep 5 backups
# 07/sep/26 M.C. - change for /home/rma  to /alpha/home/rma etc for all home directories

echo "Running f086patid ..."

Get-ChildItem $env:pb_prod\f086_pat_id.dat

Set-Location \\$env:root\alpha\home\rma
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003 | Set-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma1
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma2
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma3
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma4
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma5
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma6
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma7
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma8
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma9
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma10
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma11
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma12
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma13
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma14
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma15
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma16
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma17
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma18
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma19
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma20
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma21
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma22
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma23
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma24
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma25
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma26
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma27
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma28
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma29
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma30
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma31
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma32
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma33
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma34
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location \\$env:root\alpha\home\rma35
Get-Content f086_pat_id.dat, f086_pat_id.d001, f086_pat_id.d003  | Add-Content $env:pb_prod\f086_pat_id.dat
&$env:cmd\f086delcopy

Set-Location $env:pb_prod
$rcmd = $env:QTP + "LOAD_F086 f086_pat_id.dat"
Invoke-Expression $rcmd
Remove-Item f086_pat_id_bkp_5.dat  -EA SilentlyContinue
Move-Item f086_pat_id_bkp_4.dat f086_pat_id_bkp_5.dat
Move-Item f086_pat_id_bkp_3.dat f086_pat_id_bkp_4.dat
Move-Item f086_pat_id_bkp_2.dat f086_pat_id_bkp_3.dat
Move-Item f086_pat_id_bkp.dat f086_pat_id_bkp_2.dat
Copy-Item f086_pat_id.dat f086_pat_id_bkp.dat

Set-Location $env:application_production

echo "Done f086patid ..."
