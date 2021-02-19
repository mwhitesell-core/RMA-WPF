#-------------------------------------------------------------------------------
# File 'run_u010_daily.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'run_u010_daily'
#-------------------------------------------------------------------------------

Remove-Item u010.ls *> $null
&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "run_u010_daily" -InitializationScript $init -ScriptBlock {
  & $env:cmd\u010_daily ${1} >> u010.ls 2> u010.ls
}
