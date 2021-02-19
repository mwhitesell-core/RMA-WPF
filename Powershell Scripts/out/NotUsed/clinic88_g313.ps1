#-------------------------------------------------------------------------------
# File 'clinic88_g313.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'clinic88_g313'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\production

Remove-Item clinic*.sf
Remove-Item clinic*.sfd
Remove-Item clinic*.ps
Remove-Item clinic*.psd

echo ""
Get-Date
echo ""

&$env:QTP clinic88_g313 20110401

Remove-Item clinic88_g313.txt

&$env:QUIZ clinic88_g313

echo ""
Get-Date
echo ""
