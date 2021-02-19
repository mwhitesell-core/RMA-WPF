#-------------------------------------------------------------------------------
# File 'batch_run_monthends_60_82_83_86.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_run_monthends_60_82_83_86'
#-------------------------------------------------------------------------------

##  $cmd/batch_run_monthends_60_82_83_86
##  execute $cmd/run_monthends_60_82_83_86 in batch

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_run_monthends_60_82_83_86" -InitializationScript $init -ScriptBlock {
  & $env:cmd\run_monthends_60_82_83_86 > batch_run_monthends_60_82_83_86.log
}
