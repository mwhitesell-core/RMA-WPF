#-------------------------------------------------------------------------------
# File 'after_yearend_doc_deletion.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'after_yearend_doc_deletion'
#-------------------------------------------------------------------------------

Set-Location $pb_data

Remove-Item $pb_data\f022_deleted_doc_mstr.dat
$pipedInput = @"
create file f022-deleted-doc-mstr
"@

$pipedInput | qutil++ *> $null

# CONVERSION ERROR (expected, #8): bcheck.
# bcheck $pb_data/tmp_counters
$pipedInput = @"
create file tmp-counters
"@

$pipedInput | qutil++ *> $null

Set-Location $application_upl

&$env:QTP u023a
&$env:QUIZ r023b
&$env:QUIZ r023c
Get-Content ru023a.txt | Out-Printer
Get-Content ru023b.txt | Out-Printer
Get-Content ru023a.txt | Out-Printer
Get-Content ru023a.txt | Out-Printer
Get-Content ru023a.txt | Out-Printer
