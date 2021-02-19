#-------------------------------------------------------------------------------
# File 'yas_verify.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas_verify'
#-------------------------------------------------------------------------------

echo "CLAIMS_MSTR_VERIFY_OLD"
echo ""

&$env:COBOL r071 20090630 Y

# CONVERSION ERROR (expected, #9): bcheck.
# bcheck -n $pb_data/f002_claim_shadow > rv071_before

echo ""
Get-ChildItem -Force r071
echo ""
Get-Date

Move-Item -Force r071 r071_before_claims_purge
Get-Content r071_before_claims_purge | Out-Printer
Get-Content rv071_before | Out-Printer
