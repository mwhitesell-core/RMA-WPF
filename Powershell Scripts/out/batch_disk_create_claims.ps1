#-------------------------------------------------------------------------------
# File 'batch_disk_create_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_disk_create_claims'
#-------------------------------------------------------------------------------

##  $cmd/batch_disk_create_claims
##  execute $cmd/disk_create_claims in batch
<#$path = Convert-Path .
$vers = $env:RMABILL_VERS
$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_disk_create_claims" -InitializationScript $init -ScriptBlock {
  param(
    [string]$path,
    [string]$vers
       )
  $env:srvname = $env:srvname + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" $vers
  cd $path#>
  &$env:cmd\disk_create_claims > claims.ls
#} -ArgumentList $path, $vers
