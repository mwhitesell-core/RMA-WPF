#-------------------------------------------------------------------------------
# File 'batch_run_monthends_31to48.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_monthends_31to48'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_monthends_31to48
##  execute $cmd/run_monthends_31to48 in batch

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_monthends_31to48" -InitializationScript $init -ScriptBlock {
  & $env:cmd\run_monthends_31to48 > batch_run_monthends_31to48.log
}
