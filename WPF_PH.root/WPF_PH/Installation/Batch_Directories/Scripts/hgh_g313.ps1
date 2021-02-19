#-------------------------------------------------------------------------------
# File 'hgh_g313.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'hgh_g313'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill${env:RMABILL_VERS}\production

Remove-Item hgh*.sf
Remove-Item hgh*.sfd
Remove-Item hgh*.ps
Remove-Item hgh*.psd

echo ""
Get-Date
echo ""

&$env:QTP hgh_g313 20160701

Remove-Item hgh_g310.txt

&$env:QUIZ
 hgh_g313

 #Core - Added to rename report according to quiz file
Get-Content hgh_g313.txt > hgh_g310.txt

echo ""
Get-Date
echo ""
