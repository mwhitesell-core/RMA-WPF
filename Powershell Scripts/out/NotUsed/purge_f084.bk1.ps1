#-------------------------------------------------------------------------------
# File 'purge_f084.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'purge_f084.bk1'
#-------------------------------------------------------------------------------

#  PURGE f084_claims_inventory file
#
#

Set-Location $Env:root\charly\purge

Remove-Item purgef084.log *> $null

echo "Purge f084 -  STARTING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')" > purgef084.log

$rcmd = $env:QTP + "purge_unlof084 20000101 20141231"
Invoke-Expression $rcmd >>purgef084.log 2> purgef084.log

Set-Location $env:pb_data

echo "Move F084 to $Env:root\foxtrot\purge - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')""
Invoke-Expression $rcmd >>purgef084.log

Move-Item -Force f084_claims_inventory.dat $Env:root\charly\purge\f084_claims_inventory.dat
Move-Item -Force f084_claims_inventory.idx $Env:root\charly\purge\f084_claims_inventory.idx

echo "--- create file file F084 ---""
Invoke-Expression $rcmd >>purgef084.log
<#$pipedInput = @"
create file f084-claims-inventory  
"@

$pipedInput | qutil++#>
$rcmd = $env:TRUNCATE+ "f110-compensation-history"
Invoke-Expression $rcmd

Set-Location $Env:root\charly\purge

echo "Reload F084 from subfile    - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')""
Invoke-Expression $rcmd >>purgef084.log

$rcmd = $env:QTP + "purge_relof084"
Invoke-Expression $rcmd >>purgef084.log 2> purgef084.log

echo "Purge f084 - ENDING - $(Get-Date -uformat '%Y-%m-%d %H:%M:%S')""
Invoke-Expression $rcmd >>purgef084.log
