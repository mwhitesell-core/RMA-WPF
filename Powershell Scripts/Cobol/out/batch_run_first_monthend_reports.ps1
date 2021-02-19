#-------------------------------------------------------------------------------
# File 'batch_run_first_monthend_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_run_first_monthend_reports'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_first_monthend_reports
##  execute $cmd/run_monthends_80_91to96, $cmd/reports_first_monthend in batch

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_first_monthend_reports" -InitializationScript $init -ScriptBlock {
  & $cmd\run_monthends_80_91to96  > batch_run_monthends_80_91to96.log
  & $cmd\reports_first_monthend  > batch_reports_first_monthend.log
}
