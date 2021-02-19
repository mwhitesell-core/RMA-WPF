#-------------------------------------------------------------------------------
# File 'purge_f084.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f084'
#-------------------------------------------------------------------------------

param(
  [string] $1
)

#  PURGE f084_claims_inventory file
#
# 2016/Jul/11   MC1     - correct to move f084 from charly to foxtrot

Set-Location \\$Env:root\charly\purge

Remove-Item purgef084.log *> $null

$out = $null
$rcmd = $env:QTP + "backup_earnings_daily 1 purge_f084"
Invoke-Expression $rcmd | Tee-Object -Variable out
$out | Add-Content $env:pb_data/backup_earnings_daily$1.ls

echo "Purge f084 -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > purgef084.log

$rcmd = $env:QTP + "purge_unlof084 20000101 $1"
Invoke-Expression $rcmd *>>purgef084.log

#Set-Location $env:pb_data

#echo "Move F084 to $Env:root\foxtrot\purge - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')"
#Invoke-Expression $rcmd >>purgef084.log

#Move-Item -Force f084_claims_inventory.dat \\$Env:root\foxtrot\purge\f084_claims_inventory.dat
#Move-Item -Force f084_claims_inventory.idx \\$Env:root\foxtrot\purge\f084_claims_inventory.idx

#echo "--- create file file F084 ---"
<#$pipedInput = @"
create file f084-claims-inventory  
"@

$pipedInput | qutil++#>
#$rcmd = $env:TRUNCATE+ "f084_claims_inventory"
#Invoke-Expression $rcmd

#Set-Location \\$Env:root\charly\purge

#echo "Reload F084 from subfile    - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >>purgef084.log

#$rcmd = $env:QTP + "purge_relof084"
#Invoke-Expression $rcmd *>>purgef084.log

echo "Purge f084 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" >>purgef084.log
