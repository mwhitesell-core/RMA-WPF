#-------------------------------------------------------------------------------
# File 'moh1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'moh1'
#-------------------------------------------------------------------------------

Remove-Item moh*.sf* *> $null
Remove-Item moh*.txt *> $null
echo ""
echo "RUN ALTERNATIVE FUNDING REPORT ........"
echo ""

echo "JOB STARTING ... $(Get-Date -uformat `"%T`")"

&$env:QUIZ moh1a 220000000 229999999 970723 970723

&$env:QTP moh1a
&$env:QUIZ moh1
echo ""
echo "FINISH TIME $(Get-Date -uformat `"%T`")"

Move-Item -Force moh1a.txt moh1a
Get-Content moh1a | Out-Printer
Get-Content moh1a | Out-Printer
