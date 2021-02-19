#-------------------------------------------------------------------------------
# File 'r____.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'r____'
#-------------------------------------------------------------------------------

Set-Location $pb_data
Remove-Item adj_claim_file_bkp.dat *> $null
Copy-Item adj_claim_file.dat adj_claim_file_bkp.dat

Set-Location $env:application_production
echo ""
echo "CREATE AUTOMATIC ADJUSTMENT CLAIMS (U802.QTC)"
echo ""
&$env:QTP u802

echo ""
echo "CREATE THE ADJUSTED CLMDTL RECORDS (U030C)"
echo ""

&$env:COBOL u030c

echo ""
echo "CREATE THE AUTOMATIC ADJUSTMENT CLAIMS REPORT (R801A,B,C)"
echo ""

Remove-Item r801*.txt *> $null

&$env:QUIZ r801a
&$env:QUIZ r801b
&$env:QUIZ r801c

Get-ChildItem r801*

Get-Content r801a.txt | Out-Printer *> $null
Get-Content r801b.txt | Out-Printer *> $null
#lp r801c.txt >/dev/null 2>/dev/null 

echo ""
echo "DELETE AND RECREATE THE ADJ_CLAIM_FILE"
echo ""

$pipedInput = @"
create file adj-claim-file
"@

$pipedInput | qutil++
