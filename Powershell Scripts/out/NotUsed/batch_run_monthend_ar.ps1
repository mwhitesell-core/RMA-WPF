#-------------------------------------------------------------------------------
# File 'batch_run_monthend_ar.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_monthend_ar'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_monthend_ar
##  execute $cmd/run_monthend_ar in batch

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_monthend_ar" -InitializationScript $init -ScriptBlock {
  & $env:cmd\run_monthend_ar > batch_run_monthend_ar.log
}
