#-------------------------------------------------------------------------------
# File 'claims_mstr_verify_old_OLD.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_mstr_verify_old_OLD'
#-------------------------------------------------------------------------------

echo "CLAIMS_MSTR_VERIFY_OLD"
echo ""

echo "A\R FILE PURGE STAGE" # 3
echo ""
echo "HITNEWLINE TO VERIFYOLD CLAIMS MSTR"
 $garbage = Read-Host
echo ""
echo "PROGRAMR071 NOW LOADING ..."

&$env:COBOL r071
# CONVERSION ERROR (expected, #12): bcheck.
# bcheck -n $pb_data/f002_claim_shadow > rv071        

echo ""
Get-ChildItem -Force r071
echo ""
Get-Date

Get-Content r071 | Out-Printer
Get-Content rv071 | Out-Printer
