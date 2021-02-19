#-------------------------------------------------------------------------------
# File 'application_of_rat_60_part1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'application_of_rat_60_part1'
#-------------------------------------------------------------------------------

echo "APPLICATION_OF_RAT_60"
echo ""
echo "**   APPLICATION OF OHIP REMITTANCE ADVICE TAPE   ** WITHOUT BACKUP"
echo ""
echo "-  W A R N I N G  -"
echo ""
echo "IF THIS IS THE 1ST PROCESSING OF THIS RAT TAPE"
echo "THEN CONVERT_RAT_TO_ASCII MUST BE RUN TO CONVERT"
echo "THE DISK FILE FROMEBCDIC TOASCII"
echo ""
#echo   'IF FILE HAS BEEN CONVERTED ONCE THEN  HIT   "NEWLINE"   TO CONTINUE ...'
# read garbage

echo ""
echo "-  WARNING  -"
echo "DOCTOR CASH FILE AND CLAIMS MASTER"
echo "WILL BE UPDATED BY THIS RUN"
echo ""
echo "A DOCTOR CASH BACKUP SHOULD HAVE ALREADY BEEN RUN --BEFORE-- THIS UPDATE ..."

#echo     'HIT   "NEWLINE"   TO INITIATE UPDATE PROGRAM ...'
# read garbage
echo ""
#echo  'PROGRAM "U030" NOW LOADING ...'

#echo 'Now starting U030 for Clinic 60 ...'a
#date
#cd  $application_production/60
#pwd
#rm   >/dev/null  2>/dev/null  u030_60.ls
#$cmd/u030_60 1>u030_60.ls 2>&1

echo "Now starting U030 for Clinic 61 ..."
Get-Date
Set-Location $env:application_production\61
Get-Location
Remove-Item u030_61.ls *> $null
&$env:cmd\u030 61 *> u030_61.ls

echo "Now starting U030 for Clinic 62 ..."
Get-Date
Set-Location $env:application_production\62
Get-Location
Remove-Item u030_62.ls *> $null
&$env:cmd\u030 62 *> u030_62.ls

echo "Now starting U030 for Clinic 63 ..."
Get-Date
Set-Location $env:application_production\63
Get-Location
Remove-Item u030_63.ls *> $null
&$env:cmd\u030 63 *> u030_63.ls

echo "Now starting U030 for Clinic 64 ..."
Get-Date
Set-Location $env:application_production\64
Get-Location
Remove-Item u030_64.ls *> $null
&$env:cmd\u030 64 *> u030_64.ls

echo "Now starting U030 for Clinic 65 ..."
Get-Date
Set-Location $env:application_production\65
Get-Location
Remove-Item u030_65.ls *> $null
&$env:cmd\u030 65 *> u030_65.ls

echo "Now starting U030 for Clinic 66 ..."
Get-Date
Set-Location $env:application_production\66
Get-Location
Remove-Item u030_66.ls *> $null
&$env:cmd\u030 66 *> u030_66.ls
Get-Date
