#-------------------------------------------------------------------------------
# File 'claims_mstr_verify_new.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
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

Set-Location $root\charly\purge

$pipedInput = @"
20150630
Y
"@

$pipedInput | cobrun++ $obj\r073

bcheck++ $pb_data\f002_claim_shadow  > rv073_after

echo ""
Get-ChildItem -Force r073
echo ""
Get-Date

Move-Item r073 r073_after_claims_purge
Get-Contents r073| Out-Printer
Get-Contents r073_after_claims_purge| Out-Printer
Get-Contents rv073_after| Out-Printer
