#-------------------------------------------------------------------------------
# File 'clinic22_g310.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'clinic22_g310'
#-------------------------------------------------------------------------------

Set-Location $Env:root\alpha\rmabill\rmabill101c\production

echo ""
Get-Date
echo ""

&$env:QTP clinic22_g310_paid 20110314 20110314

Remove-Item clinic22_g310_adjust.txt
Remove-Item clinic22_g310_paid_byloc.txt
Remove-Item clinic22_g310_minus_misc.txt

&$env:QUIZ clinic22_g310_adjust
&$env:QUIZ clinic22_g310_paid_byloc
&$env:QUIZ clinic22_g310_minus_misc

echo ""
Get-Date
echo ""
