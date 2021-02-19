#-------------------------------------------------------------------------------
# File 'batch_claims_subfile_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_claims_subfile_80_91to96'
#-------------------------------------------------------------------------------

##  $cmd/batch_claims_subfile_80_91to96
##  execute $cmd/claims_subfile_80_91to96 in batch

<#$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_claims_subfile_80_91to96" -InitializationScript $init -ScriptBlock {
  $env:srvname = [system.environment]::MachineName + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" 101c#>
  & $env:cmd\claims_subfile_80_91to96 > batch_claims_subfile_80_91to96.log
#}
