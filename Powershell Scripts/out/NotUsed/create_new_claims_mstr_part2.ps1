#-------------------------------------------------------------------------------
# File 'create_new_claims_mstr_part2.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'create_new_claims_mstr_part2'
#-------------------------------------------------------------------------------

echo "CREATE_NEW_CLAIMS_MSTR_PART2"
#  modification history
#  2002/jul/06 B.E. - changed to put orig claim and processing of subifle
#                    on /dyad/purge disk
#  2002/nov/14 M.C. - include clinic 95 as well  
#  2003/Jun/16 yas  - include clinics 91,92,93,94 and 96
#  2005/jul/06 M.C. - changed to put orig claim and processing of subfile
#                     on /charly/purge disk
#  2006/Jun/29 yas  - include clinic 98                     
#  2011/Feb/16 yas  - comment out the printing of the reports
#  2011/Feb/17 MC1  - move the 3 files from /charly to /foxtrot instead as suggested by Brad
#  2011/Feb/22 MC2  - save f002_claims_extra & f085_rejected_claims as well in /foxtrot       
#  2011/Feb/22 yas  - include "claims_mstr_verify_new" in this macro  
#  2011/May/10 MC3  - copy f002_claims_extra & f085_rejected_claims instead of move
#                     unload & reload f002_claims_extra & f085_rejected_claims  
#  2011/Jun/06 MC4  - save f071 & f099 files as well in /foxtrot and  unload & reload f071 & f099 files  

#############################################################################
#following "claims_mstr_verify_new" is add Feb 22, 2011

echo "Starting r073 Time is $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"

echo "CLAIMS_MSTR_VERIFY_NEW"

Set-Location $Env:root\charly\purge

&$env:COBOL r073 20101231 Y

# CONVERSION ERROR (expected, #32): bcheck.
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

echo "end of part2 claims purge"
