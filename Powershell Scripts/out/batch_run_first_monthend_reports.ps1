#-------------------------------------------------------------------------------
# File 'batch_run_first_monthend_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_first_monthend_reports'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_first_monthend_reports
##  execute $cmd/run_monthends_80_91to96, $cmd/reports_first_monthend in batch

<#$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_first_monthend_reports" -InitializationScript $init -ScriptBlock {
  $env:srvname = [system.environment]::MachineName + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" 101c#>
  & $env:cmd\run_monthends_80_91to96 > batch_run_monthends_80_91to96.log
  & $env:cmd\reports_first_monthend > batch_reports_first_monthend.log
#}
