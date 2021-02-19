#-------------------------------------------------------------------------------
# File 'batch_yasemin.ps1'
# Converted to PowerShell by CORE Migration on 2017-12-06 16:09:57
# Original file name was 'batch_yasemin'
#-------------------------------------------------------------------------------

&$init = [scriptblock]::Create("{ Set-Location `"$(Get-Location)`" }")
Start-Job -Name "batch_yasemin" -InitializationScript $init -ScriptBlock {
  & $env:cmd\costing_noweb.com *> costing.ls
}
exit
