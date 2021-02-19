#-------------------------------------------------------------------------------
# File 'steiner.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'steiner'
#-------------------------------------------------------------------------------

Set-Location $application_upl

Remove-Item steiner_a.sf*
Remove-Item steiner_b.sf*
Remove-Item steiner_ca.txt
Remove-Item steiner_cb.txt

echo " --- steiner_a.qzc --- "
&$env:QUIZ steiner_a
echo " --- steiner_b.qtc --- "
&$env:QTP steiner_b
echo " --- steiner_ca.qzc --- "
&$env:QUIZ steiner_ca
echo " --- steiner_cb.qzc --- "
&$env:QUIZ steiner_cb

Get-Content steiner_ca.txt | Out-Printer
Get-Content steiner_cb.txt | Out-Printer

Get-Content steiner_ca.txt | Out-Printer
Get-Content steiner_cb.txt | Out-Printer
