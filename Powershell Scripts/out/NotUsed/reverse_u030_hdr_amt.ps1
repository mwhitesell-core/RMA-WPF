#-------------------------------------------------------------------------------
# File 'reverse_u030_hdr_amt.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'reverse_u030_hdr_amt'
#-------------------------------------------------------------------------------



echo "Now starting U030 reverse for Clinic 22 ..."
Get-Date
Set-Location $env:application_production
Remove-Item u030_reverse.ls *> $null
&$env:cmd\u030bb_reverse 22 *> u030_reverse.ls

echo "Now starting U030 reverse for Clinic 61 ..."
Get-Date
Set-Location $env:application_production\61
Get-Location
Remove-Item u030_61_reverse.ls *> $null
&$env:cmd\u030bb_reverse 61 *> u030_61_reverse.ls

echo "Now starting U030 reverse for Clinic 62 ..."
Get-Date
Set-Location $env:application_production\62
Get-Location
Remove-Item u030_62_reverse.ls *> $null
&$env:cmd\u030bb_reverse 62 *> u030_62_reverse.ls

echo "Now starting U030 reverse for Clinic 63 ..."
Get-Date
Set-Location $env:application_production\63
Get-Location
Remove-Item u030_63_reverse.ls *> $null
&$env:cmd\u030bb_reverse 63 *> u030_63_reverse.ls

echo "Now starting U030 reverse for Clinic 64 ..."
Get-Date
Set-Location $env:application_production\64
Get-Location
Remove-Item u030_64_reverse.ls *> $null
&$env:cmd\u030bb_reverse 64 *> u030_64_reverse.ls

echo "Now starting U030 reverse for Clinic 65 ..."
Get-Date
Set-Location $env:application_production\65
Get-Location
Remove-Item u030_65_reverse.ls *> $null
&$env:cmd\u030bb_reverse 65 *> u030_65_reverse.ls
Get-Date

echo "Now starting U030 reverse for Clinic 80 ..."
Get-Date
Set-Location $env:application_production\80
Get-Location
Remove-Item u030_80_reverse.ls *> $null
&$env:cmd\u030bb_reverse 80 *> u030_80_reverse.ls

echo "Now starting U030 reverse for Clinic 81 ..."
Get-Date
Set-Location $env:application_production\81
Get-Location
Remove-Item u030_81_reverse.ls *> $null
&$env:cmd\u030bb_reverse 81 *> u030_81_reverse.ls

echo "Now starting U030 reverse for Clinic 82 ..."
Get-Date
Set-Location $env:application_production\82
Get-Location
Remove-Item u030_82_reverse.ls *> $null
&$env:cmd\u030bb_reverse 82 *> u030_82_reverse.ls

echo "Now starting U030 reverse for Clinic 83 ..."
Get-Date
Set-Location $env:application_production\83
Get-Location
Remove-Item u030_83_reverse.ls *> $null
&$env:cmd\u030bb_reverse 83 *> u030_83_reverse.ls

echo "Now starting U030 reverse for Clinic 90 ..."
Get-Date
Set-Location $env:application_production\90
Get-Location
Remove-Item u030_90_reverse.ls *> $null
&$env:cmd\u030bb_reverse 90 *> u030_90_reverse.ls


echo "Finish..................for all clinics ..."
Get-Date
