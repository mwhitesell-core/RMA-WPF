#-------------------------------------------------------------------------------
# File 'batch_run_third_monthend_reports.bk1.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_third_monthend_reports.bk1'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_third_monthend_reports
##  execute $cmd/run_third_monthend_reports in batch

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_third_monthend_reports.bk1" -InitializationScript $init -ScriptBlock {
  & $env:cmd\run_third_monthend_reports > batch_run_third_monthend_reports.log
}
