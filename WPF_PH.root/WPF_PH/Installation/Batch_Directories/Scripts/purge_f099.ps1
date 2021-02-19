#-------------------------------------------------------------------------------
# File 'purge_f099.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f099'
#-------------------------------------------------------------------------------

#  PURGE f099 file
#
#
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge

#cd $env:pb_prod

Set-Location $Env:root\charly\purge

Remove-Item $env:pb_prod\purgef099.log *> $null

echo "Purge f099 -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $env:pb_prod\purgef099.log

$rcmd = $env:QTP + "purge_unlof099"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef099.log

Set-Location $env:pb_data

Move-Item -Force f099_group_claim_mstr.dat $Env:root\foxtrot\purge\f099_group_claim_mstr.dat
Move-Item -Force f099_group_claim_mstr.idx $Env:root\foxtrot\purge\f099_group_claim_mstr.idx

echo "--- create files ---"
<#$pipedInput = @"
create file f099-group-claim-mstr
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+ "f110_compensation_history"
Invoke-Expression $rcmd

Set-Location $Env:root\charly\purge

$rcmd = $env:QTP + "purge_relof099"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef099.log


echo "Purge f099 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef099.log
