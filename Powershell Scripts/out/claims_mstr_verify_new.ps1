#-------------------------------------------------------------------------------
# File 'claims_mstr_verify_new.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'claims_mstr_verify_new'
#-------------------------------------------------------------------------------

echo "CLAIMS_MSTR_VERIFY_NEW"
echo ""

echo "A\R FILE PURGE STAGE" # 4
echo "NOTE -- STAGE" #2 MUST HAVE COMPLETED NEW THIS RUN !!!
echo ""
#echo  HIT "NEWLINE" TO VERIFY 'NEW' CLAIMS MSTR
#read garbage
echo ""
echo "PROGRAMR073 NOW LOADING ..."

Set-Location \\$Env:root\charly\purge

$rcmd = $env:COBOL + "r073 20150630 Y"
Invoke-Expression $rcmd

# CONVERSION ERROR (expected, #19): bcheck.
# bcheck -n $pb_data/f002_claim_shadow > rv073_after

echo ""
Get-ChildItem -Force r073
echo ""
Get-Date

Move-Item -Force r073 r073_after_claims_purge
Get-Content r073 | Out-Printer
Get-Content r073_after_claims_purge | Out-Printer
Get-Content rv073_after | Out-Printer
