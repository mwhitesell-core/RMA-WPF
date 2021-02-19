#-------------------------------------------------------------------------------
# File 'claims_mstr_verify_new_OLD.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_mstr_verify_new_OLD'
#-------------------------------------------------------------------------------

echo "CLAIMS_MSTR_VERIFY_NEW"
echo ""

echo "A\R FILE PURGE STAGE" # 4
echo "NOTE -- STAGE" #2 MUST HAVE COMPLETED NEW THIS RUN !!!
echo ""
echo "HITNEWLINE TO VERIFYNEW CLAIMS MSTR"
$garbage = Read-Host
echo ""
echo "PROGRAMR073 NOW LOADING ..."

&$env:COBOL r073
# CONVERSION ERROR (expected, #13): bcheck.
# bcheck -n $pb_data/f002_claim_shadow_new > rv073

echo ""
Get-ChildItem -Force r073
echo ""
Get-Date

Get-Content r073 | Out-Printer
Get-Content rv073 | Out-Printer
