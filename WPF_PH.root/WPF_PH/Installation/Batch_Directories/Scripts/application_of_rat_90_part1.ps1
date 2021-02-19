#-------------------------------------------------------------------------------
# File 'application_of_rat_90_part1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'application_of_rat_90_part1'
#-------------------------------------------------------------------------------

echo "APPLICATION_OF_RAT_90"

echo ""

echo "**   APPLICATION OF Ohip REMITTANCE ADVICE TAPE   ** WITHOUT BACKUP"
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


echo "HIT   `"NEWLINE`"   TO INITIATE UPDATE PROGRAM ..."
 $garbage = Read-Host
echo ""
echo "PROGRAMU030 NOW LOADING ..."

Set-Location $env:application_production\90
Remove-Item u030_90.ls *> $null
&$env:cmd\u030 90 *> u030_90.ls
Get-Date
