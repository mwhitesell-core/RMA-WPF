#-------------------------------------------------------------------------------
# File 'batch_run_second_monthend_reports.ps1'
# Converted to PowerShell by CORE Migration on 2017-04-13 17:40:47
# Original file name was 'batch_run_second_monthend_reports'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_second_monthend_reports
##  execute $cmd/run_monthends_60_82_83_86, $cmd/reports_second_monthend in batch

$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_second_monthend_reports" -InitializationScript $init -ScriptBlock {
  & $cmd\run_monthends_60_82_83_86  > batch_run_monthends_60_82_83_86.log
  & $cmd\reports_second_monthend  > batch_report_second_monthend.log
}
