#-------------------------------------------------------------------------------
# File 'moh1_81y2k.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'moh1_81y2k'
#-------------------------------------------------------------------------------

Remove-Item moh*icu.sf* *> $null
Remove-Item moh*icu.txt *> $null
Remove-Item moh*icu. *> $null
echo ""
echo "RUN ALTERNATIVE FUNDING REPORT FOR CLINIC 81........"
echo ""

echo "JOB STARTING ... $(Get-Date -uformat `"%T`")"

&$env:QUIZ moh1_81y2k 20011112 20011112

echo ""
echo "Finish Time $(Get-Date -uformat `"%T`")"

Move-Item -Force moh1b_icu.txt mohbicu
Get-Content mohbicu | Out-Printer
Get-Content mohbicu | Out-Printer
Get-Content moh_icu.ls | Out-Printer
