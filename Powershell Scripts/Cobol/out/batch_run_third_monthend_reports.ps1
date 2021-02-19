#-------------------------------------------------------------------------------
# File 'batch_run_third_monthend_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_run_third_monthend_reports'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_third_monthend_reports
##  execute $cmd/run_monthend_stage40, $cmd/run_monthends_31to48, $cmd/run_monthend_ar 
##  and $cmd/reports_third_monthend in batch

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_third_monthend_reports" -InitializationScript $init -ScriptBlock {
  & $cmd\run_monthend_stage40  > batch_run_monthend_stage40.log
  & $cmd\run_monthend_ar  > batch_run_monthend_ar.log
  & $cmd\run_monthends_31to48  > batch_run_monthends_31to48.log
  & $cmd\reports_third_monthend  > batch_reports_third_monthend.log
}
