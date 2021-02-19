#-------------------------------------------------------------------------------
# File 'application_of_rat_24_part1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'application_of_rat_24_part1'
#-------------------------------------------------------------------------------

echo "APPLICATION_OF_RAT_24"
echo ""
echo "**   APPLICATION OF OHIP REMITTANCE ADVICE TAPE   ** WITHOUT BACKUP"
echo ""
echo "-  W A R N I N G  -"
echo ""
echo "IF THIS IS THE 1ST PROCESSING OF THIS RAT TAPE"
echo "THENCONVERT_RAT_TO_ASCII MUST BE RUN TO CONVERT"
echo "THE DISK FILE FROMEBCDIC TOASCII"
echo ""
#echo   'IF FILE HAS BEEN CONVERTED ONCE THEN  HIT   "NEWLINE"   TO CONTINUE .'
#read garbage

echo ""
echo "-  WARNING  -"
echo "DOCTOR REVENUE FILE AND CLAIMS MASTER"
echo "WILL BE UPDATED BY THIS RUN"
echo ""
echo "A DOCTOR REVENUE BACKUP SHOULD HAVE ALREADY BEEN RUN --BEFORE-- THIS UPDATE ..."

#echo     'HIT   "NEWLINE"   TO INITIATE UPDATE PROGRAM ...'
# read garbage
echo ""
echo "PROGRAM `"U030`" NOW LOADING ..."

Set-Location $env:application_production\24
Remove-Item u030.ls *> $null
&$env:cmd\u030 24 *> u030_24.ls
Get-Date
