#-------------------------------------------------------------------------------
# File 'yas_claims_mstr.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'yas_claims_mstr'
#-------------------------------------------------------------------------------

#### moira  I deleted everything above and start running it from here

Set-Location $pb_data

Remove-Item f002_claims_mstr
Remove-Item f002_claims_mstr.idx
Remove-Item f002_claims_mstr.dat

Remove-Item f002_claim_shadow
Remove-Item f002_claim_shadow.idx
Remove-Item f002_claim_shadow.dat


. .\createfiles.com


#############################################################################

echo "Starting u072a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

Set-Location $Env:root\charly\purge

&$env:QTP u072a

echo "Ending u072a Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

#ls -l  ru072
#lp ru072

#############################################################################
#following "claims_mstr_verify_new" is add Feb 22, 2011

echo "Starting r073 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo "CLAIMS_MSTR_VERIFY_NEW"

Set-Location $Env:root\charly\purge

&$env:COBOL r073 20121231 Y

# CONVERSION ERROR (expected, #44): bcheck.
# bcheck -n $pb_data/f002_claim_shadow > rv073_after

echo ""
Get-ChildItem -Force r073
echo ""
Get-Date

Move-Item -Force r073 r073_after_claims_purge
Get-Content r073 | Out-Printer
Get-Content r073_after_claims_purge | Out-Printer
Get-Content rv073_after | Out-Printer

echo "Ending r073 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

## the followings are added by MC on 2011/May/10
#############################################################################
echo "Starting time to unload f002extra and f085 files $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QUIZ unlof002extra
&$env:QUIZ unlof085

Set-Location $pb_data

Remove-Item f002_claims_extra.idx
Remove-Item f002_claims_extra
Remove-Item f002_claims_extra.dat

Remove-Item f085_rejected_claims.idx
Remove-Item f085_rejected_claims
Remove-Item f085_rejected_claims.dat

. .\createfiles.com

Set-Location $Env:root\charly\purge

&$env:QTP relof002extra
&$env:QTP relof085

echo "Ending time to reload f002extra and f085 files $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

## the followings are added by MC on 2011/Jun/06
#############################################################################
echo "Starting time to unload f071 and f099 files $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

&$env:QUIZ unlof071
&$env:QUIZ unlof099

Set-Location $pb_data

Remove-Item f071_client_rma_claim_nbr.idx
Remove-Item f071_client_rma_claim_nbr
Remove-Item f071_client_rma_claim_nbr.dat

Remove-Item f099_group_claim_mstr.dat
Remove-Item f099_group_claim_mstr.idx

. .\createfiles.com

$pipedInput = @"
create file f099-group-claim-mstr
"@

$pipedInput | qutil++

Set-Location $Env:root\charly\purge

&$env:QTP relof071
&$env:QTP relof099

echo "Ending time to reload f071 and  f099 files  $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
