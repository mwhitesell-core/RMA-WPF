#-------------------------------------------------------------------------------
# File 'batch_web_create_claims.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_web_create_claims'
#-------------------------------------------------------------------------------
  param(
        [string]$date
        )
##  $cmd/batch_web_create_claims
##  execute $cmd/web_create_claims in batch
##  user should pass   the date below before running this macro
<#$path = Convert-Path .
$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_web_create_claims" -InitializationScript $init -ScriptBlock {
  param(
    [string]$path,
    [string]$date
       )   
  $env:srvname = [system.environment]::MachineName + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" 101c
  cd $path#>
  &$env:cmd\web_create_claims  $date > web.ls
#} -ArgumentList $path, $date
