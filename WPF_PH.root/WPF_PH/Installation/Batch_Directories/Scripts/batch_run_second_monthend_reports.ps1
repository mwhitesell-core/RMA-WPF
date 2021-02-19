#-------------------------------------------------------------------------------
# File 'batch_run_second_monthend_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_second_monthend_reports'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_second_monthend_reports
##  execute $cmd/run_monthends_60_82_83_86, $cmd/reports_second_monthend in batch
<#$vers = $env:RMABILL_VERS

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_second_monthend_reports" -InitializationScript $init -ScriptBlock {

  param(
        [string]$version
        )

  $env:srvname = [system.environment]::MachineName + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" $version#>
  & $env:cmd\run_monthends_60_82_83_86 > batch_run_monthends_60_82_83_86.log
  & $env:cmd\reports_second_monthend > batch_report_second_monthend.log
#} -ArgumentList $vers
