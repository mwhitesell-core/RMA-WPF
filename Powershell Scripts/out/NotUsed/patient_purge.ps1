#-------------------------------------------------------------------------------
# File 'patient_purge.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'patient_purge'
#-------------------------------------------------------------------------------

#  2005/jul/06 M.C. - changed to the processing of subfile
#                     on /charly/purge disk
#



echo "PATIENT_PURGE"
echo ""
echo "PATIENT FILE PURGE STAGE # 1"
echo "NOTE -- THE Backup MUST HAVE BEEN RUN !!!"
echo ""
echo "HIT `"NEWLINE`" TO PURGE `"INACTIVE`" PATIENTS ..."
$garbage = Read-Host
echo ""

echo ""
Get-Date
echo ""

##cd $application_production
Set-Location $Env:root\charly\purge

# CONVERSION ERROR (expected, #23): bcheck.
# bcheck -n $pb_data/f010_pat_mstr > f010_verify_before


echo "PROGRAM `"U099`" NOW LOADING ..."

echo ""
Get-Date
echo ""
#cobrun $obj/u099
&$env:QTP u099 20120101 > u099.log

&$env:QUIZ r099a
&$env:QUIZ r099b
&$env:QUIZ r099c
&$env:QUIZ r099d

Get-ChildItem ru099.txt

echo ""
Get-Date
echo ""

Get-Content ru099.txt | Out-Printer
Get-Content u099.log | Out-Printer

Get-Date
