#-------------------------------------------------------------------------------
# File 'batch_run_third_monthend_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_third_monthend_reports'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_third_monthend_reports
##  execute $cmd/run_monthend_stage40, $cmd/run_monthends_31to48, $cmd/run_monthend_ar 
##  and $cmd/reports_third_monthend in batch
<#$vers = $env:RMABILL_VERS
$path = Convert-Path .

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_third_monthend_reports" -InitializationScript $init -ScriptBlock {

  param(
        [string]$version,
	    [string]$path
        )

  $env:srvname = [system.environment]::MachineName + "." + [system.environment]::UserDomainName + ".LOCAL"
  &"\\$env:srvname\rma\scripts\rmabill" $version
  cd $path#>
  & $env:cmd\run_monthend_stage40 > batch_run_monthend_stage40.log
  & $env:cmd\run_monthend_ar > batch_run_monthend_ar.log
  & $env:cmd\run_monthends_31to48 > batch_run_monthends_31to48.log
  & $env:cmd\reports_third_monthend > batch_reports_third_monthend.log
#} -ArgumentList $vers, $path

echo "Done Running Third Monthend"
