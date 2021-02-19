#-------------------------------------------------------------------------------
# File 'application_of_rat_70_part1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'application_of_rat_70_part1'
#-------------------------------------------------------------------------------

echo "APPLICATION_OF_RAT_70"
echo ""
echo "**   APPLICATION OF OHIP REMITTANCE ADVICE TAPE   ** WITHOUT BACKUP"
echo ""
echo "-  W A R N I N G  -"
echo ""
echo "IF THIS IS THE 1ST PROCESSING OF THIS RAT TAPE"
echo "THEN CONVERT_RAT_TO_ASCII MUST BE RUN TO CONVERT"
echo "THE DISK FILE FROMEBCDIC TOASCII"
echo ""

echo ""
echo "-  WARNING  -"
echo "DOCTOR CASH FILE AND CLAIMS MASTER"
echo "WILL BE UPDATED BY THIS RUN"
echo ""
echo "A DOCTOR CASH BACKUP SHOULD HAVE ALREADY BEEN RUN --BEFORE-- THIS UPDATE ..."

echo ""

echo "Now starting U030 for Clinic 71 ..."
Get-Date
Set-Location $env:application_production\71
Get-Location
Remove-Item u030_71.ls *> $null
&$env:cmd\u030 71 *> u030_71.ls

echo "Now starting U030 for Clinic 72 ..."
Get-Date
Set-Location $env:application_production\72
Get-Location
Remove-Item u030_72.ls *> $null
&$env:cmd\u030 72 *> u030_72.ls

echo "Now starting U030 for Clinic 73 ..."
Get-Date
Set-Location $env:application_production\73
Get-Location
Remove-Item u030_73.ls *> $null
&$env:cmd\u030 73 *> u030_73.ls

echo "Now starting U030 for Clinic 74 ..."
Get-Date
Set-Location $env:application_production\74
Get-Location
Remove-Item u030_74.ls *> $null
&$env:cmd\u030 74 *> u030_74.ls

echo "Now starting U030 for Clinic 75 ..."
Get-Date
Set-Location $env:application_production\75
Get-Location
Remove-Item u030_75.ls *> $null
&$env:cmd\u030 75 *> u030_75.ls
Get-Date
