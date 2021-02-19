#-------------------------------------------------------------------------------
# File 'batch_run_monthends_80_91to96.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_monthends_80_91to96'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_monthends_80_91to96
##  execute $cmd/run_monthends_80_91to96 in batch
$vers = $env:RMABILL_VERS

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_monthends_80_91to96" -InitializationScript $init -ScriptBlock {

  param(
        [string]$version
        )

  &"\\$env:srvname\rma\scripts\rmabill" $version
  $env:srvname = [system.environment]::MachineName + "." + [system.environment]::UserDomainName + ".LOCAL"
  & $env:cmd\run_monthends_80_91to96 > batch_run_monthends_80_91to96.log
} -ArgumentList $vers
