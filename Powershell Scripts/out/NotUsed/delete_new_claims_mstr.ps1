#-------------------------------------------------------------------------------
# File 'delete_new_claims_mstr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'delete_new_claims_mstr'
#-------------------------------------------------------------------------------

echo "DELETE_NEW_CLAIMS_MSTR"
echo ""

echo "A\R FILE PURGE STAGE" # 1
echo ""
echo "DELETE ANY EXISTING `"NEW`" CLAIMS MASTER"
echo ""
echo ""
echo "HIT  `"NEWLINE`"  TO DELETE ANY `"NEW`" CLAIMS MSTR ..."
$garbage = Read-Host
echo ""

Set-Location $pb_data
Remove-Item f002_claims_mstr_new*
Remove-Item f002_claim_shadow_new*
