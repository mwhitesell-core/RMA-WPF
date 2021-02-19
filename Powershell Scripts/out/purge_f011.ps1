#-------------------------------------------------------------------------------
# File 'purge_f011.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f011'
#-------------------------------------------------------------------------------

#  PURGE f011 file
#  2013/Jan/07  MC1  - change to save original file from /charly/purge to /foxtrot/purge
#  2013/Apr/08  MC2  - change the log file location from $env:pb_prod to current directory /charly/purge
#

#cd $env:pb_prod
Set-Location \\$Env:root\charly\purge


#rm $env:pb_prod/purgef011.log 1>/dev/null  2>/dev/null
Remove-Item purgef011.log *> $null

echo "Purge f011 -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > purgef011.log

$rcmd = $env:QTP + "purge_unlof011"
Invoke-Expression $rcmd >>purgef011.log 2> purgef011.log

Set-Location $env:pb_data


Move-Item -Force f011_pat_mstr_elig_history.idx \\$Env:root\foxtrot\purge\f011_pat_mstr_elig_history.idx
Move-Item -Force f011_pat_mstr_elig_history \\$Env:root\foxtrot\purge\f011_pat_mstr_elig_history


echo "--- create files ---"
<#$pipedInput = @"
create file f011-pat-mstr-elig-history
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+ "f011_pat_mstr_elig_history"
Invoke-Expression $rcmd

Set-Location \\$Env:root\charly\purge

$rcmd = $env:QTP + "purge_relof011"
Invoke-Expression $rcmd >>purgef011.log 2> purgef011.log


echo "Purge f011 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >>purgef011.log
