#-------------------------------------------------------------------------------
# File 'moh1_icu.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'moh1_icu'
#-------------------------------------------------------------------------------

Remove-Item moh*icu.sf* *> $null
Remove-Item moh*icu.txt *> $null
Remove-Item moh*icu. *> $null
echo ""
echo "RUN ALTERNATIVE FUNDING REPORT FOR CLINIC 85........"
echo ""

echo "JOB STARTING ... $(Get-Date -uformat `"%T`")"

&$env:QUIZ moh1_icu 20040630 20040630

echo ""
echo "Finish Time $(Get-Date -uformat `"%T`")"

Move-Item -Force moh1b_icu.txt mohbicu
# yas 2002/05/02 cancelled print per Mary's request it is to be scan instead 
#lp mohbicu
#lp mohbicu
#lp moh_icu.ls
