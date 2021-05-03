#-------------------------------------------------------------------------------
# File 'batch_claims_subfile_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_claims_subfile_60_82_83_86'
#-------------------------------------------------------------------------------

##  $cmd/batch_claims_subfile_60_82_83_86
##  execute $cmd/claims_subfile_60_82_83_86 in batch
<#$vers = $env:RMABILL_VERS

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_claims_subfile_60_82_83_86" -InitializationScript $init -ScriptBlock {

  param(
        [string]$version
        )

  $env:srvname = $env:srvname + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" $version#>
  &$env:cmd\claims_subfile_60_82_83_86 > batch_claims_subfile_60_82_83_86.log
#} -ArgumentList $vers
