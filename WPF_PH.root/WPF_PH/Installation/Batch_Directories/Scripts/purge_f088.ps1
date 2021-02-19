#-------------------------------------------------------------------------------
# File 'purge_f088.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f088'
#-------------------------------------------------------------------------------

#  PURGE f088 file
#  Delete f088 records if f002-claims master does not exist for the rejects 
#
#  2013/Jan/10  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2014/Jul/06  yas  - change to save original file from /foxtrot/purge to /charly/purge

#cd $env:pb_prod
Set-Location \\$Env:root\charly\purge

Remove-Item $env:pb_prod\purgef088.log *> $null

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily 1 purge_f088"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily$1.ls

echo "Purge f088 -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > $env:pb_prod\purgef088.log

$rcmd = $env:QTP + "purge_unlof088"
Invoke-Expression $rcmd *>>$env:pb_prod\purgef088.log

#Set-Location $env:pb_data

#Move-Item -Force f088_rat_rejected_claims_hist_hdr.dat \\$Env:root\charly\purge\f088_rat_rejected_claims_hist_hdr.dat
#Move-Item -Force f088_rat_rejected_claims_hist_hdr.idx \\$Env:root\charly\purge\f088_rat_rejected_claims_hist_hdr.idx
#Move-Item -Force f088_rat_rejected_claims_hist_dtl.dat \\$Env:root\charly\purge\f088_rat_rejected_claims_hist_dtl.dat
#Move-Item -Force f088_rat_rejected_claims_hist_dtl.idx \\$Env:root\charly\purge\f088_rat_rejected_claims_hist_dtl.idx

#echo "--- create files ---"
<#$pipedInput = @"
create file f088-rat-rejected-claims-hist-hdr
create file f088-rat-rejected-claims-hist-dtl
"@

$pipedInput | qutil++#>
#$rcmd = $env:TRUNCATE+ "f088_rat_rejected_claims_hist_hdr"
#Invoke-Expression $rcmd
#$rcmd = $env:TRUNCATE+ "f088_rat_rejected_claims_hist_dtl"
#Invoke-Expression $rcmd

#Set-Location \\$Env:root\charly\purge

#$rcmd = $env:QTP + "purge_relof088"
#Invoke-Expression $rcmd *>>$env:pb_prod\purgef088.log

echo "Purge f088 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >>$env:pb_prod\purgef088.log
