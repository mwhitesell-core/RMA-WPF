#-------------------------------------------------------------------------------
# File 'create_new_doctors.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_new_doctors'
#-------------------------------------------------------------------------------

#
# CREATE THE NEW ASSIGNED DOCTORS FROM F021-AVAIL-DOCTOR-MSTR
#

echo ""
Get-Date
echo ""

Set-Location $pb_data
Remove-Item tmp_counters.*
$pipedInput = @"
create file tmp-counters
"@

$pipedInput | qutil++

Set-Location $env:application_production

Remove-Item u023*.sf*, r023*txt, r911*txt

echo " --- r911.qzc --- "
&$env:QUIZ r911
echo " --- u023a.qtc --- "
&$env:QTP u023a
echo " --- r023.qzu --- "
&$env:QUIZ r023
echo " --- r911a.qzc --- "
&$env:QUIZ r911a

Get-Content r911.txt | Out-Printer
Get-Content r023b.txt | Out-Printer
Get-Content r023c.txt | Out-Printer
Get-Content r023d.txt | Out-Printer
Get-Content r911a.txt | Out-Printer

echo ""
Get-Date
echo ""
exit
