#-------------------------------------------------------------------------------
# File 'create_adj_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'create_adj_claims'
#-------------------------------------------------------------------------------

Set-Location $pb_data
echo "Rolling over the adj_claim_file backup files ..."
#rm >/dev/null 2>/dev/null adj_claim_file_bkp.dat
#cp adj_claim_file.dat adj_claim_file_bkp.dat
Remove-Item adj_claim_file_bk9.dat
Move-Item adj_claim_file_bk8.dat adj_claim_file_bk9.dat
Move-Item adj_claim_file_bk7.dat adj_claim_file_bk8.dat
Move-Item adj_claim_file_bk6.dat adj_claim_file_bk7.dat
Move-Item adj_claim_file_bk5.dat adj_claim_file_bk6.dat
Move-Item adj_claim_file_bk4.dat adj_claim_file_bk5.dat
Move-Item adj_claim_file_bk3.dat adj_claim_file_bk4.dat
Move-Item adj_claim_file_bk2.dat adj_claim_file_bk3.dat
Move-Item adj_claim_file_bk1.dat adj_claim_file_bk2.dat
Copy-Item adj_claim_file.dat adj_claim_file_bk1.dat

Set-Location $application_production
echo ""
echo "CREATE AUTOMATIC ADJUSTMENT CLAIMS (U802.QTC)"
echo ""
qtp++ $obj\u802

echo ""
echo "CREATE THE ADJUSTED CLMDTL RECORDS (U030C)"
echo ""

cobrun++ $obj\u030c

echo ""
echo "CREATE THE AUTOMATIC ADJUSTMENT CLAIMS REPORT (R801A,B,C)"
echo ""

Remove-Item r801*.txt  > $null

$pipedInput = @"
exec $obj/r801a.qzc 
exec $obj/r801b.qzc 
exec $obj/r801c.qzc 
"@

$pipedInput | quiz++

Get-ChildItem r801*

Get-Contents r801a.txt| Out-Printer  > $null
Get-Contents r801b.txt| Out-Printer  > $null
#lp r801c.txt >/dev/null 2>/dev/null 

echo ""
echo "DELETE AND RECREATE THE ADJ_CLAIM_FILE"
echo ""

$pipedInput = @"
create file adj-claim-file
"@

$pipedInput | qutil++
