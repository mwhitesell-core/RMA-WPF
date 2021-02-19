#-------------------------------------------------------------------------------
# File 'f086patidmc.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'f086patidmc'
#-------------------------------------------------------------------------------

# /bin/ksh
# f086patid
# 00/jul/26 B.E. - changed backup of file f086_pat_id.dat to keep 5 backups

echo "Running f086patid ..."

Get-ChildItem $pb_prod\f086_pat_id.dat

Set-Location $Env:root\home\rma
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma1
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma2
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma3
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma4
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma5
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma6
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma7
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma8
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma9
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma10
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma11
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma12
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma13
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma14
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma15
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma16
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma17
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma18
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma19
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma20
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma21
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma22
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma23
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma24
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma25
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma26
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma27
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma28
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma29
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma30
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma31
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma32
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma33
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma34
&$env:cmd\f086delcopymc

Set-Location $Env:root\home\rma35
&$env:cmd\f086delcopymc

Set-Location $env:application_production

echo "Done f086patid ..."
