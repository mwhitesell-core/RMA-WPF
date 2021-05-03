#-------------------------------------------------------------------------------
# File 'create_adj_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_adj_claims'
#-------------------------------------------------------------------------------

Set-Location $env:pb_data
echo "Rolling over the adj_claim_file backup files ..."
#rm >/dev/null 2>/dev/null adj_claim_file_bkp.dat
#cp adj_claim_file.dat adj_claim_file_bkp.dat
Remove-Item adj_claim_file_bk9.dat
Move-Item -Force adj_claim_file_bk8.dat adj_claim_file_bk9.dat
Move-Item -Force adj_claim_file_bk7.dat adj_claim_file_bk8.dat
Move-Item -Force adj_claim_file_bk6.dat adj_claim_file_bk7.dat
Move-Item -Force adj_claim_file_bk5.dat adj_claim_file_bk6.dat
Move-Item -Force adj_claim_file_bk4.dat adj_claim_file_bk5.dat
Move-Item -Force adj_claim_file_bk3.dat adj_claim_file_bk4.dat
Move-Item -Force adj_claim_file_bk2.dat adj_claim_file_bk3.dat
Move-Item -Force adj_claim_file_bk1.dat adj_claim_file_bk2.dat
Copy-Item adj_claim_file.dat adj_claim_file_bk1.dat

Set-Location $env:application_production
echo ""
echo "CREATE AUTOMATIC ADJUSTMENT CLAIMS (U802.QTC)"
echo ""
$rcmd = $env:QTP + "u802"
Invoke-Expression $rcmd

echo ""
echo "CREATE THE ADJUSTED CLMDTL RECORDS (U030C)"
echo ""

$rcmd = $env:COBOL + "u030c"
Invoke-Expression $rcmd

echo ""
echo "CREATE THE AUTOMATIC ADJUSTMENT CLAIMS REPORT (R801A,B,C)"
echo ""

Remove-Item r801*.txt *> $null

$rcmd = $env:QUIZ + "r801a"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r801b"
Invoke-Expression $rcmd
$rcmd = $env:QUIZ + "r801c"
Invoke-Expression $rcmd

Get-ChildItem r801*

if ( $env:networkprinter -ne 'null'  )
{
   Get-Content r801a.txt | Out-Printer -Name $env:networkprinter
   Get-Content r801b.txt | Out-Printer -Name $env:networkprinter
}
#lp r801c.txt >/dev/null 2>/dev/null 

echo ""
echo "DELETE AND RECREATE THE ADJ_CLAIM_FILE"
echo ""

<#$pipedInput = @"
create file adj-claim-file
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+"adj_claim_file"
Invoke-Expression $rcmd
