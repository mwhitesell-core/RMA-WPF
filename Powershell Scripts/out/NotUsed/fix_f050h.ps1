#-------------------------------------------------------------------------------
# File 'fix_f050h.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'fix_f050h'
#-------------------------------------------------------------------------------


Set-Location 82
Get-Location
echo "hit"
$garbage = Read-Host
utouch brad82
&$env:QTP u014_f050 82 *> u014_f050_82.log
Set-Location ..
Get-Location

echo "hit"
$garbage = Read-Host

Set-Location 83
Get-Location
echo "hit"
$garbage = Read-Host
utouch brad83
&$env:QTP u014_f050 83 *> u014_f050_83.log
Set-Location ..
Get-Location


echo "hit"
$garbage = Read-Host

Set-Location 86
Get-Location
echo "hit"
$garbage = Read-Host
utouch brad86
&$env:QTP u014_f050 86 *> u014_f050_86.log
Set-Location ..
Get-Location


echo "hit"
$garbage = Read-Host

Set-Location 60
Get-Location
echo "hit"
$garbage = Read-Host
utouch brad60
&$env:QTP u014_f050 60 *> u014_f050_60.log
Set-Location ..
Get-Location


echo "hit"
$garbage = Read-Host

Set-Location 70
Get-Location
echo "hit"
$garbage = Read-Host
utouch brad70
&$env:QTP u014_f050 70 *> u014_f050_70.log
Set-Location ..
Get-Location


echo "DONE"
