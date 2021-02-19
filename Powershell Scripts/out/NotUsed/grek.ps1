#-------------------------------------------------------------------------------
# File 'grek.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'grek'
#-------------------------------------------------------------------------------

Set-Location $env:application_production

Remove-Item grek_a.sf*
Remove-Item grek_b.sf*
Remove-Item grek_ca.txt
Remove-Item grek_cb.txt

echo " --- grek_a.qzc --- "
&$env:QUIZ grek_a
echo " --- grek_b.qtc --- "
&$env:QTP grek_b
echo " --- grek_ca.qzc --- "
&$env:QUIZ grek_ca
echo " --- grek_cb.qzc --- "
&$env:QUIZ grek_cb

Get-Content grek_ca.txt | Out-Printer
Get-Content grek_cb.txt | Out-Printer

Get-Content grek_ca.txt | Out-Printer
Get-Content grek_cb.txt | Out-Printer
