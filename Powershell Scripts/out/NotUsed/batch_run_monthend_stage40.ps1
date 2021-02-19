#-------------------------------------------------------------------------------
# File 'batch_run_monthend_stage40.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_monthend_stage40'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_monthend_stage40
##  execute $cmd/run_monthend_stage40 in batch

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_monthend_stage40" -InitializationScript $init -ScriptBlock {
  & $env:cmd\run_monthend_stage40 > batch_run_monthend_stage40.log
}
