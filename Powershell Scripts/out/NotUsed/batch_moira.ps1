#-------------------------------------------------------------------------------
# File 'batch_moira.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_moira'
#-------------------------------------------------------------------------------

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_moira" -InitializationScript $init -ScriptBlock {
  & $env:cmd\moira $1 > moira.log
}
