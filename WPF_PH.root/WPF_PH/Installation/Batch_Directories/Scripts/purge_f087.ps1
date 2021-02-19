#-------------------------------------------------------------------------------
# File 'purge_f087.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f087'
#-------------------------------------------------------------------------------

#  PURGE f087 file
#  Deletes f087 if f002-claims master does not exist for the rejects 
#
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2014/Jul/06  yas  - change to save original file from /foxtrot/purge to /charly/purge

#cd $env:pb_prod

Set-Location \\$Env:root\charly\purge

Remove-Item $env:pb_prod\purgef087.log *> $null

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily 1 purge_f087"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily$1.ls

echo "Purge f087 -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $env:pb_prod\purgef087.log

$rcmd = $env:QTP + "purge_unlof087"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef087.log

#Set-Location $env:pb_data

#Move-Item -Force f087_submitted_rejected_claims_hdr.dat \\$Env:root\charly\purge\f087_submitted_rejected_claims_hdr.dat
#Move-Item -Force f087_submitted_rejected_claims_hdr.idx \\$Env:root\charly\purge\f087_submitted_rejected_claims_hdr.idx
#Move-Item -Force f087_submitted_rejected_claims_dtl.dat \\$Env:root\charly\purge\f087_submitted_rejected_claims_dtl.dat
#Move-Item -Force f087_submitted_rejected_claims_dtl.idx \\$Env:root\charly\purge\f087_submitted_rejected_claims_dtl.idx

#echo "--- create files ---"
<#$pipedInput = @"
create file f087-submitted-rejected-claims-hdr
create file f087-submitted-rejected-claims-dtl
"@

$pipedInput | qutil++#>
#$rcmd = $env:TRUNCATE+ "f087_submitted_rejected_claims_hdr"
#Invoke-Expression $rcmd
#$rcmd = $env:TRUNCATE+ "f087_submitted_rejected_claims_dtl"
#Invoke-Expression $rcmd

#Set-Location \\$Env:root\charly\purge

#$rcmd = $env:QTP + "purge_relof087"
#Invoke-Expression $rcmd *>>$env:pb_prod\purgef087.log

echo "Purge f087 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >>$env:pb_prod\purgef087.log
