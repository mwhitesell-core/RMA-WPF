#-------------------------------------------------------------------------------
# File 'restart_claims_moira.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'restart_claims_moira'
#-------------------------------------------------------------------------------

echo "Starting u072a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $Env:root\charly\purge

&$env:QTP u072a

echo "Ending u072a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#############################################################################

echo "Starting u071 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP u071

echo "Ending u071 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#############################################################################

Set-Location $pb_data

Move-Item -Force f071_client_rma_claim_nbr $Env:root\foxtrot\purge\f071_client_rma_claim_nbr_orig
Move-Item -Force f071_client_rma_claim_nbr.idx $Env:root\foxtrot\purge\f071_client_rma_claim_nbr_orig.idx

Remove-Item f071_client_rma_claim_nbr.dat

. .\createfiles.com


echo "Rebuild F071 file"

echo "Starting u071a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $Env:root\charly\purge

&$env:QTP u071a

echo "Ending u071a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#############################################################################

echo "CLAIMS_MSTR_VERIFY_NEW"

Set-Location $Env:root\charly\purge

&$env:COBOL r073 20080701 Y

# CONVERSION ERROR (expected, #50): bcheck.
# bcheck -n $pb_data/f002_claim_shadow > rv073_after

echo ""
Get-ChildItem -Force r073
echo ""
Get-Date

Move-Item -Force r073 r073_after_claims_purge
Get-Content r073 | Out-Printer
Get-Content r073_after_claims_purge | Out-Printer
Get-Content rv073_after | Out-Printer
