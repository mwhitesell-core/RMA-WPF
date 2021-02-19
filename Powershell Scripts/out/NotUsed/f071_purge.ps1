#-------------------------------------------------------------------------------
# File 'f071_purge.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'f071_purge'
#-------------------------------------------------------------------------------

echo "Starting u071 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QTP u071

echo "Ending u071 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $pb_data

Move-Item -Force f071_client_rma_claim_nbr $Env:root\foxtrot\purge\f071_client_rma_claim_nbr_orig
Move-Item -Force f071_client_rma_claim_nbr.idx $Env:root\foxtrot\purge\f071_client_rma_claim_nbr_orig.idx

Remove-Item f071_client_rma_claim_nbr.dat

. .\createfiles.com

echo "Starting u071a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $Env:root\charly\purge

&$env:QTP u071a


echo "Ending u071a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
