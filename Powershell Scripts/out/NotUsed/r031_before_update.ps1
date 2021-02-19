#-------------------------------------------------------------------------------
# File 'r031_before_update.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r031_before_update'
#-------------------------------------------------------------------------------


# report r031 payments by clinic compare against R997_xx "AGE PAYMENT" column

Set-Location $pb_prod
Remove-Item r031*
&$env:QUIZ r031_before_update
echo ""
echo ""
Get-Content r031_before_update.txt | Out-Printer
